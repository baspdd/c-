using Q1.Models;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PE_PRN_Fall22B1Context context = new PE_PRN_Fall22B1Context();
        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            try
            {


                var data = context.Producers.ToList();
                comboBox2.DataSource = data;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";



                var data2 = context.Genres.ToList();
                listBox1.DataSource = data2;
                listBox1.DisplayMember = "Title";
                listBox1.ValueMember = "Id";

            }

            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Movie product = new Movie
                {
                    Title = textBox1.Text,
                    ReleaseDate = DateTime.Parse(dateTimePicker1.Text),
                    Description = richTextBox1.Text,
                    Language = textBox2.Text,
                    ProducerId = (int)comboBox2.SelectedValue,
                    Genres = list,
                };
                // Add vào DB
                context.Movies.Add(product);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("add successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("add " + ex.Message);
            }
        }
        static ICollection<Genre> list = new List<Genre>();
        
    }
}