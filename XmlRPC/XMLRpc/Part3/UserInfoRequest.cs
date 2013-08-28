//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Userinfo request container.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using CookComputing.XmlRpc;

namespace tobaer.CSharp.codinghints.XmlRpc.Part3
{
   public class UserInfoRequest
   {
      private int[] ids;

      [XmlRpcMember("ids")]
      public int[] Ids
      {
         get { return ids ?? new int[0]; }
         set { ids = value; }
      }

      private string[] names;

      [XmlRpcMember("names")]
      public string[] Names
      {
         get { return names ?? new string[0]; }
         set { names = value; }
      }

      private string[] matches;

      [XmlRpcMember("match")]
      public string[] Matches
      {
         get { return matches ?? new string[0]; }
         set { matches = value; }
      }
   }
}