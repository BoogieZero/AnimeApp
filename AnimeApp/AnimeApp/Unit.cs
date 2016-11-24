using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AnimeApp {
    public class Unit {
        public static columnInfo[] columnsInfo;
        private int id;

        public string name { get; set; }
        public int year { get; set; }
        public Rating rating { get; set; }
        public Genre genre { get; set; }
        public String info { get; set; }

        static Unit() {
            columnsInfo = new columnInfo[] {
                new columnInfo("name", "Name", typeof(string)),
                new columnInfo("year", "Year", typeof(int)),
                new columnInfo("rating", "Rating", typeof(string)),
                new columnInfo("genre", "Genre", typeof(string)),
                new columnInfo("info", "Info", typeof(string)),
            };

        }

        public Unit() {
            id = Storage.getNewId();
        }

        public Unit(
                int id,
                string name,
                int year,
                Rating rating,
                Genre genre,
                string info) {

            this.id = id;
            this.name = name;
            this.year = year;
            this.rating = rating;
            this.genre = genre;
            this.info = info;
        }


        public int getId() {
            return id;
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
