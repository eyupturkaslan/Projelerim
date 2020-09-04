namespace paraüstü
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.on = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yirmi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yüz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ikiyüz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bir,
            this.bes,
            this.on,
            this.yirmi,
            this.elli,
            this.yüz,
            this.ikiyüz});
            this.dataGridView1.Location = new System.Drawing.Point(262, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(749, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // bir
            // 
            this.bir.HeaderText = "1";
            this.bir.Name = "bir";
            // 
            // bes
            // 
            this.bes.HeaderText = "5";
            this.bes.Name = "bes";
            // 
            // on
            // 
            this.on.HeaderText = "10";
            this.on.Name = "on";
            // 
            // yirmi
            // 
            this.yirmi.HeaderText = "20";
            this.yirmi.Name = "yirmi";
            // 
            // elli
            // 
            this.elli.HeaderText = "50";
            this.elli.Name = "elli";
            // 
            // yüz
            // 
            this.yüz.HeaderText = "100";
            this.yüz.Name = "yüz";
            // 
            // ikiyüz
            // 
            this.ikiyüz.HeaderText = "200";
            this.ikiyüz.Name = "ikiyüz";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 362);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bir;
        private System.Windows.Forms.DataGridViewTextBoxColumn bes;
        private System.Windows.Forms.DataGridViewTextBoxColumn on;
        private System.Windows.Forms.DataGridViewTextBoxColumn yirmi;
        private System.Windows.Forms.DataGridViewTextBoxColumn elli;
        private System.Windows.Forms.DataGridViewTextBoxColumn yüz;
        private System.Windows.Forms.DataGridViewTextBoxColumn ikiyüz;
    }
}

