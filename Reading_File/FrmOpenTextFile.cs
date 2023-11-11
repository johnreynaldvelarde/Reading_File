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

namespace Reading_File
{
    public partial class FrmOpenTextFile : Form
    {
        public FrmOpenTextFile()
        {
            InitializeComponent();
        }

        public void DisplayToList()
        {
            try
            {
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Browse Text Files";
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog1.FileName;

                    lvShowText.Items.Clear();

                    using (StreamReader streamReader = File.OpenText(path))
                    {
                        string file;
                        while ((file = streamReader.ReadLine()) != null)
                        {
                            Console.WriteLine(file);
                            lvShowText.Items.Add(file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DisplayToList();
        }
    }
}
