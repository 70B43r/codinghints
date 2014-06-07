//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Part 3 of XmlRpc samples.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using NUnit.Framework;
using log4net;
using tobaer.CSharp.codinghints.XmlRpc.Part2.SimpleMethod;

namespace tobaer.CSharp.codinghints.XmlRpc.Part2
{
	[TestFixture]
	public sealed class XmlRpc
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(XmlRpc));

		[Test]
		public void Should_Query_Version()
		{
			var requestObj = new Request { Method = "Bugzilla.version" };

			byte[] requestData;
			using (var memStream = new MemoryStream())
			{
				var serializer = new XmlSerializer(typeof(Request));
				serializer.Serialize(memStream, requestObj);

				memStream.Flush();

				requestData = memStream.ToArray();
			}

			using (var memStream = QueryHelper.QueryData(requestData))
			using (var destinationStream = new MemoryStream())
			{
				Log.Info("Transforming data");

				var xslTransform = new XslCompiledTransform();
				xslTransform.Load(@"Part2\TransformResponse.xslt");

				using (var xmlReader = XmlReader.Create(memStream))
					xslTransform.Transform(xmlReader, null, destinationStream);

				var xmlSerializer = new XmlSerializer(typeof(VersionResult));

				Log.Info("Deserializing to useful model");

				destinationStream.Seek(0, SeekOrigin.Begin);
				var version = (VersionResult)xmlSerializer.Deserialize(destinationStream);

				Log.Info("Deserializing to raw model");

				memStream.Seek(0, SeekOrigin.Begin);
				var result = memStream.DeSerialize<Response>();

				Assert.That(version.FaultCode, Is.Null.Or.Empty, version.FaultString);

				Log.InfoFormat("Received: {0}", version.Version);
				Assert.That(version.Version, Is.EqualTo(result.Params[0].Param.Value.Member[0].Value.Value));
			}
		}

		[Test]
		public void Should_Query_With_simple_args()
		{
			// HACK: hardcoded result
			const string expectedResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?><SimpleCall>" +
													"<methodName>simpleMethod</methodName><params><param><value>" +
													"<i4>12</i4></value></param></params></SimpleCall>";

			var call = new SimpleCall
						  {
							  Method = "simpleMethod",
							  Arguments = new List<MethodCallArgument>
											  {
												  new MethodCallArgument { Value = 12 }
											  }
						  };

			string serializedCall;
			using (var memoryStream = new MemoryStream(call.Serialize()))
			using (var streamReader = new StreamReader(memoryStream))
				serializedCall = streamReader.ReadToEnd();

			Log.Info(serializedCall);

			Assert.That(serializedCall, Is.EqualTo(expectedResult));
		}
	}
}