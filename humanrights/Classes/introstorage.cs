using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace humanrights.Classes
{

    internal class introstorage
    {

        internal static void WriteXml<T>(T data, string file )
        {
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(T));


                FileStream stream;



                stream = new FileStream(file, FileMode.Create);



                sr.Serialize(stream, data);
                stream.Close();
            }

            catch (Exception x)
            {
                MessageBox.Show(x.ToString(), "Error");
                throw;
            }

        }


        internal static T GetResourceXML<T>(string file)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("humanrights.Data" + file))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));
                        return (T)ser.Deserialize(sr);
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
                return default(T);
            }

        }
        //internal static T ReadXml<T>(string file)
        //{
        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(file))
        //        {
        //            XmlSerializer serializer = new XmlSerializer(typeof(T));
        //            return (T)serializer.Deserialize(sr);
        //        }
        //    }

        //    catch (Exception x)
        //    {
        //        MessageBox.Show(x.ToString(), "Error");
        //        return default(T);
        //    }

        //}
    }
}
