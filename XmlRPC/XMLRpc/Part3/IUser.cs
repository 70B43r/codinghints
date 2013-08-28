//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : User proxy.
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
   public interface IUser : IXmlRpcProxy
   {
      [XmlRpcMethod("User.login")]
      LogInResult LogIn(LogIn logIn);

      [XmlRpcMethod("User.get")]
      UserInfoResponse GetUserInfo(UserInfoRequest userInfoRequest);

      [XmlRpcMethod("User.logout")]
      void LogOut();
   }
}