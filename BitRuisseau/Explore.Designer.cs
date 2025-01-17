﻿namespace BitRuisseau
{
    partial class Explore
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
            Panel = new Panel();
            ExitButton = new Button();
            ChooseNetworkButton = new Button();
            ExploreButton = new Button();
            MyDocumentsButton = new Button();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            searchBar = new TextBox();
            panel3 = new Panel();
            DataGridMedia = new DataGridView();
            Panel.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridMedia).BeginInit();
            SuspendLayout();
            // 
            // Panel
            // 
            Panel.AutoSize = true;
            Panel.BackColor = SystemColors.ActiveCaptionText;
            Panel.Controls.Add(ExitButton);
            Panel.Controls.Add(ChooseNetworkButton);
            Panel.Controls.Add(ExploreButton);
            Panel.Controls.Add(MyDocumentsButton);
            Panel.Dock = DockStyle.Left;
            Panel.Location = new Point(0, 0);
            Panel.Name = "Panel";
            Panel.Size = new Size(141, 443);
            Panel.TabIndex = 1;
            // 
            // ExitButton
            // 
            ExitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ExitButton.BackColor = Color.Silver;
            ExitButton.Location = new Point(9, 438);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(129, 40);
            ExitButton.TabIndex = 3;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // ChooseNetworkButton
            // 
            ChooseNetworkButton.Anchor = AnchorStyles.Left;
            ChooseNetworkButton.BackColor = Color.FromArgb(192, 255, 255);
            ChooseNetworkButton.Location = new Point(9, 313);
            ChooseNetworkButton.Name = "ChooseNetworkButton";
            ChooseNetworkButton.Size = new Size(129, 71);
            ChooseNetworkButton.TabIndex = 2;
            ChooseNetworkButton.Text = "Choose Network";
            ChooseNetworkButton.UseVisualStyleBackColor = false;
            // 
            // ExploreButton
            // 
            ExploreButton.Anchor = AnchorStyles.Left;
            ExploreButton.BackColor = Color.FromArgb(192, 255, 255);
            ExploreButton.Location = new Point(9, 217);
            ExploreButton.Name = "ExploreButton";
            ExploreButton.Size = new Size(129, 71);
            ExploreButton.TabIndex = 1;
            ExploreButton.Text = "Explore";
            ExploreButton.UseVisualStyleBackColor = false;
            ExploreButton.Click += ExploreButton_Click;
            // 
            // MyDocumentsButton
            // 
            MyDocumentsButton.Anchor = AnchorStyles.Left;
            MyDocumentsButton.BackColor = Color.FromArgb(192, 255, 255);
            MyDocumentsButton.Location = new Point(9, 128);
            MyDocumentsButton.Name = "MyDocumentsButton";
            MyDocumentsButton.Size = new Size(129, 71);
            MyDocumentsButton.TabIndex = 0;
            MyDocumentsButton.Text = "My Documents";
            MyDocumentsButton.UseVisualStyleBackColor = false;
            MyDocumentsButton.Click += MyDocumentsButton_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(141, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(576, 443);
            panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.Size = new Size(556, 423);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoSize = true;
            panel1.Controls.Add(searchBar);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 99);
            panel1.TabIndex = 0;
            // 
            // searchBar
            // 
            searchBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            searchBar.Location = new Point(17, 46);
            searchBar.Name = "searchBar";
            searchBar.Size = new Size(239, 23);
            searchBar.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(DataGridMedia);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 108);
            panel3.Name = "panel3";
            panel3.Size = new Size(550, 312);
            panel3.TabIndex = 1;
            // 
            // DataGridMedia
            // 
            DataGridMedia.AllowUserToOrderColumns = true;
            DataGridMedia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridMedia.Dock = DockStyle.Fill;
            DataGridMedia.Location = new Point(0, 0);
            DataGridMedia.Name = "DataGridMedia";
            DataGridMedia.Size = new Size(550, 312);
            DataGridMedia.TabIndex = 0;
            DataGridMedia.CellContentClick += DataGridMedia_CellContentClick_1;
            // 
            // Explore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 443);
            Controls.Add(panel2);
            Controls.Add(Panel);
            Name = "Explore";
            Text = "BitRuisseau";
            Panel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataGridMedia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel Panel;
        private Button MyDocumentsButton;
        private Button ChooseNetworkButton;
        private Button ExploreButton;
        private Button ExitButton;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private TextBox searchBar;
        private Panel panel3;
        private DataGridView DataGridMedia;
    }
}