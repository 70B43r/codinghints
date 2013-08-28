//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Login result.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using CookComputing.XmlRpc;

namespace tobaer.CSharp.codinghints.XmlRpc.Part3
{
   public class LogInResult
   {
      [XmlRpcMember("id")]
      public int Id { get; set; }
   }
}