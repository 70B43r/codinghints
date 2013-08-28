//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : XmlRpc base class.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System.IO;
using System.Net;
using log4net;

namespace tobaer.CSharp.codinghints.XmlRpc
{
   internal abstract class QueryHelper
   {
      private static readonly ILog Log = LogManager.GetLogger(typeof(QueryHelper));

      public static MemoryStream QueryData(byte[] payload)
      {
         var request = (HttpWebRequest)WebRequest.Create("https://bugzilla.mozilla.org/xmlrpc.cgi");
         request.Method = "POST";
         request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729;)";
         request.ContentType = "text/xml";
         request.ContentLength = payload.Length;

         Log.InfoFormat("Sending request to {0}", request.RequestUri);

         using (Stream requestStream = request.GetRequestStream())
            requestStream.Write(payload, 0, payload.Length);

         var memoryStream = new MemoryStream();
         using (var httpWebResponse = (HttpWebResponse)request.GetResponse())
         using (var responseStream = httpWebResponse.GetResponseStream())
            responseStream.CopyTo(memoryStream);

         memoryStream.Seek(0, SeekOrigin.Begin);

         return memoryStream;
      }
   }
}