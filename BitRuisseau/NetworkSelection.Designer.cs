namespace BitRuisseau
{
    partial class NetworkSelection
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
            HostTextBox = new TextBox();
            hostLabel = new Label();
            UsernameLabel = new Label();
            UsernameTextBox = new TextBox();
            label1 = new Label();
            PasswordTextBox = new TextBox();
            button1 = new Button();
            label2 = new Label();
            PortValue = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)PortValue).BeginInit();
            SuspendLayout();
            // 
            // HostTextBox
            // 
            HostTextBox.Location = new Point(211, 58);
            HostTextBox.Name = "HostTextBox";
            HostTextBox.Size = new Size(217, 23);
            HostTextBox.TabIndex = 0;
            HostTextBox.Text = "mqtt.blue.section-inf.ch";
            // 
            // hostLabel
            // 
            hostLabel.AutoSize = true;
            hostLabel.Location = new Point(156, 61);
            hostLabel.Name = "hostLabel";
            hostLabel.Size = new Size(32, 15);
            hostLabel.TabIndex = 1;
            hostLabel.Text = "Host";
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(128, 124);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(60, 15);
            UsernameLabel.TabIndex = 3;
            UsernameLabel.Text = "Username";
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(211, 121);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(217, 23);
            UsernameTextBox.TabIndex = 2;
            UsernameTextBox.Text = "ict";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 184);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 5;
            label1.Text = "Password";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(211, 181);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(217, 23);
            PasswordTextBox.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(211, 232);
            button1.Name = "button1";
            button1.Size = new Size(217, 47);
            button1.TabIndex = 6;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ConnectionButton;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(451, 61);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 8;
            label2.Text = "port";
            // 
            // PortValue
            // 
            PortValue.Location = new Point(497, 59);
            PortValue.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            PortValue.Name = "PortValue";
            PortValue.Size = new Size(72, 23);
            PortValue.TabIndex = 9;
            PortValue.Value = new decimal(new int[] { 1883, 0, 0, 0 });
            // 
            // NetworkSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 330);
            Controls.Add(PortValue);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameLabel);
            Controls.Add(UsernameTextBox);
            Controls.Add(hostLabel);
            Controls.Add(HostTextBox);
            Name = "NetworkSelection";
            Text = "NetworkSelection";
            ((System.ComponentModel.ISupportInitialize)PortValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox HostTextBox;
        private Label hostLabel;
        private Label UsernameLabel;
        private TextBox UsernameTextBox;
        private Label label1;
        private TextBox PasswordTextBox;
        private Button button1;
        private Label label2;
        private NumericUpDown PortValue;
    }
}