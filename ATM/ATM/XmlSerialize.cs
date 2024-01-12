using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ATM
{
    public class XmlSerialize
    {
        public void convertObjectToXml<T>(T obj, string file, bool overwrite)
        {
            bool append = !overwrite;
            using (StreamWriter writer = new StreamWriter(file, append, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
            }
        }
        public List<T> convertXmlToObjects<T>(string fileName)
        {
            List<T> list;
            using (StreamReader reader = new StreamReader(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                list = (List<T>)serializer.Deserialize(reader);
            }
            return list;
        }
        public T convertXmlToObject<T>(string fileName)
        {
            T obj;
            using (StreamReader reader = new StreamReader(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                obj = (T)serializer.Deserialize(reader);
            }

            return obj;
        }
    }
}
