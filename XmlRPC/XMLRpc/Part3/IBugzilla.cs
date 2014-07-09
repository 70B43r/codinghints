//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Part 3 of xml rpc post.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////

using CookComputing.XmlRpc;

namespace tobaer.CSharp.codinghints.XmlRpc.Part3
{
   [XmlRpcUrl("https://bugzilla.mozilla.org/xmlrpc.cgi")]
   public interface IBugzilla : IXmlRpcProxy
   {
      [XmlRpcMethod("Bugzilla.version")]
      VersionResult Version();

      [XmlRpcMethod("Bug.comments", StructParams = true)]
      BugComments BugComments(int[] ids);
   }
}