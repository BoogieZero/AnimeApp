using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp {
    public class Genre {
        public List<GenreType> genre;

        public Genre() {
            genre = new List<GenreType>();
        }

        public Genre(List<Genre.GenreType> genres) {
            genre = genres;
        }

        public Genre(string[] str) {
            genre = new List<GenreType>();

            if(str.Length == 1 && str[0] == "") return;

            GenreType pom;
            foreach(string item in str) {
                try {
                    pom = (GenreType)Enum.Parse(typeof(GenreType), item);
                    genre.Add(pom);
                }catch(Exception) {
                    throw new System.Exception("Could not parse to Genre enum!");
                }
            }
            
        }

        public static Boolean tryParse(string str, out Genre genre) {
            genre = null;
            if(str == "") {
                genre = new Genre();
                return true;
            }
            string[] s = str.Split(' ');

            try {
                genre = new Genre(s);
            } catch(Exception) {
                genre = null;
                return false;
            }

            return true;
        }

        public override string ToString() {
            string s = "";
            for(int i = 0; i < genre.Count - 1; i++) {
                s += genre[i] + " ";
            }
            if(genre.Count == 0) return s;
            s += genre[genre.Count - 1];
            return s;
        }

        public static List<GenreType> getAllGenreList() {
            return Enum.GetValues(typeof(GenreType)).Cast<GenreType>().ToList();
        }

        public enum GenreType {
            Action,
            Adventure,
            Comedy,
            Demons,
            Detective,
            Drama,
            Ecchi,
            Romance,
            Fantasy,
            Game,
            Harem,
            Hentai,
            Hystorical,
            Horror,
            Kids,
            Magic,
            Martial_Art,
            Mecha,
            Military,
            Music,
            Mystery,
            Occult,
            Parody,
            Police,
            Post_Apocalyptic,
            Psychological,
            School,
            Sci_fi,
            Seinen,
            Shoujo,
            Shounen,
            Slice_of_life,
            Space,
            Sports,
            Superpower,
            Supernatural,
            Tragedy,
            Thriller,
            Vampire,
            Yaoi,
            Yuri
        }
    }

    
}
