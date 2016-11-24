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
        public Form1() {
            InitializeComponent();

            Storage.createAnimeTable();
            dgvMain.DataSource = Storage.tabAnime;
            dgvMain.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Storage.save();
        }
        
    }
}
