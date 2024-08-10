namespace ElegantOTAClient
{
    partial class FormConfig
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
            textBoxIPPort = new TextBox();
            label1 = new Label();
            checkBoxDigestAuth = new CheckBox();
            groupBox1 = new GroupBox();
            label2 = new Label();
            textBoxUsername = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            textBoxFirmwarePath = new TextBox();
            buttonOFD = new Button();
            label3 = new Label();
            textBoxPassword = new TextBox();
            buttonLoadConfig = new Button();
            buttonSaveConfig = new Button();
            buttonLaunch = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxIPPort
            // 
            textBoxIPPort.Location = new Point(162, 49);
            textBoxIPPort.Name = "textBoxIPPort";
            textBoxIPPort.PlaceholderText = "1.1.1.1:1234";
            textBoxIPPort.Size = new Size(243, 31);
            textBoxIPPort.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 52);
            label1.Name = "label1";
            label1.Size = new Size(68, 25);
            label1.TabIndex = 1;
            label1.Text = "IP Port:";
            // 
            // checkBoxDigestAuth
            // 
            checkBoxDigestAuth.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            checkBoxDigestAuth.AutoSize = true;
            checkBoxDigestAuth.Location = new Point(75, 32);
            checkBoxDigestAuth.Name = "checkBoxDigestAuth";
            checkBoxDigestAuth.Size = new Size(243, 29);
            checkBoxDigestAuth.TabIndex = 2;
            checkBoxDigestAuth.Text = "Use Digest Authentication";
            checkBoxDigestAuth.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxPassword);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(checkBoxDigestAuth);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBoxUsername);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 86);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(393, 257);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label2.Location = new Point(6, 84);
            label2.Name = "label2";
            label2.Size = new Size(381, 38);
            label2.TabIndex = 4;
            label2.Text = "Username";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxUsername.Location = new Point(29, 125);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(335, 31);
            textBoxUsername.TabIndex = 5;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label4.Location = new Point(6, 170);
            label4.Name = "label4";
            label4.Size = new Size(381, 38);
            label4.TabIndex = 7;
            label4.Text = "Password";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(29, 211);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(76, 31);
            textBox3.TabIndex = 8;
            // 
            // textBoxFirmwarePath
            // 
            textBoxFirmwarePath.Location = new Point(145, 12);
            textBoxFirmwarePath.Name = "textBoxFirmwarePath";
            textBoxFirmwarePath.Size = new Size(569, 31);
            textBoxFirmwarePath.TabIndex = 4;
            // 
            // buttonOFD
            // 
            buttonOFD.Location = new Point(720, 9);
            buttonOFD.Name = "buttonOFD";
            buttonOFD.Size = new Size(68, 34);
            buttonOFD.TabIndex = 5;
            buttonOFD.Text = "...";
            buttonOFD.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 15);
            label3.Name = "label3";
            label3.Size = new Size(127, 25);
            label3.TabIndex = 6;
            label3.Text = "Firmware Path:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPassword.Location = new Point(29, 211);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(335, 31);
            textBoxPassword.TabIndex = 9;
            // 
            // buttonLoadConfig
            // 
            buttonLoadConfig.Location = new Point(411, 49);
            buttonLoadConfig.Name = "buttonLoadConfig";
            buttonLoadConfig.Size = new Size(377, 60);
            buttonLoadConfig.TabIndex = 7;
            buttonLoadConfig.Text = "Load Config";
            buttonLoadConfig.UseVisualStyleBackColor = true;
            // 
            // buttonSaveConfig
            // 
            buttonSaveConfig.Location = new Point(411, 115);
            buttonSaveConfig.Name = "buttonSaveConfig";
            buttonSaveConfig.Size = new Size(377, 60);
            buttonSaveConfig.TabIndex = 8;
            buttonSaveConfig.Text = "Save Config";
            buttonSaveConfig.UseVisualStyleBackColor = true;
            // 
            // buttonLaunch
            // 
            buttonLaunch.Location = new Point(411, 181);
            buttonLaunch.Name = "buttonLaunch";
            buttonLaunch.Size = new Size(377, 162);
            buttonLaunch.TabIndex = 9;
            buttonLaunch.Text = "Launch";
            buttonLaunch.UseVisualStyleBackColor = true;
            // 
            // FormConfig
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 361);
            Controls.Add(buttonLaunch);
            Controls.Add(buttonSaveConfig);
            Controls.Add(buttonLoadConfig);
            Controls.Add(label3);
            Controls.Add(buttonOFD);
            Controls.Add(textBoxFirmwarePath);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(textBoxIPPort);
            Name = "FormConfig";
            Text = "FormConfig";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxIPPort;
        private Label label1;
        private CheckBox checkBoxDigestAuth;
        private GroupBox groupBox1;
        private Label label4;
        private TextBox textBoxUsername;
        private Label label2;
        private TextBox textBox3;
        private TextBox textBoxFirmwarePath;
        private Button buttonOFD;
        private Label label3;
        private TextBox textBoxPassword;
        private Button buttonLoadConfig;
        private Button buttonSaveConfig;
        private Button buttonLaunch;
    }
}