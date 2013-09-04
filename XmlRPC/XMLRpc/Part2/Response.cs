//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Response data.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using System.Xml.Serialization;

namespace tobaer.CSharp.codinghints.XmlRpc.Part2
{
   [XmlRoot("methodResponse", Namespace = "")]
   public class Response
   {
      [XmlElement("fault", Namespace = "")]
      public Fault Fault { get; set; }

      [XmlElement("params", Namespace = "")]
      public List<ResponseParams> Params { get; set; }
   }

   public class ResponseParams
   {
      [XmlElement("param", Namespace = "")]
      public ResponseParam Param { get; set; }
   }

   public class ResponseParam
   {
      [XmlElement("value", Namespace = "")]
      public ResponseValue Value { get; set; }
   }

   public class ResponseValue
   {
      [XmlArray("struct", Namespace = ""), XmlArrayItem("member", Namespace = "")]
      public List<Member> Member { get; set; }
   }

   [XmlRoot("methodResponse", Namespace = "")]
   public class VersionResult
   {
      [XmlElement("faultString", Namespace = "")]
      public string FaultString { get; set; }

      [XmlElement("faultCode", Namespace = "")]
      public string FaultCode { get; set; }

      [XmlElement("version", Namespace = "")]
      public string Version { get; set; }
   }
}