using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;

namespace Person.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Person person = new Person();
            //person.Name = "王三";
            person.Data = DateTime.Now;
            person.Des = "小王";

            string xml = XmlSerializerHelp.SerializeObjectToXML(person);

            string xmlA = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Person><Des>小王</Des><Data>2014-03-10T14:03:14.2350144+08:00</Data></Person>";
            Person personXml = XmlSerializerHelp.DeserializeXMLToObject<Person>(xmlA);
        }
    }


    public class XmlSerializerHelp
    {
        #region 将对象序列化成XML
        /// <summary>
        /// 将对象序列化成XML
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string SerializeObjectToXML<T>(T t)
        {
            return SerializeObjectToXML<T>(t, Encoding.UTF8);
        }

        /// <summary>
        /// 将对象序列化成XML
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string SerializeObjectToXML<T>(T t, Encoding encoding)
        {
            XmlSerializer ser = new XmlSerializer(t.GetType());
            using (MemoryStream mem = new MemoryStream())
            {
                using (XmlTextWriter writer = new XmlTextWriter(mem, encoding))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    ser.Serialize(writer, t, ns);
                    return encoding.GetString(mem.ToArray()).Trim();
                }
            }
        }

        /// <summary>
        /// json字符串转换为Xml对象
        /// </summary>
        /// <param name="sJson">json字串</param>
        /// <param name="xmlROOT">自定义xml根节点</param>
        /// <returns></returns>
        public static XmlDocument Json2Xml(string sJson, string xmlROOT)
        {
            /*json字符串需要把键加""才行*/
            //XmlDictionaryReader reader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(sJson), XmlDictionaryReaderQuotas.Max);
            //XmlDocument doc = new XmlDocument();
            //doc.Load(reader);
            /*json字符串需要把键加""才行*/

            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            Dictionary<string, object> Dic = (Dictionary<string, object>)oSerializer.DeserializeObject(sJson);
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDec;
            xmlDec = doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            doc.InsertBefore(xmlDec, doc.DocumentElement);
            XmlElement nRoot = doc.CreateElement(xmlROOT);
            doc.AppendChild(nRoot);
            foreach (KeyValuePair<string, object> item in Dic)
            {
                XmlElement element = doc.CreateElement(item.Key);
                KeyValue2Xml(element, item);
                nRoot.AppendChild(element);
            }
            return doc;
        }

        private static void KeyValue2Xml(XmlElement node, KeyValuePair<string, object> Source)
        {
            object kValue = Source.Value;
            if (kValue.GetType() == typeof(Dictionary<string, object>))
            {
                foreach (KeyValuePair<string, object> item in kValue as Dictionary<string, object>)
                {
                    XmlElement element = node.OwnerDocument.CreateElement(item.Key);
                    KeyValue2Xml(element, item);
                    node.AppendChild(element);
                }
            }
            else if (kValue.GetType() == typeof(object[]))
            {
                object[] o = kValue as object[];
                for (int i = 0; i < o.Length; i++)
                {
                    XmlElement xitem = node.OwnerDocument.CreateElement("Item");
                    KeyValuePair<string, object> item = new KeyValuePair<string, object>("Item", o[i]);
                    KeyValue2Xml(xitem, item);
                    node.AppendChild(xitem);
                }
            }
            else
            {
                XmlText text = node.OwnerDocument.CreateTextNode(kValue.ToString());
                node.AppendChild(text);
            }
        }
        #endregion

        #region 将XML反序列化成对象
        /// <summary>
        /// 将XML反序列化成对象
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T DeserializeXMLToObject<T>(string source)
        {
            return DeserializeXMLToObject<T>(source, Encoding.UTF8);
        }

        /// <summary>
        /// 将XML反序列化成对象
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T DeserializeXMLToObject<T>(string source, Encoding encoding)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(encoding.GetBytes(source)))
            {
                return (T)mySerializer.Deserialize(stream);
            }
        }
        #endregion
    }
}
