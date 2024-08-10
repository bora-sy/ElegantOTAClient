using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElegantOTAClient
{
    public partial class FormConfig : Form
    {
        const string EOTAfileDialogFilter = "ElegantOTA files (*.eota)|*.eota|All files (*.*)|*.*";

        public FormConfig()
        {
            InitializeComponent();
        }

        bool ValidateInputs()
        {
            if (!File.Exists(textBoxFirmwarePath.Text))
            {
                MessageBox.Show("Firmware file does not exist");
                return false;
            }

            if (!IPEndPoint.TryParse(textBoxIPPort.Text, out _))
            {
                MessageBox.Show("Invalid IP Port");
                return false;
            }

            if (checkBoxDigestAuth.Checked && (textBoxUsername.Text.IsNullOrEmpty() || textBoxPassword.Text.IsNullOrEmpty()))
            {
                MessageBox.Show("Digest Auth Credentials are misssing");
                return false;
            }

            return true;
        }

        OTAConfig GetConfig()
        {
            IPEndPoint EP = IPEndPoint.Parse(textBoxIPPort.Text);

            string firmPath = textBoxFirmwarePath.Text;
            string? username = textBoxUsername.Text;
            string? password = textBoxPassword.Text;

            username = username == "" ? null : username;
            password = password == "" ? null : password;

            return new OTAConfig(EP, firmPath, username, password);
        }

        void SetConfig(OTAConfig cfg)
        {
            this.textBoxIPPort.Text = $"{cfg.EP.Address.MapToIPv4().ToString()}:{cfg.EP.Port}";
            this.textBoxFirmwarePath.Text = cfg.FirmwarePath;
            this.textBoxUsername.Text = cfg.Username;
            this.textBoxPassword.Text = cfg.Password;

            if (!textBoxUsername.Text.IsNullOrEmpty() || !textBoxPassword.Text.IsNullOrEmpty())
            {
                checkBoxDigestAuth.Checked = true;
                checkBoxDigestAuth_CheckedChanged(null!, null!);
            }
        }

        private void checkBoxDigestAuth_CheckedChanged(object sender, EventArgs e)
        {
            textBoxUsername.Enabled = checkBoxDigestAuth.Checked;
            textBoxPassword.Enabled = checkBoxDigestAuth.Checked;
        }

        private void buttonOFD_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";

            if (ofd.ShowDialog() != DialogResult.OK) return;

            textBoxFirmwarePath.Text = ofd.FileName;


        }

        private void buttonSaveConfig_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            OTAConfig config = GetConfig();

            byte[] buf = config.Serialize();


            var sfd = new SaveFileDialog();
            sfd.Filter = EOTAfileDialogFilter;

            if (sfd.ShowDialog() != DialogResult.OK) return;

            string path = sfd.FileName;

            if (!File.Exists(path)) File.Create(path).Close();

            File.WriteAllBytes(path, buf);

            MessageBox.Show($"Config Saved Successfully\n({path})");
        }

        private void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = EOTAfileDialogFilter;

            if (ofd.ShowDialog() != DialogResult.OK) return;

            string path = ofd.FileName;

            if (!File.Exists(path))
            {
                MessageBox.Show("File does not exist");
                return;
            }

            byte[] buf = File.ReadAllBytes(path);
            OTAConfig cfg = OTAConfig.Deserialize(buf);

            SetConfig(cfg);

            MessageBox.Show($"Config Loaded Successfully\n({path})");

        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            OTAConfig cfg = GetConfig();
            this.Hide();
            new FormDialog(cfg).ShowDialog();
            this.Show();
        }

    }
}
