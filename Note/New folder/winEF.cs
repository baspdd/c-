using Dictionary_EF.Models;
using System.Data;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Dictionary_EF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyDB2Context db = new MyDB2Context();
        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            try
            {

                var data = db.Dictionaries
                    .Select(item => new
                    {
                        WordID = item.WordId,
                        Word = item.Word,
                        Meaning = item.Meaning,
                        EditDate = item.EditDate,
                        TypeName = item.IdNavigation.TypeName,
                    })
                    .ToList();
                dataGridView1.DataSource = data;

                var data2 = db.WordTypes.ToList();
                comboBox1.DataSource = data2;
                comboBox1.DisplayMember = "TypeName";
                comboBox1.ValueMember = "ID";

                //Binding du lieu len form
                textBox1.DataBindings.Clear();
                textBox1.DataBindings.Add("Text", data, "Word");

                textBox2.DataBindings.Clear();
                textBox2.DataBindings.Add("Text", data, "Meaning");

                comboBox1.DataBindings.Clear();
                comboBox1.DataBindings.Add("Text", data, "TypeName");

            }

            catch (Exception ex)
            {

                MessageBox.Show("Load error" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Regex.Match(textBox1.Text, "[a-zA-Z ]+").Success && Regex.Match(textBox2.Text, "[a-zA-Z ]+").Success)
            {
                addNew();
            }
            else
            {
                DialogResult res = MessageBox.Show("Are you sure you want to empty", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    addNew();
                }
                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        private void addNew()
        {
            DateTime dt1 = DateTime.Now;
            try
            {
                Dictionary d = new Dictionary
                {
                    Word = textBox1.Text,
                    Meaning = textBox2.Text,
                    EditDate = dt1,
                    Id = (int)(comboBox1.SelectedValue),
                };
                db.Dictionaries.Add(d);
                if (db.SaveChanges() > 0)
                {
                    loadData();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary p = db.Dictionaries.FirstOrDefault(item => item.WordId == Int32.Parse(WordId));
            if (Regex.Match(textBox1.Text, "[a-zA-Z ]+").Success && Regex.Match(textBox2.Text, "[a-zA-Z ]+").Success && !textBox1.Text.Equals(p.Word))
            {
                update();
            }
            else
            {
                DialogResult res = MessageBox.Show("Are you sure you want to empty", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    update();
                }
                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }

        }
        private void update()
        {
            DateTime dt1 = DateTime.Now;
            try
            {
                //Tìm đối tượng cần update
                Dictionary p = db.Dictionaries.FirstOrDefault(item => item.WordId == Int32.Parse(WordId));
                if (p != null)
                {
                    p.Word = textBox1.Text;
                    p.EditDate = dt1;
                    p.Meaning = textBox2.Text;
                    p.Id = (int)(comboBox1.SelectedValue);

                    if (db.SaveChanges() > 0)
                    {
                        loadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("update error:" + ex.Message);
            }
        }

        static string WordId = "";
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary d = db.Dictionaries.FirstOrDefault(item => item.WordId == Int32.Parse(WordId));
                if (d != null)
                {
                    db.Dictionaries.Remove(d);
                    if (db.SaveChanges() > 0)
                    {
                        loadData();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var i = e.RowIndex;
            if (i >=0)
            {
                WordId = dataGridView1.Rows[i].Cells[0].FormattedValue.ToString();

            }
        }
    }
}