//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Login data container.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using CookComputing.XmlRpc;

namespace tobaer.CSharp.codinghints.XmlRpc.Part3
{
   public class LogIn
   {
      [XmlRpcMember("login")]
      public string User { get; set; }

      [XmlRpcMember("password")]
      public string Password { get; set; }

      [XmlRpcMember("remember")]
      public bool Remember { get; set; }
   }
}