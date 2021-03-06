﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

namespace AnimeApp {
    public static class Storage {
        public static readonly String APPDATA = //"";
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+"\\";
        public static readonly String SAVE_FOLDER = "AnimeApp";
        private static readonly String SAVE_FILE_NAME = "AnimeApp.dat";
        private static readonly String SAVE_FILE_PATH = 
            APPDATA + SAVE_FOLDER + "\\" + SAVE_FILE_NAME;
        private static int idCounter = -1;

        private static Dictionary<int, Unit> srcAnime;
        public static DataTable tabAnime;

        public static int getNewId() {
            if(idCounter == -1) {
                throw new System.Exception("ID counter is not loaded!");
            }
            idCounter++;
            return idCounter;
        }

        public static int getIdCounter() {
            return idCounter;
        }

        public static Unit getUnit(int id) {
            return srcAnime[id];
        }

        public static void createAnimeTable() {
            srcAnime = Loader.loadFrom(SAVE_FILE_PATH, out idCounter);

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

        public static int createNewUnit() {
            int id = getNewId();
            Unit u = new Unit(id);
            srcAnime.Add(id, u);
            addRow(u);
            return id;
        }

        public static void addUnit(Unit unit) {
            srcAnime.Add(unit.getId(), unit);
            addRow(unit);
        }

        public static void deleteUnit(int id) {
            srcAnime.Remove(id);
            if(id == idCounter) {
                idCounter--;
            }
        }

        public static void save() {
            Loader.saveAs(SAVE_FILE_PATH, srcAnime);
        }
    }
}
