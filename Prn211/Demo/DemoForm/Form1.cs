using OOP;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DemoForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cboSub.Items.Add("Graphics");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String code = txtCode.Text;
            if (checkDup(code) != null)
            {
                MessageBox.Show(this, "Student already exist !", "Alert");
                return;
            }
            String name = txtName.Text;
            String sub = cboSub.SelectedItem.ToString();
            int mark = (int)numMark.Value;
            listStudent.Items.Add(new Student(code, name, sub, mark));
        }

        private Student checkDup(string code)
        {
            foreach (Student item in listStudent.Items)
            {
                if (item.Code.Equals(code))
                {
                    return item;
                }
            }
            return null;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Student student = (Student)listStudent.SelectedItem;
            listStudent.Items.Remove(student);

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Wanna exit", "Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCode.Text = default;
            txtName.Text = default;
            cboSub.Text = default;
            numMark.Value = default;
        }

        private void numMark_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String fileName = @"..\\..\\..\\Data.txt";
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (Student item in listStudent.Items)
                    {
                        sw.WriteLine(item);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Save file error :" + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            listStudent.Items.Clear();
            try
            {
                String fileName = @"..\\..\\..\\Data.txt";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    String s = sr.ReadLine().Trim();
                    while (s != null)
                    {
                        if (!String.IsNullOrEmpty(s))
                        {
                            String[] a = s.Split('\t');
                            if (a.Length == 4 && Regex.Match(a[3], "[0-9]+").Success && checkDup(a[0])==null)
                            {
                                String code = a[0];
                                String name = a[1];
                                String sub = a[2];
                                int mark = Convert.ToInt32(a[3]);
                                listStudent.Items.Add(new Student(code, name, sub,mark));
                            }

                        }
                        s = sr.ReadLine();
                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("load file error :" + ex.Message);
            }
        }
    }
}