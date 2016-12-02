using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AnimeApp {
    public static class Loader {

        public static Dictionary<int, Unit> loadFrom(string file, out int idCounter) {

            if(!File.Exists(file)) {
                throw new System.Exception("File (" + file + ") doesn't exist!");
            }

            Dictionary<int, Unit> input = new Dictionary<int, Unit>();
            idCounter = -1;
            

            using(XmlReader xrr = XmlReader.Create(file)) {
                while(xrr.Read()) {
                    if(xrr.IsStartElement()) {
                        //start element
                        switch(xrr.Name) {
                            case "id_counter":
                                xrr.Read();
                                try {
                                    idCounter = int.Parse(xrr.Value.Trim());
                                } catch(Exception e) {
                                    throw new System.Exception("id_counter NaN");
                                }
                                break;
                            case "Units":
                                readUnits(xrr, input);
                                break;
                        }
                    }
                }
            }
            
            return input;
        }

        private static void readUnits(XmlReader xrr, Dictionary<int, Unit> units) {

            while(xrr.Read()) {
                if(xrr.IsStartElement()) {
                    //Start element
                    if(xrr.Name == "Unit") {
                        Unit u = new Unit(xrr);
                        units.Add(u.getId(), u);
                    }
                }else {
                    //End element
                    if(xrr.Name == "Units")
                        break;
                }
            }
        }

        public static void saveAs(string file, Dictionary<int, Unit> source) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineOnAttributes = true;

            if(!Directory.Exists(Storage.APPDATA + Storage.SAVE_FOLDER)) {
                Directory.CreateDirectory(Storage.APPDATA + "\\" + Storage.SAVE_FOLDER);
            }

            using(XmlWriter xwr = XmlWriter.Create(file, settings)) {
                xwr.WriteStartDocument();
                xwr.WriteStartElement("Root");  //Root

                //id counter
                xwr.WriteStartElement("id_counter");
                xwr.WriteString("" + Storage.getIdCounter());
                xwr.WriteEndElement();

                xwr.WriteStartElement("Units"); //Units

                foreach(KeyValuePair<int, Unit> item in source) {
                    item.Value.toXmlOutput(xwr);
                }
                xwr.WriteEndElement();  //Units
                xwr.WriteEndElement();  //Root

                xwr.WriteEndDocument();
                xwr.Close();
            }
        }

    }
}
