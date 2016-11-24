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
    public partial class Form1 : Form {
        private const Boolean ID_VISIBLE = true;

        public Form1() {
            InitializeComponent();

            Storage.createAnimeTable();
            dgvMain.DataSource = Storage.tabAnime;
            dgvMain.Columns[0].Visible = ID_VISIBLE;
            //Storage.save();
            
        }

        private void chbEditable_CheckedChanged(object sender, EventArgs e) {
            if(!chbEditable.Checked) {
                //turn off
                dgvMain.ReadOnly = true;
                dgvMain.AllowUserToAddRows = false;
                dgvMain.AllowUserToDeleteRows = false;
            } else {
                //turn on
                dgvMain.ReadOnly = false;
                dgvMain.AllowUserToAddRows = true;
                dgvMain.AllowUserToDeleteRows = true;
                dgvMain.Columns[0].ReadOnly = true;

            }
        }

        private void dgvMain_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            
        }

        private void dgvMain_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            Console.WriteLine("validating e.colIndex: " + e.ColumnIndex+" val: "+ dgvMain.CurrentCell.Value.ToString());
            
            if(e.ColumnIndex == 2) {
                //year
                int i = -1;
                if(!int.TryParse(e.FormattedValue.ToString(), out i)) {
                    e.Cancel = true;
                }
            }else if(e.ColumnIndex == 3) {
                //rating
                string s = e.FormattedValue.ToString();
                char[] chs = s.ToCharArray();
                for(int i = 0; i < s.Length; i++) {
                    if(chs[i] != '+') {
                        e.Cancel = true;
                        return;
                        Console.WriteLine("Not good");
                    }
                }
            }else if(e.ColumnIndex == 4) {
                //genre
                string[] s = e.FormattedValue.ToString().Split(' ');
                Genre.GenreType t;
                foreach(string item in s) {
                    if(!Enum.TryParse<Genre.GenreType>(item, out t)) {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            GenreDialog gd = new GenreDialog();
            gd.Owner = this;
            gd.StartPosition = FormStartPosition.CenterParent;
            gd.ShowDialog();
        }
    }
}
