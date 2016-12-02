using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AnimeApp {
    public class Unit {
        public static columnInfo[] columnsInfo;
        private int id { get; set; }

        public string name      { get; set; }
        public int year         { get; set; }
        public Rating rating    { get; set; }
        public Genre genre      { get; set; }
        public Boolean watched  { get; set; }
        public String info      { get; set; }

        static Unit() {
            columnsInfo = new columnInfo[] {
                new columnInfo("id", "id", typeof(int)),
                new columnInfo("name", "Name", typeof(string)),
                new columnInfo("year", "Year", typeof(int)),
                new columnInfo("rating", "Rating", typeof(Rating)),
                new columnInfo("genre", "Genre", typeof(Genre)),
                new columnInfo("watched", "Watched", typeof(string)),
                new columnInfo("info", "Info", typeof(string)),
            };

        }

        public Unit(int id) {
            this.id = id;
            this.name = "Name";
            this.year = 0;
            this.rating = new Rating(0);
            this.genre = new Genre();
            this.watched = false;
            this.info = "";
        }

        public Unit(
                int id,
                string name,
                int year,
                Rating rating,
                Genre genre,
                Boolean watched,
                string info) {

            this.id = id;
            this.name = name;
            this.year = year;
            this.rating = rating;
            this.genre = genre;
            this.watched = watched;
            this.info = info;
        }

        public Unit(XmlReader xrr) {
            do {
                if(xrr.IsStartElement()) {
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
                        case "Watched":
                            xrr.Read();
                            try {
                                watched = Boolean.Parse(xrr.Value.Trim());
                            } catch(Exception e) {
                                throw new System.Exception("Watched not boolean value");
                            }
                            break;
                        case "Info":
                            xrr.Read();
                            info = xrr.Value.Trim();
                            break;
                    }
                } else {
                    //End element
                    if(xrr.Name == "Unit") break;
                }
            } while(xrr.Read());
        }


        public int getId() {
            return id;
        }

        public void toXmlOutput(XmlWriter xwr) {
            xwr.WriteStartElement("Unit");  //Unit
            xwr.WriteAttributeString("name", "" + name);     //name
            xwr.WriteAttributeString("id", "" + getId());    //id

            //Year
            xwr.WriteStartElement("Year");
            xwr.WriteString("" + year);
            xwr.WriteEndElement();

            //Rating
            xwr.WriteStartElement("Rating");
            xwr.WriteString("" + rating);
            xwr.WriteEndElement();

            //Genre
            xwr.WriteStartElement("Genre");
            xwr.WriteString("" + genre);
            xwr.WriteEndElement();

            //Watched
            xwr.WriteStartElement("Watched");
            xwr.WriteString("" + watched);
            xwr.WriteEndElement();

            //Info
            xwr.WriteStartElement("Info");
            xwr.WriteString("" + info);
            xwr.WriteEndElement();

            xwr.WriteEndElement();  //Unit
        }
    }

    public struct columnInfo {
        public string attribName;
        public string displayName;
        public Type attibType;

        public columnInfo(string name, string display, Type type) {
            attribName = name;
            displayName = display;
            attibType = type;
        }
    }

    public class Rating {
        public int rating;

        public Rating(int rating) {
            this.rating = rating;
        }

        public static Boolean tryParse(string str, out Rating rating) {
            char[] chs = str.ToCharArray();
            for(int i = 0; i < str.Length; i++) {
                if(chs[i] != '+') {
                    rating = null;
                    return false;
                }
            }
            rating = new Rating(str.Length);
            return true;
        }

        public override string ToString() {
            string s = "";
            for(int i = 0; i < rating; i++) {
                s += "+";
            }
            return s;
        }
    }

    public static class RatingExtensions {
        public static string toPlus(int rating) {
            string s = "";
            for(int i = 0; i < rating; i++) {
                s += "+";
            }
            return s;
        }
    }
}
