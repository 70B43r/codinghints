//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Part 1 of XmlRpc.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////

using System.IO;
using System.Text;
using NUnit.Framework;
using log4net;

namespace tobaer.CSharp.codinghints.XmlRpc.Part1
{
   [TestFixture]
   public sealed class XmlRpc
   {
      private static readonly ILog Log = LogManager.GetLogger(typeof(XmlRpc));

      [Test]
      public void Should_Query_Version()
      {
         byte[] requestData = Encoding.ASCII.GetBytes("<?xml version=\"1.0\"?><methodCall><methodName>Bugzilla.version</methodName></methodCall>");

         using (var memoryStream = QueryHelper.QueryData(requestData))
         using (var streamReader = new StreamReader(memoryStream))
            Log.InfoFormat("received; {0}", streamReader.ReadToEnd());
      }

      [Test]
      public void Query_Bug_Comment([Values(415555)]int id)
      {
         byte[] requestData =
            Encoding.ASCII.GetBytes("<?xml version=\"1.0\"?><methodCall><methodName>Bug.comments</methodName>" +
                                    "<params><param><value><struct><member><name>ids</name><value><i4>" + id +
                                    "</i4></value></member></struct></value></param></params>" +
                                    "</methodCall>");

         using (var memoryStream = QueryHelper.QueryData(requestData))
         using (var streamReader = new StreamReader(memoryStream))
            Log.InfoFormat("received; {0}", streamReader.ReadToEnd());
      }
   }
}