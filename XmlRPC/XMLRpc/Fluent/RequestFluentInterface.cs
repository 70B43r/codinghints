//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Fluent definition.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System;
using System.IO;
using System.Net;
using XMLRpcTest;

namespace tobaer.CSharp.codinghints.XmlRpc
{
   internal static class RequestFluent
   {
      /// <summary>
      /// Defines the method.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <param name="methodName">Name of the method.</param>
      /// <returns>The request.</returns>
      public static Request WithMethod(this Request request, string methodName)
      {
         request.Method = methodName;

         return request;
      }

      public static Request AddParam(this Request request, string name, int value)
      {
         return AddParam(request, name, value, MemberValue.ValueType.@int);
      }

      public static Request AddParam(this Request request, string name, string value)
      {
         return AddParam(request, name, value, MemberValue.ValueType.@string);
      }

      public static Request AddParam(this Request request, string name, DateTime value)
      {
         return AddParam(request, name, value, MemberValue.ValueType.datetime);
      }

      public static Request AddParam(this Request request, string name, double value)
      {
         return AddParam(request, name, value, MemberValue.ValueType.@double);
      }

      public static Request AddBase64Param(this Request request, string name, string value)
      {
         return AddParam(request, name, value, MemberValue.ValueType.base64);
      }

      public static Request AddParam(this Request request, string name, Array value)
      {
         return AddParam(request, name, value, MemberValue.ValueType.array);
      }

      private static Request AddParam(this Request request, string name, object value, MemberValue.ValueType valueType)
      {
         Member m = new Member()
         {
            Name = name,
            Value = new MemberValue()
            {
               Value = value,
               ValueChoice = valueType
            }
         };

         Param param = new Param { Value = new Value() };
         param.Value.Member.Add(m);

         request.Params.Add(param);

         return request;
      }

      public static Response Excecute(this Request request, string target)
      {
         var requestData = request.Serialize();

         using (Stream stream = QueryHelper.QueryData(requestData))
            return stream.DeSerialize<Response>();
      }
   }
}