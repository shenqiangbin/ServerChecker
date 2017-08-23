using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// Represents a serialization helper for XML file.
/// </summary>
public static class XMLFileSerializationHelper
{
    /// <summary>
    /// Serializes the specified object instance to XML file.
    /// </summary>
    /// <typeparam name="T">The specified object instance type.</typeparam>
    /// <param name="obj">The object instance.</param>
    /// <param name="filePath">The XML file path with full name.</param>
    public static void SerializeObjectToXMLFile<T>(T obj, string filePath) where T : class
    {
        if (obj == null)
            throw new ArgumentNullException("obj");
        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentNullException("filePath");

        Stream stream = null;
        XmlTextWriter xmlTextWriter = null;
        try
        {
            using (stream = File.Open(filePath, FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, obj);
                xmlTextWriter.Flush();
                xmlTextWriter.Close();
                stream.Close();
            }
        }
        finally
        {
            if (xmlTextWriter != null)
                xmlTextWriter.Close();

            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
            }
        }
    }

    /// <summary>
    /// Deserializes from the specified XML file to an object instance.
    /// </summary>
    /// <typeparam name="T">The object instance type.</typeparam>
    /// <param name="filePath">The specified XML file with full name.</param>
    /// <returns>The object instance.</returns>
    public static T DeserializeObjectFromXMLFile<T>(string filePath) where T : class
    {
        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentNullException("filePath");

        Stream stream = null;
        try
        {
            stream = File.Open(filePath, FileMode.Open);
            XmlSerializer xs = new XmlSerializer(typeof(T));
            return xs.Deserialize(stream) as T;
        }
        finally
        {
            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
            }
        }
    }
}
