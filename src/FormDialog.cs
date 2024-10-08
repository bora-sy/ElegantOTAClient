﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ElegantOTAClient
{
    public partial class FormDialog : Form
    {
        private OTAConfig config;
        private FileSystemWatcher fileWatcher;

        private byte[]? LastUploadedHash = null;
        private byte[]? CurrentHash = null;

        public FormDialog(OTAConfig cfg)
        {
            InitializeComponent();

            config = cfg;

            fileWatcher = new(Path.GetDirectoryName(cfg.FirmwarePath)!);
            fileWatcher.Filter = Path.GetFileName(cfg.FirmwarePath);

            fileWatcher.Changed += FileUpdated;
            fileWatcher.Created += FileUpdated;

            CurrentHash = GetMD5Hash();

        }

        private byte[] GetMD5Hash()
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(config.FirmwarePath))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }

        private void FileUpdated(object sender, FileSystemEventArgs e)
        {
            CurrentHash = GetMD5Hash();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if(CurrentHash == LastUploadedHash && (CurrentHash != null))
            {
                if (MessageBox.Show("The current version of the file is already uploaded. Are you sure you want to upload it again?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            }

            buttonUpdate.Enabled = false;

             Task.Run(async delegate() {

                try
                {
                     this.BeginInvoke(new MethodInvoker(delegate {
                         buttonUpdate.Visible = false;
                         progressBar.Visible = true;
                         labelProgress.Visible = true;
                     }));


                    ElegantOTAHandler.SetConfig(config);

                    byte[] buf = File.ReadAllBytes(config.FirmwarePath);

                     long len = buf.Length;
                    progressBar.Maximum = (int)len;
                    progressBar.Value = 0;

                    await ElegantOTAHandler.UpdateAsync(buf, GetMD5Hash(), x => this.BeginInvoke(new MethodInvoker(delegate { progressBar.Value = (int)x; labelProgress.Text = x.ToString(); })), x => MessageBox.Show("ErrorCB: " + x));

                     this.BeginInvoke(new MethodInvoker(delegate {
                     buttonUpdate.Visible = true;
                     progressBar.Visible = false;
                     labelProgress.Visible = false;
                     buttonUpdate.Enabled = true;

                     }));

                     MessageBox.Show("UPDATE COMPT");
                }
                catch(Exception ex)
                {

                }
            });


        }
    }
}
