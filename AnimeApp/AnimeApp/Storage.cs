using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

namespace AnimeApp {
    public static class Storage {
        private static readonly String SAVE_FILE = "test";
        private static int idCounter = 1;

        private static Dictionary<int, Unit> srcAnime;
        public static DataTable tabAnime;

        public static int getNewId() {
            if(idCounter == -1) {
                throw new System.Exception("ID counter is not loaded!");
            }
            return idCounter++;
        }

        public static int getIdCounter() {
            return idCounter;
        }

        public static Unit getUnit(int id) {
            return srcAnime[id];
        }

        public static void createAnimeTable() {
            srcAnime = Loader.loadFrom(SAVE_FILE);

            tabAnime = new DataTable("Anime");
            //tab columns
            foreach(columnInfo item in Unit.columnsInfo) {
                tabAnime.Columns.Add(item.displayName, item.attibType);
            }

            //tab rows
            foreach(KeyValuePair<int, Unit> item in srcAnime) {
                addRow(item.Value);
            }
            
        }

        private static void addRow(Unit unit) {
            var properties = typeof(Unit).GetProperties(
                BindingFlags.NonPublic | 
                BindingFlags.Public |
                BindingFlags.Instance);

            object[] values = new object[properties.Length];

            for(int i = 0; i < properties.Length; i++) {
                values[i] = properties[i].GetValue(unit);
            }
            tabAnime.Rows.Add(values);
        }

        public static void addUnit(Unit unit) {
            srcAnime.Add(unit.getId(), unit);
            addRow(unit);
        }

        public static void save() {
            Loader.saveAs(SAVE_FILE+" save", srcAnime);
        }
    }
}
