namespace P3_Mpp_Lab1
{
    partial class Admin_window
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridCautare = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownVarsta = new System.Windows.Forms.NumericUpDown();
            this.textBoxNume = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStil = new System.Windows.Forms.ComboBox();
            this.comboBoxDistanta = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCautare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVarsta)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(416, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(405, 144);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridCautare
            // 
            this.dataGridCautare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCautare.Location = new System.Drawing.Point(1, 175);
            this.dataGridCautare.Name = "dataGridCautare";
            this.dataGridCautare.Size = new System.Drawing.Size(508, 144);
            this.dataGridCautare.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cautare participanti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(570, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Varsta";
            // 
            // numericUpDownVarsta
            // 
            this.numericUpDownVarsta.Location = new System.Drawing.Point(632, 201);
            this.numericUpDownVarsta.Name = "numericUpDownVarsta";
            this.numericUpDownVarsta.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownVarsta.TabIndex = 14;
            // 
            // textBoxNume
            // 
            this.textBoxNume.Location = new System.Drawing.Point(632, 175);
            this.textBoxNume.Name = "textBoxNume";
            this.textBoxNume.Size = new System.Drawing.Size(121, 20);
            this.textBoxNume.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(571, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nume";
            // 
            // comboBoxStil
            // 
            this.comboBoxStil.FormattingEnabled = true;
            this.comboBoxStil.Location = new System.Drawing.Point(107, 77);
            this.comboBoxStil.Name = "comboBoxStil";
            this.comboBoxStil.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStil.TabIndex = 15;
            this.comboBoxStil.Text = "Stil";
            // 
            // comboBoxDistanta
            // 
            this.comboBoxDistanta.FormattingEnabled = true;
            this.comboBoxDistanta.Location = new System.Drawing.Point(107, 104);
            this.comboBoxDistanta.Name = "comboBoxDistanta";
            this.comboBoxDistanta.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDistanta.TabIndex = 16;
            this.comboBoxDistanta.Text = "Distanta";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(650, 247);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Inregistrare";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(703, 329);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Logout";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Admin_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 470);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBoxDistanta);
            this.Controls.Add(this.comboBoxStil);
            this.Controls.Add(this.numericUpDownVarsta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridCautare);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Admin_window";
            this.Text = "Admin_window";
            this.Load += new System.EventHandler(this.Admin_window_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCautare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVarsta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridCautare;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownVarsta;
        private System.Windows.Forms.TextBox textBoxNume;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxStil;
        private System.Windows.Forms.ComboBox comboBoxDistanta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}