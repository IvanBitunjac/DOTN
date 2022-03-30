
namespace Predavanje6___EF
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.cb_drzava = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ozdravljeni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_umrli = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_zarazeni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gv_slucajevi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gv_slucajevi)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 30);
            this.button1.TabIndex = 17;
            this.button1.Text = "Spremi u bazu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_drzava
            // 
            this.cb_drzava.FormattingEnabled = true;
            this.cb_drzava.Location = new System.Drawing.Point(178, 202);
            this.cb_drzava.Name = "cb_drzava";
            this.cb_drzava.Size = new System.Drawing.Size(228, 24);
            this.cb_drzava.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Država:";
            // 
            // tb_ozdravljeni
            // 
            this.tb_ozdravljeni.Location = new System.Drawing.Point(178, 144);
            this.tb_ozdravljeni.Name = "tb_ozdravljeni";
            this.tb_ozdravljeni.Size = new System.Drawing.Size(228, 22);
            this.tb_ozdravljeni.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Broj ozdravljenih:";
            // 
            // tb_umrli
            // 
            this.tb_umrli.Location = new System.Drawing.Point(178, 85);
            this.tb_umrli.Name = "tb_umrli";
            this.tb_umrli.Size = new System.Drawing.Size(228, 22);
            this.tb_umrli.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Broj preminulih:";
            // 
            // tb_zarazeni
            // 
            this.tb_zarazeni.Location = new System.Drawing.Point(178, 35);
            this.tb_zarazeni.Name = "tb_zarazeni";
            this.tb_zarazeni.Size = new System.Drawing.Size(228, 22);
            this.tb_zarazeni.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Broj zaraženih:";
            // 
            // gv_slucajevi
            // 
            this.gv_slucajevi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_slucajevi.Location = new System.Drawing.Point(425, 12);
            this.gv_slucajevi.Name = "gv_slucajevi";
            this.gv_slucajevi.RowHeadersWidth = 51;
            this.gv_slucajevi.RowTemplate.Height = 24;
            this.gv_slucajevi.Size = new System.Drawing.Size(734, 460);
            this.gv_slucajevi.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 497);
            this.Controls.Add(this.gv_slucajevi);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_drzava);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_ozdravljeni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_umrli);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_zarazeni);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_slucajevi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_drzava;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_ozdravljeni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_umrli;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_zarazeni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gv_slucajevi;
    }
}

