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
            this.SuspendLayout();
            // 
            // lbGenres
            // 
            this.lbGenres.FormattingEnabled = true;
            this.lbGenres.ItemHeight = 20;
            this.lbGenres.Location = new System.Drawing.Point(12, 12);
            this.lbGenres.Name = "lbGenres";
            this.lbGenres.Size = new System.Drawing.Size(185, 344);
            this.lbGenres.TabIndex = 1;
            this.lbGenres.DoubleClick += new System.EventHandler(this.lbGenres_DoubleClick);
            // 
            // btDone
            // 
            this.btDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDone.Location = new System.Drawing.Point(349, 373);
            this.btDone.Name = "btDone";
            this.btDone.Size = new System.Drawing.Size(109, 34);
            this.btDone.TabIndex = 2;
            this.btDone.Text = "Done";
            this.btDone.UseVisualStyleBackColor = true;
            this.btDone.Click += new System.EventHandler(this.btDone_Click);
            // 
            // btCancel
            // 
            this.btCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.Location = new System.Drawing.Point(12, 373);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(109, 34);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbChosen
            // 
            this.lbChosen.FormattingEnabled = true;
            this.lbChosen.ItemHeight = 20;
            this.lbChosen.Location = new System.Drawing.Point(273, 12);
            this.lbChosen.Name = "lbChosen";
            this.lbChosen.Size = new System.Drawing.Size(185, 344);
            this.lbChosen.TabIndex = 4;
            // 
            // GenreDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 419);
            this.ControlBox = false;
            this.Controls.Add(this.lbChosen);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btDone);
            this.Controls.Add(this.lbGenres);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GenreDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.GenreDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbGenres;
        private System.Windows.Forms.Button btDone;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ListBox lbChosen;
    }
}