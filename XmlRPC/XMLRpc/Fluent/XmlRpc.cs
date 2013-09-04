//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Fluent sample.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using NUnit.Framework;
using log4net;
using tobaer.CSharp.codinghints.XmlRpc.Part2;

namespace tobaer.CSharp.codinghints.XmlRpc.Fluent
{
   [TestFixture]
   public class XmlRpc
   {
      private static readonly ILog Log = LogManager.GetLogger(typeof(XmlRpc));

      [Test]
      public void Should_Query_Fluent()
      {
         var response = new Request()
            .WithMethod("Bugzilla.version")
            .Excecute("https://bugzilla.mozilla.org/xmlrpc.cgi");

         Log.InfoFormat("received: {0}", response.Params[0].Param.Value.Member[0].Value.Value);
      }
   }
}