//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Userinfo container.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using CookComputing.XmlRpc;

namespace tobaer.CSharp.codinghints.XmlRpc.Part3
{
   public class UserInfo
   {
      [XmlRpcMember("id")]
      public int Id { get; set; }

      [XmlRpcMember("name"), XmlRpcMissingMapping(MappingAction.Ignore)]
      public string Name { get; set; }

      [XmlRpcMember("real_name"), XmlRpcMissingMapping(MappingAction.Ignore)]
      public string RealName { get; set; }

      [XmlRpcMember("email"), XmlRpcMissingMapping(MappingAction.Ignore)]
      public string eMail { get; set; }
   }
}