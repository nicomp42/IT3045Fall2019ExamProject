namespace SQL {
    partial class frmCats {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnReadCats = new System.Windows.Forms.Button();
            this.lbCats = new System.Windows.Forms.ListBox();
            this.txtCat = new System.Windows.Forms.TextBox();
            this.btnAddCat = new System.Windows.Forms.Button();
            this.tbCat = new System.Windows.Forms.TrackBar();
            this.btnLookupBreedID = new System.Windows.Forms.Button();
            this.txtBreedID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbCat)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 275);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnCheckConnection_Click);
            // 
            // btnReadCats
            // 
            this.btnReadCats.Location = new System.Drawing.Point(157, 275);
            this.btnReadCats.Name = "btnReadCats";
            this.btnReadCats.Size = new System.Drawing.Size(75, 23);
            this.btnReadCats.TabIndex = 1;
            this.btnReadCats.Text = "Read Cats";
            this.btnReadCats.UseVisualStyleBackColor = true;
            this.btnReadCats.Click += new System.EventHandler(this.btnReadCats_Click);
            // 
            // lbCats
            // 
            this.lbCats.FormattingEnabled = true;
            this.lbCats.Location = new System.Drawing.Point(24, 12);
            this.lbCats.Name = "lbCats";
            this.lbCats.Size = new System.Drawing.Size(173, 147);
            this.lbCats.TabIndex = 2;
            // 
            // txtCat
            // 
            this.txtCat.Location = new System.Drawing.Point(322, 116);
            this.txtCat.Name = "txtCat";
            this.txtCat.Size = new System.Drawing.Size(100, 20);
            this.txtCat.TabIndex = 3;
            this.txtCat.Text = "Pink Panther";
            // 
            // btnAddCat
            // 
            this.btnAddCat.Location = new System.Drawing.Point(322, 135);
            this.btnAddCat.Name = "btnAddCat";
            this.btnAddCat.Size = new System.Drawing.Size(75, 23);
            this.btnAddCat.TabIndex = 4;
            this.btnAddCat.Text = "Add Cat";
            this.btnAddCat.UseVisualStyleBackColor = true;
            this.btnAddCat.Click += new System.EventHandler(this.btnAddCat_Click);
            // 
            // tbCat
            // 
            this.tbCat.Location = new System.Drawing.Point(318, 253);
            this.tbCat.Name = "tbCat";
            this.tbCat.Size = new System.Drawing.Size(179, 45);
            this.tbCat.TabIndex = 5;
            this.tbCat.Scroll += new System.EventHandler(this.tbCat_Scroll);
            // 
            // btnLookupBreedID
            // 
            this.btnLookupBreedID.Location = new System.Drawing.Point(322, 218);
            this.btnLookupBreedID.Name = "btnLookupBreedID";
            this.btnLookupBreedID.Size = new System.Drawing.Size(102, 23);
            this.btnLookupBreedID.TabIndex = 6;
            this.btnLookupBreedID.Text = "Lookup BreedID";
            this.btnLookupBreedID.UseVisualStyleBackColor = true;
            this.btnLookupBreedID.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBreedID
            // 
            this.txtBreedID.Location = new System.Drawing.Point(324, 197);
            this.txtBreedID.Name = "txtBreedID";
            this.txtBreedID.Size = new System.Drawing.Size(100, 20);
            this.txtBreedID.TabIndex = 7;
            // 
            // frmCats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 310);
            this.Controls.Add(this.txtBreedID);
            this.Controls.Add(this.btnLookupBreedID);
            this.Controls.Add(this.tbCat);
            this.Controls.Add(this.btnAddCat);
            this.Controls.Add(this.txtCat);
            this.Controls.Add(this.lbCats);
            this.Controls.Add(this.btnReadCats);
            this.Controls.Add(this.btnConnect);
            this.Name = "frmCats";
            this.Text = "Fun with Cats";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbCat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnReadCats;
        private System.Windows.Forms.ListBox lbCats;
        private System.Windows.Forms.TextBox txtCat;
        private System.Windows.Forms.Button btnAddCat;
        private System.Windows.Forms.TrackBar tbCat;
        private System.Windows.Forms.Button btnLookupBreedID;
        private System.Windows.Forms.TextBox txtBreedID;
    }
}

