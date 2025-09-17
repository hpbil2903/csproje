namespace gun1_25._08
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtsinifadi = new TextBox();
            numsinifmevcud = new NumericUpDown();
            label1 = new Label();
            btnsinifekle = new Button();
            label2 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numsinifmevcud).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtsinifadi
            // 
            txtsinifadi.Location = new Point(12, 59);
            txtsinifadi.Name = "txtsinifadi";
            txtsinifadi.PlaceholderText = "Sınıf İsmi";
            txtsinifadi.Size = new Size(148, 27);
            txtsinifadi.TabIndex = 0;
            // 
            // numsinifmevcud
            // 
            numsinifmevcud.Location = new Point(12, 112);
            numsinifmevcud.Name = "numsinifmevcud";
            numsinifmevcud.Size = new Size(148, 27);
            numsinifmevcud.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 89);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 2;
            label1.Text = "Sınıf Mevcudu";
            // 
            // btnsinifekle
            // 
            btnsinifekle.BackColor = Color.Red;
            btnsinifekle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnsinifekle.ForeColor = SystemColors.ButtonHighlight;
            btnsinifekle.Location = new Point(12, 145);
            btnsinifekle.Name = "btnsinifekle";
            btnsinifekle.Size = new Size(102, 59);
            btnsinifekle.TabIndex = 3;
            btnsinifekle.Text = "Sınıf Bilgileri";
            btnsinifekle.UseVisualStyleBackColor = false;
            btnsinifekle.Click += btnsinifekle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 36);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 5;
            label2.Text = "Sınıf İsmi";
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Location = new Point(166, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(887, 472);
            panel1.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(0, 0);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(12, 233);
            button1.Name = "button1";
            button1.Size = new Size(102, 61);
            button1.TabIndex = 7;
            button1.Text = "Sınıfı Onaylayın";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 329);
            button2.Name = "button2";
            button2.Size = new Size(102, 56);
            button2.TabIndex = 8;
            button2.Text = "Eklenmiş Sınıflar ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1065, 526);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(btnsinifekle);
            Controls.Add(label1);
            Controls.Add(numsinifmevcud);
            Controls.Add(txtsinifadi);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numsinifmevcud).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtsinifadi;
        private NumericUpDown numsinifmevcud;
        private Label label1;
        private Button btnsinifekle;
        private Label label2;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Button button2;
    }
}
