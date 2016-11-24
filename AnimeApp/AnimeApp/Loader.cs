using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AnimeApp {
    public static class Loader {

        public static Dictionary<int, Unit> loadFrom(string file) {

            if(!File.Exists(file)) {
                throw new System.Exception("File (" + file + ") doesn't exist!");
            }

            Dictionary<int, Unit> input = new Dictionary<int, Unit>();
            int idCounter = -1;
            

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
            //units = new Dictionary<int, Unit>();
            int id = -1;
            int year = -1;
            Rating rating = null;
            Genre genre = null;
            string name = "";
            string info = "";

            while(xrr.Read()) {
                
                if(xrr.NodeType == XmlNodeType.EndElement) {
                    //End element
                    if(xrr.Name == "Units") break;
                    if(xrr.Name == "Unit") {
                        Unit u = new Unit(id, name, year, rating, genre, info);
                        units.Add(u.getId(), u);
                    }
                }else {
                    //Start element
                    switch(xrr.Name) {
                        case "Unit":
                            try {
                                id = int.Parse(xrr["id"]);
                            } catch(Exception e) {
                                throw new System.Exception("id NaN");
                            }
                            name = xrr["name"];
                            break;
                        case "Year":
                            xrr.Read();
                            try {
                                year = int.Parse(xrr.Value.Trim());
                            } catch(Exception e) {
                                throw new System.Exception("Year NaN");
                            }
                            break;
                        case "Rating":
                            xrr.Read();
                            rating = new Rating(xrr.Value.Trim().Length);
                            break;
                        case "Genre":
                            xrr.Read();
                            genre = new Genre(xrr.Value.Trim().Split(' '));
                            break;
                        case "Info":
                            xrr.Read();
                            info = xrr.Value.Trim();
                            break;
                    }
                }
            }
        }

        public static void saveAs(string file, Dictionary<int, Unit> source) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineOnAttributes = true;

            using(XmlWriter xwr = XmlWriter.Create(file, settings)) {
                xwr.WriteStartDocument();
                xwr.WriteStartElement("Root");  //Root

                //id counter
                xwr.WriteStartElement("id_counter");
                xwr.WriteString("" + Storage.getIdCounter());
                xwr.WriteEndElement();

                xwr.WriteStartElement("Units"); //Units

                foreach(KeyValuePair<int, Unit> item in source) {
                    xwr.WriteStartElement("Unit");  //Unit
                    xwr.WriteAttributeString("name", "" + item.Value.name);     //name
                    xwr.WriteAttributeString("id", "" + item.Value.getId());    //id

                    //Year
                    xwr.WriteStartElement("Year");
                    xwr.WriteString("" + item.Value.year);
                    xwr.WriteEndElement();

                    //Rating
                    xwr.WriteStartElement("Rating");
                    xwr.WriteString("" + item.Value.rating);
                    xwr.WriteEndElement();

                    //Genre
                    xwr.WriteStartElement("Genre");
                    xwr.WriteString("" + item.Value.genre);
                    xwr.WriteEndElement();

                    //Info
                    xwr.WriteStartElement("Info");
                    xwr.WriteString("" + item.Value.info);
                    xwr.WriteEndElement();

                    xwr.WriteEndElement();  //Unit
                }
                xwr.WriteEndElement();  //Units
                xwr.WriteEndElement();  //Root

                xwr.WriteEndDocument();
                xwr.Close();
            }
        }

    }
}
