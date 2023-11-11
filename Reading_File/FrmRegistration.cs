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
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string getStudentNo = txtStudentNo.Text;
            string getFirstName = txtFirstName.Text;
            string getMiddleName = txtMiddleInitial.Text;
            string getLastName = txtLastName.Text;
            string getAge = txtAge.Text;
            string getBirthday = datePickerBirtday.Value.ToString("yyyy-MM-dd");
            string getProgram = cbPrograms.Text;
            string getGender = cbGender.Text;
            string getContact = txtContactNo.Text;

            if (string.IsNullOrEmpty(getStudentNo) || string.IsNullOrEmpty(getFirstName) || string.IsNullOrEmpty(getLastName) || 
                string.IsNullOrEmpty(getAge) || string.IsNullOrEmpty(getContact))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a gender");
            }
            else if (cbPrograms.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a program");
            }
            else
            {
                string setFileName = String.Concat(getStudentNo, ".txt");
                string docPath2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath2, setFileName)))
                    {
                        string[] info = {"Student No: " + getStudentNo,
                             "FullName: " + getLastName + ", " + getFirstName + ", " + getMiddleName,
                             "Program: " + getProgram,
                             "Gender: " + getGender,
                             "Age: " + getAge,
                             "Birthday: " + getBirthday,
                             "Contact No: " + getContact};

                        Console.WriteLine(getStudentNo);
                        foreach (string i in info)
                        {
                            outputFile.WriteLine(i);
                        }
                    }
                    MessageBox.Show("Successfully saved!!!");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            FrmStudentRecord records = new FrmStudentRecord(this);
            records.Show();
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[] { "BS Information Technology",
                                                    "BS Computer Science",
                                                    "BS Information Systems",
                                                    "BS in Accountancy",
                                                    "BS in Hospitality Management",
                                                    "BS in Tourism Management" };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }

            string[] listGender = new string[] { "Male", "Female" };

            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(listGender[i].ToString());
            }
        }
    }
}
