//////////////////////////////////////////////////////////////////////////////////
//
// Project            : XMLRpc
// Description        : Serializer.
//
// Copyright          : (c) 2013 Torsten Bär
//
// Published under the MIT License. See license.rtf or http://www.opensource.org/licenses/mit-license.php.
//
//////////////////////////////////////////////////////////////////////////////////
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace tobaer.CSharp.codinghints.XmlRpc
{
   /// <summary>
   /// Xml - Serializer 
   /// </summary>
   public static class XmlRpcSerializer
   {
      /// <summary>
      /// Serializes the specified object.
      /// </summary>
      /// <typeparam name="T">The Type</typeparam>
      /// <param name="object">The object to serialize.</param>
      /// <returns>The serialized object data.</returns>
      public static byte[] Serialize<T>(this T @object)
      {
         return Serialize(@object, Encoding.UTF8);
      }

      /// <summary>
      /// Serializes the specified object.
      /// </summary>
      /// <typeparam name="T">The Type</typeparam>
      /// <param name="object">The object to serialize.</param>
      /// <param name="encoding">The encoding.</param>
      /// <returns>The serialized object data.</returns>
      public static byte[] Serialize<T>(this T @object, Encoding encoding)
      {
         XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
         namespaces.Add(String.Empty, String.Empty);

         using (MemoryStream memStream = new MemoryStream())
         {
            using (XmlTextWriter writer = new XmlTextWriter(memStream, encoding))
            {
               XmlSerializer serializer = new XmlSerializer(typeof(T));
               serializer.Serialize(writer, @object, namespaces);
            }

            return memStream.ToArray();
         }
      }

      /// <summary>
      /// Deserializes the data.
      /// </summary>
      /// <typeparam name="T">The type.</typeparam>
      /// <param name="data">The datastream.</param>
      /// <returns>The deserialized instance.</returns>
      public static T DeSerialize<T>(this Stream data)
      {
         var deSerializer = new XmlSerializer(typeof(T));

         return (T)deSerializer.Deserialize(data);
      }
   }
}