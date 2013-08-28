//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Part 2 of xml rpc.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////

using System;
using System.Configuration;
using System.Linq;
using CookComputing.XmlRpc;
using NUnit.Framework;
using log4net;

namespace tobaer.CSharp.codinghints.XmlRpc.Part3
{
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