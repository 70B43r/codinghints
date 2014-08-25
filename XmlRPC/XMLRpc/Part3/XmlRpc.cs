//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Part 3 of xml rpc.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////

using System;
using System.Configuration;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;
using NUnit.Framework;
using log4net;

namespace tobaer.CSharp.codinghints.XmlRpc.Part3
{
	using System.Dynamic;

	[TestFixture]
	public sealed class XmlRpc
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(XmlRpc));

		[Test]
		public void Should_Query_Version()
		{
			var bugzilla = XmlRpcProxyGen.Create<IBugzilla>();
			Log.InfoFormat("Received: {0}", bugzilla.Version().Version);
		}

		[Test]
		public void Query_Bug_Comment([Random(1, 415555, 5)] int id)
		{
			var bugzilla = XmlRpcProxyGen.Create<IBugzilla>();

			var bugComments = bugzilla.BugComments(new[] { id });

			var commentsArray = ((object[])((XmlRpcStruct)bugComments.Bug[id.ToString()])["comments"]);

			Log.InfoFormat("received {0} comments", commentsArray.Length);

			var stringBuilder = new StringBuilder();

			foreach (var comment in commentsArray.OfType<XmlRpcStruct>())
			{
				var text = (string)comment["text"];
				stringBuilder.AppendFormat("{0} ({2}) :{1}", comment["author"],
													text.Substring(0, Math.Min(100, text.Length)), comment["creation_time"]);
				stringBuilder.AppendLine();
			}

			Log.Info(stringBuilder);
		}

		[Test]
		public void Query_Bug_with_reduced_fields([Random(1, 415555, 5)] int id)
		{
			var bugzilla = XmlRpcProxyGen.Create<IBugzilla>();

			var fields = new[] { "id", "creator", "summary" };
			var rpcStruct = bugzilla.GetBug(new[] { id }, fields);

			var bugsArray = rpcStruct["bugs"] as object[];
			Assert.That(bugsArray, Is.Not.Null);

			if (bugsArray.Length == 0)
				Assert.Inconclusive("No bugs available");

			var bugItem = (XmlRpcStruct)bugsArray.First();

			foreach (var field in bugItem.Keys.OfType<string>())
			{
				Assert.That(fields.Any(f => field.StartsWith(f)), Is.True, "Field {0} not requested", field);
			}

			dynamic rpcResult = new DynamicRpcObject(rpcStruct);
			foreach (var bug in rpcResult.Bugs)
				Log.InfoFormat("{0} was created by {1}: {2}", bug.Id, bug.Creator, bug.Summary);
		}

		[Test]
		public void Should_Query_User()
		{
			var bugzilla = XmlRpcProxyGen.Create<IBugzilla>();
			var versionResult = bugzilla.Version();

			Log.InfoFormat("Bugzilla version: {0}", versionResult.Version);

			try
			{
				var user = XmlRpcProxyGen.Create<IUser>();

				var logIn = user.LogIn(new LogIn
											  {
												  User = ConfigurationManager.AppSettings["user"],
												  Password = ConfigurationManager.AppSettings["password"]
											  });

				Log.InfoFormat("logged in as {0}", logIn.Id);

				user.CookieContainer.Add(user.ResponseCookies);

				var userInfo = user.GetUserInfo(new UserInfoRequest { Ids = new[] { logIn.Id }, });

				if (userInfo.UserInfos.Any())
				{
					var first = userInfo.UserInfos.First();

					Log.InfoFormat("I'm {0}", first.RealName);
				}
				else
				{
					Log.Info("No user");
				}

				user.LogOut();
			}
			catch (Exception exception)
			{
				Log.Error("error retrieving user info", exception);

			}
		}
	}
}