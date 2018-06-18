using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDS2ToolGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExtractDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void RepackDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ExtractDragDrop(object sender, DragEventArgs e)
        {
            ExtractOrRepack(e, 0);
        }

        private void RepackDragDrop(object sender, DragEventArgs e)
        {
            ExtractOrRepack(e, 1);
        }

        public static void ExtractOrRepack(DragEventArgs e, int command)
        {
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (string filePath in fileList)
                {
                    if (command == 0 && DDS2.ValidateDDS2(filePath) == true)
                    {
                        DDS2.Extract(filePath);
                    }
                    else if (command == 1 && DDS2.ValidateFolder(filePath) == true)
                    {
                        DDS2.Repack(filePath);
                    }
                    else
                    {
                        MessageBox.Show($"{Path.GetFileName(filePath)} is not a valid DDS2 bin or folder. Could not complete operation.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://shrinefox.github.io");
        }
    }
}
