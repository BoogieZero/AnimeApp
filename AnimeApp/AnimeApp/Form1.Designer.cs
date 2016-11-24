namespace AnimeApp {
    partial class Form1 {
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
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.chbEditable = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMain.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(140, -1);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowTemplate.Height = 28;
            this.dgvMain.Size = new System.Drawing.Size(1074, 378);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMain_CellBeginEdit);
            this.dgvMain.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvMain_CellValidating);
            // 
            // chbEditable
            // 
            this.chbEditable.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbEditable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chbEditable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbEditable.Location = new System.Drawing.Point(12, 12);
            this.chbEditable.Name = "chbEditable";
            this.chbEditable.Size = new System.Drawing.Size(122, 39);
            this.chbEditable.TabIndex = 2;
            this.chbEditable.Text = "Add / Edit";
            this.chbEditable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbEditable.UseVisualStyleBackColor = true;
            this.chbEditable.CheckedChanged += new System.EventHandler(this.chbEditable_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 516);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chbEditable);
            this.Controls.Add(this.dgvMain);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.CheckBox chbEditable;
        private System.Windows.Forms.Button button1;
    }
}

