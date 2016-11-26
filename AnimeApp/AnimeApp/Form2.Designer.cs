namespace AnimeApp {
    partial class GenreDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lbGenres = new System.Windows.Forms.ListBox();
            this.btDone = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.lbChosen = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbGenres
            // 
            this.lbGenres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbGenres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbGenres.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbGenres.FormattingEnabled = true;
            this.lbGenres.ItemHeight = 20;
            this.lbGenres.Location = new System.Drawing.Point(12, 36);
            this.lbGenres.Name = "lbGenres";
            this.lbGenres.Size = new System.Drawing.Size(185, 300);
            this.lbGenres.TabIndex = 1;
            this.lbGenres.DoubleClick += new System.EventHandler(this.lbGenres_DoubleClick);
            this.lbGenres.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbGenres_KeyDown);
            // 
            // btDone
            // 
            this.btDone.FlatAppearance.BorderSize = 0;
            this.btDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDone.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btDone.Location = new System.Drawing.Point(360, 356);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(109, 34);
            this.btDone.TabIndex = 2;
            this.btDone.Text = "Done";
            this.btDone.UseVisualStyleBackColor = false;
            this.btDone.Click += new System.EventHandler(this.btDone_Click);
            // 
            // btCancel
            // 
            this.btCancel.FlatAppearance.BorderSize = 0;
            this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btCancel.Location = new System.Drawing.Point(88, 356);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(109, 34);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbChosen
            // 
            this.lbChosen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbChosen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbChosen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbChosen.FormattingEnabled = true;
            this.lbChosen.ItemHeight = 20;
            this.lbChosen.Location = new System.Drawing.Point(284, 36);
            this.lbChosen.Name = "lbChosen";
            this.lbChosen.Size = new System.Drawing.Size(185, 300);
            this.lbChosen.TabIndex = 2;
            this.lbChosen.DoubleClick += new System.EventHandler(this.lbChosen_DoubleClick);
            this.lbChosen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbChosen_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available genres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(280, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chosen genres";
            // 
            // GenreDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(491, 405);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbChosen);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btDone);
            this.Controls.Add(this.lbGenres);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "GenreDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Genre";
            this.Load += new System.EventHandler(this.GenreDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GenreDialog_KeyDown_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGenres;
        private System.Windows.Forms.Button btDone;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ListBox lbChosen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}