﻿using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Prosen.Common.Serializer
{
    /// <summary>
    /// Json序列化帮助类
    /// </summary>
    public class SerializerJsonHelper
    {
        // 从一个对象信息生成Json串
        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
        // 从一个Json串生成对象信息
        public static object JsonToObject(string jsonString, object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return serializer.ReadObject(mStream);
            }

        }
    }
}
