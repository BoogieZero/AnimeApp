using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeApp {
    public partial class GenreDialog : Form {
        private List<Genre.GenreType> chosen = new List<Genre.GenreType>();

        public GenreDialog() {
            InitializeComponent();
        }

        private void GenreDialog_Load(object sender, EventArgs e) {
            lbGenres.DataSource = Genre.getAllGenreList();
            //chosen = new List<Genre.GenreType>();
        }

        private void btCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void lbGenres_DoubleClick(object sender, EventArgs e) {
            Console.WriteLine("fafsdfasdgsgsf");
            if(lbGenres.SelectedItem != null) {
                chosen.Add((Genre.GenreType)lbGenres.SelectedValue);
                lbChosen.Items.Add((Genre.GenreType)lbGenres.SelectedValue);
            }
        }

        private void btDone_Click(object sender, EventArgs e) {
            
        }
    }
}
