using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElegantOTAClient
{
    public partial class FormTes : Form
    {
        public FormTes()
        {
            InitializeComponent();
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            richTextBox1.Text += $"Changed {e.Name}\n";
        }

        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            richTextBox1.Text += $"Deleted {e.Name}\n";
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            richTextBox1.Text += $"Created {e.Name}\n";
        }
    }
}
