using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Dictionary_Ado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataProvider data = new DataProvider();
        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            IDataReader dr = data.executeQuery2("Select * from Dictionary");
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("WordID"), new DataColumn("Word"), new DataColumn("Meaning"), new DataColumn("EditDate"), new DataColumn("TypeName") });

            while (dr.Read())
            {
                dt.Rows.Add(dr.GetInt32(0), dr.GetString(1), dr.GetString(3), dr.GetDateTime(2), dr.GetInt32(4));


            }
            dr.Close();
            foreach (DataRow a in dt.Rows)
            {
                a["TypeName"] = getTypeName(Int32.Parse((a["TypeName"].ToString())));
            }

            dataGridView1.DataSource = dt;
            var data2 = data.executeQuery("Select * from WordType");
            comboBox1.DataSource = data2;
            comboBox1.DisplayMember = "TypeName";
            comboBox1.ValueMember = "ID";
            dr.Close();
        }
        private string getTypeName(int id)
        {
            string typename = "";
            try
            {
                string strSelect = "select * from WordType " +
                    "where ID='" + id + "'";
                DataTable de = data.executeQuery(strSelect);
                if (de.Rows.Count > 0)
                {
                    typename = de.Rows[0].ItemArray[1].ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return typename;
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
            try
            {
                DateTime dt1 = DateTime.Now;
                string strAdd = "insert into Dictionary(Word,Meaning,ID,EditDate) values(@word,@meaning,@type,@datetime)";
                List<SqlParameter> param = new List<SqlParameter>
                {
                    new SqlParameter("@word",textBox1.Text),
                    new SqlParameter("@meaning",textBox2.Text),
                    new SqlParameter("@type",comboBox1.SelectedValue),
                    new SqlParameter("@datetime",dt1),
                };
                if (data.executeNonQuery2(strAdd, param.ToArray()))
                {
                    MessageBox.Show("Add success");
                    loadData();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Add error");
            }
        }

        static string WordId = "";
        private void button2_Click(object sender, EventArgs e)
        {
            if (Regex.Match(textBox1.Text, "[a-zA-Z ]+").Success && Regex.Match(textBox2.Text, "[a-zA-Z ]+").Success)
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
            try
            {
                DateTime dt1 = DateTime.Now;
                string strAdd = "update Dictionary set Word = @word , Meaning = @meaning, ID = @type ,EditDate = @datetime " +
                    " where WordID = @wordid";
                List<SqlParameter> param = new List<SqlParameter>
                {
                    new SqlParameter("@word",textBox1.Text),
                    new SqlParameter("@meaning",textBox2.Text),
                    new SqlParameter("@type",comboBox1.SelectedValue),
                    new SqlParameter("@datetime",dt1),
                    new SqlParameter("@wordid",WordId),

                };
                if (data.executeNonQuery2(strAdd, param.ToArray()))
                {
                    loadData();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Add error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string strDelete = "delete from Dictionary where WordID = @id";
                List<SqlParameter> param = new List<SqlParameter>
                {
                    new SqlParameter("@id",WordId),
                };
                if (data.executeNonQuery2(strDelete, param.ToArray()))
                {
                    loadData();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Delete error");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var i = e.RowIndex;
            if (i >= 0)
            {
                textBox1.Text = dataGridView1.Rows[i].Cells[1].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[2].FormattedValue.ToString();
                comboBox1.Text = dataGridView1.Rows[i].Cells[4].FormattedValue.ToString();
                WordId = dataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
            }
            
        }
    }
}