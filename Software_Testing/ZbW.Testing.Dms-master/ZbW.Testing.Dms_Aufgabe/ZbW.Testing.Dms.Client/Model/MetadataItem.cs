using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


namespace ZbW.Testing.Dms.Client.Model
{
    /*internal*/ class MetadataItem //: IXmlSerializable
    {

        public string _bezeichnung;
        public DateTime _valutaDate;
        public string _typ;
        public List<String> _stichwoerter;
        public DateTime _erfassungsdatum;
        public string _benutzer;

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public MetadataItem ReadXml(string streamFile) 
        {
            var xml_Serializer = new XmlSerializer(typeof(MetadataItem));
            var streamReader = new StreamReader(streamFile);
            var metadataItem = (MetadataItem)xml_Serializer.Deserialize(streamReader);
            if (metadataItem == null)
            {
                throw new Exception("Das hat nicht geklappt..");
            }
            return metadataItem;
        }

        [ExcludeFromCodeCoverage]
        public void WriteXml(string targetDir, string returnFileNameMetadata, MetadataItem metadataItem)
        {
            var xmlSerializer = new XmlSerializer(typeof(MetadataItem));
            var streamWriter = new StreamWriter(Path.Combine(targetDir, returnFileNameMetadata));
            xmlSerializer.Serialize(streamWriter, metadataItem);
            streamWriter.Flush();
            streamWriter.Close();
        }








        /* public string[] ReadXml(string searchedItem)
        {
            String[] Files = Directory.GetFiles(@"C:\temp\DMS");
            if (Files != null)
            {
                String[] FoundItems = new string[100];
                int index = 0;

                foreach (string file in Files)
                {
                    String[] SubFiles = Directory.GetFiles(file, "*.xml");
                    foreach (string subfile in SubFiles)
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(subfile);
                        XmlNode nodeBez = doc.DocumentElement.SelectSingleNode("Document/Bezeichnung");
                        XmlNode nodeStich = doc.DocumentElement.SelectSingleNode("Document/Bezeichnung");

                        if (nodeBez.InnerText == searchedItem || nodeStich.InnerText == searchedItem)
                        {
                            FoundItems[index] = subfile;
                            index++;
                        }
                    }
                }
                return FoundItems;
            }
            return null;
        }*/
    }
}

