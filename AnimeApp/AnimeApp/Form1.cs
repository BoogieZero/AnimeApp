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
        private const float DEFAULT_OPACITY = 0.9f;
        private const Boolean ID_VISIBLE = true;
        private Boolean mouseDown = false;
        private Point lastLocation;

        public Form1() {
            InitializeComponent();

            Storage.createAnimeTable();

            Console.WriteLine("path: "+Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            dgvMain.RowsAdded += DgvMain_RowsAdded;

            dgvMain.DataSource = Storage.tabAnime;
            //id column invisible
            dgvMain.Columns["id"].Visible = ID_VISIBLE;
            //((DataGridViewCheckBoxColumn)dgvMain.Columns["Watched"]).FlatStyle = FlatStyle.Flat;
            //last column (info) fills the space
            dgvMain.Columns[dgvMain.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            lbAppName.MouseDown += new MouseEventHandler(this.tsMain_MouseDown);
            lbAppName.MouseMove += new MouseEventHandler(this.tsMain_MouseMove);
            lbAppName.MouseUp += new MouseEventHandler(this.tsMain_MouseUp);

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts
            tsMain.Renderer = new ToolStripOverride();
            this.Scale(new SizeF(1.0f, 1.7f));
            this.Opacity = DEFAULT_OPACITY;
        }

        private void DgvMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            
        }


        #region Custom replacement for no border


        public class ToolStripOverride : ToolStripProfessionalRenderer {
            public ToolStripOverride() { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }
        }

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const int _ = 10; // you can rename this variable if you like

        Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
        Rectangle Left { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }
        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }

        Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }


        protected override void WndProc(ref Message message) {
            base.WndProc(ref message);

            if(message.Msg == 0x84) // WM_NCHITTEST
            {
            var cursor = this.PointToClient(Cursor.Position);

            if(TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
            else if(TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
            else if(BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
            else if(BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

            else if(Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
            else if(Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
            else if(Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
            else if(Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }
        #endregion


        #region Allow editing button

        private void chbEditable_CheckedChanged(object sender, EventArgs e) {
            if(!chbEditable.Checked) {
                //turn off
                dgvMain.ReadOnly = true;
                btAdd.Enabled = false;
                btAdd.Visible = false;
                //dgvMain.AllowUserToAddRows = false;
                dgvMain.AllowUserToDeleteRows = false;
            } else {
                //turn on
                dgvMain.ReadOnly = false;
                btAdd.Enabled = true;
                btAdd.Visible = true;
                //dgvMain.AllowUserToAddRows = true;
                dgvMain.AllowUserToDeleteRows = true;
                dgvMain.Columns["id"].ReadOnly = true;
                //dgvMain.Columns["genre"].ReadOnly = true;

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            Close();
        }

        #region Movable Form by it's ToolStrip

        private void tsMain_MouseDown(object sender, MouseEventArgs e) {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void tsMain_MouseMove(object sender, MouseEventArgs e) {
            if(mouseDown) {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void tsMain_MouseUp(object sender, MouseEventArgs e) {
            mouseDown = false;
        }

        #endregion

        private void chbEditable_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                if(chbEditable.Checked) {
                    chbEditable.Checked = false;
                } else {
                    chbEditable.Checked = true;
                }
            }
        }

        #endregion

        #region cells

        private void dgvMain_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            if(dgvMain.Columns[e.ColumnIndex].Name == "Genre") {
                showEditGenreDialog();
                e.Cancel = true;
                dgvMain_CellEndEdit(sender, new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex));
            }
            /*
            if(e.RowIndex == dgvMain.NewRowIndex) {
                int id = Storage.createNewUnit();
                Unit src = Storage.getUnit(id);
                dgvMain.CurrentRow.Cells[0].Value = src.getId();
                dgvMain.CurrentRow.Cells[1].Value = src.name;
                dgvMain.CurrentRow.Cells[2].Value = src.year;
                dgvMain.CurrentRow.Cells[3].Value = src.rating;
                dgvMain.CurrentRow.Cells[4].Value = src.genre;
                dgvMain.CurrentRow.Cells[5].Value = src.info;
            }
            */
        }

        private void dgvMain_CellParsing(object sender, DataGridViewCellParsingEventArgs e) {
            string val = e.Value.ToString();

            DataGridViewCell cell = dgvMain[e.ColumnIndex, e.RowIndex];

            if(e.DesiredType == typeof(Rating)) {
                ((Rating)cell.Value).rating = val.Length;
                e.Value = (Rating)cell.Value;
            }
            e.ParsingApplied = true;
        }

        private void dgvMain_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            //Console.WriteLine("validating e.colIndex: " + e.ColumnIndex+" val: "+ dgvMain.CurrentCell.Value.ToString());

            switch(e.ColumnIndex) {
                case 2:                    //year
                    int i = -1;
                    if(!int.TryParse(e.FormattedValue.ToString(), out i)) {
                        e.Cancel = true;
                    }
                    break;
                case 3:                    //rating
                    Rating rat;
                    if(!Rating.tryParse((string)e.FormattedValue, out rat)) {
                        //invalid rating
                        e.Cancel = true;
                    }
                    break;
                case 4:                    //genre
                    Genre gen;
                    if(!Genre.tryParse((string)e.FormattedValue, out gen)) {
                        e.Cancel = true;
                    }
                    break;
                case 5:
                    Boolean bol;
                    if(!Boolean.TryParse((string)e.FormattedValue, out bol)) {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            DataGridViewCell cell = dgvMain.CurrentCell;

            int id = (int)dgvMain.CurrentRow.Cells[0].Value;

            Unit src = Storage.getUnit(id);

            switch(e.ColumnIndex) {
                case 1: src.name = (string)cell.Value;      break;  //name
                case 2: src.year = (int)cell.Value;         break;  //year
                case 3: src.rating = (Rating)cell.Value;    break;  //rating
                case 4: src.genre = (Genre)cell.Value;      break;  //genre
                case 5: src.watched = 
                        (Boolean)Boolean.Parse(
                            cell.Value.ToString()
                            );                              break;  //watched
                case 6: src.info = (string)cell.Value;      break;  //info
            }

        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if(dgvMain.ReadOnly == false && e.ColumnIndex == 4) {
                //showEditGenreDialog();
            }
        }

        private void dgvMain_KeyDown(object sender, KeyEventArgs e) {
            if(dgvMain.ReadOnly == false && e.KeyCode == Keys.Enter) {
                dgvMain_CellBeginEdit(sender, 
                    new DataGridViewCellCancelEventArgs(
                        dgvMain.CurrentCell.ColumnIndex, 
                        dgvMain.CurrentCell.RowIndex
                        )
                    );
                /*
                if(dgvMain.CurrentCell.ColumnIndex == 4) {
                    dgvMain.BeginEdit(false);
                    showEditGenreDialog();
                }
                */
                //dgvMain.BeginEdit(false);
                e.Handled = true;
            }
        }


        #endregion

        private void dgvMain_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {
            Storage.deleteUnit((int)e.Row.Cells[0].Value);
        }

        private void btAdd_Click(object sender, EventArgs e) {
            int id = Storage.createNewUnit();
            //Unit src = Storage.getUnit(id);
        }

        private void showEditGenreDialog() {
            GenreDialog gd = new GenreDialog(this, dgvMain.CurrentCell);
            dgvMain.Columns[dgvMain.CurrentCell.ColumnIndex].ReadOnly = false;
            Opacity = 0.60;
            //dgvMain.BeginEdit(false);
            gd.ShowDialog();
            //dgvMain_CellEndEdit(new object(), new DataGridViewCellEventArgs(dgvMain.CurrentCell.ColumnIndex, dgvMain.CurrentRow.Index));
            dgvMain.EndEdit();
            dgvMain.Columns[dgvMain.CurrentCell.ColumnIndex].ReadOnly = true;
            Opacity = DEFAULT_OPACITY;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Storage.save();
        }
    }
}
