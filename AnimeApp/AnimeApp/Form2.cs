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

        private BindingList<Genre.GenreType> chosen = new BindingList<Genre.GenreType>();
        private DataGridViewCell cell;

        public GenreDialog(Form owner, DataGridViewCell cell) {
            this.cell = cell;
            Owner = owner;
            StartPosition = FormStartPosition.CenterParent;
            Opacity = 0.9;
            InitializeComponent();
        }

        private void GenreDialog_Load(object sender, EventArgs e) {
            lbGenres.DataSource = Genre.getAllGenreList();
            //create separate list for not influencing original
            chosen = new BindingList<Genre.GenreType>(
                new List<Genre.GenreType>(
                    ((Genre)cell.Value).genre
                    )
                );
            lbChosen.DataSource = chosen;
        }

        private void btCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void addToChosen() {
            if(lbGenres.SelectedItem != null) {
                chosen.Add((Genre.GenreType)lbGenres.SelectedValue);
            }
        }

        private void removeFromChosen() {
            if(lbChosen.SelectedItem != null) {
                chosen.RemoveAt(lbChosen.SelectedIndex);
            }
        }

        private void lbGenres_DoubleClick(object sender, EventArgs e) {
            addToChosen();
        }

        private void btDone_Click(object sender, EventArgs e) {
            if(chosen.Count == 0) {
                Close();
            }else {
                cell.Value = new Genre(chosen.ToList());
                Close();
            }
        }

        private void lbChosen_DoubleClick(object sender, EventArgs e) {
            removeFromChosen();
        }

        private void GenreDialog_KeyDown(object sender, KeyEventArgs e) {
            Console.WriteLine("asd");
        }

        private void lbGenres_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Right) {
                addToChosen();
                return;
            }
        }

        private void lbChosen_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Left) {
                removeFromChosen();
                return;
            }
        }

        private void GenreDialog_KeyDown_1(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {   btDone.PerformClick();      return; }
            if(e.KeyCode == Keys.Escape) {  btCancel.PerformClick();    return; }
        }
    }
}
