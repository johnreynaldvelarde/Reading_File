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
    public partial class FrmStudentRecord : Form
    {
        public FrmStudentRecord()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmRegistration regi = new FrmRegistration();
            regi.ShowDialog();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = openFileDialog1.FileName;
                    lvShowText.Items.Clear();

                    using (StreamReader streamReader = File.OpenText(path))
                    {
                        string file;
                        while ((file = streamReader.ReadLine()) != null)
                        {
                            lvShowText.Items.Add(file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (lvShowText.Items.Count > 0)
            {
                MessageBox.Show("Successfully Uploaded!", "Upload Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lvShowText.Items.Clear();
            }
            else
            {
                MessageBox.Show("No items to upload.", "Upload Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
