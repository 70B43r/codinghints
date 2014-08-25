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
   public class Bugs
   {
      [XmlRpcMember("bugs")]
      public XmlRpcStruct Bug { get; set; }
   }
}