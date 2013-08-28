//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : User info response container.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using CookComputing.XmlRpc;

namespace tobaer.CSharp.codinghints.XmlRpc.Part3
{
   public class UserInfoResponse
   {
      private UserInfo[] userInfos;

      [XmlRpcMember("users")]
      public UserInfo[] UserInfos
      {
         get { return userInfos ?? new UserInfo[0]; }
         set { userInfos = value; }
      }
   }
}