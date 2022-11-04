using System.Collections.Generic;
using System.Windows.Forms;

namespace winEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n;
        List<TextBox> list = new List<TextBox>();

        private void btnSub_Click(object sender, EventArgs e)
        {
             n = (int) numericUpDown1.Value;
            for (int i = 0; i < n; i++)
            {
                Label label = new Label();
                label.Text = "Text" + (i + 1) + ":";
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(49, 153 + i * 50);
                label.Size = new System.Drawing.Size(38, 15);

                TextBox textBox = new TextBox();
                textBox.Location = new System.Drawing.Point(110, 150 + i * 50);
                textBox.Name = "textBox" + i;
                textBox.Size = new System.Drawing.Size(126, 23);
                list.Add(textBox);

                this.Controls.Add(label);
                this.Controls.Add(textBox);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                CheckBox check = new CheckBox();
                check.AutoSize = true;
                check.Location = new System.Drawing.Point(376, 155 + i * 50);
                check.Name = "checkBox" + i;
                check.Size = new System.Drawing.Size(83, 19);
                check.Text = list[i].Text;
                check.UseVisualStyleBackColor = true;
                check.CheckedChanged += CheckBox_CheckedChange;
                this.Controls.Add(check);

                Button btn = new Button();
                btn.Location = new System.Drawing.Point(500, 155 + i * 50);
                btn.Name = "button"+i;
                btn.Size = new System.Drawing.Size(75, 23);
                btn.Text = "button"+i;
                btn.UseVisualStyleBackColor = true;
                btn.Click += new System.EventHandler(btn_Click);
                this.Controls.Add(btn);
            }
        }
        private void btn_Click(object? sender, EventArgs e)
        {
          Button btn = sender as Button;
            int index = Int32.Parse(btn.Name.Substring(btn.Name.Length - 1));
            var c = GetAll(this, typeof(TextBox));
            foreach (var item in c)
            {
                if (item.Name.Equals("checkBox"+index))
                {
                    item.Text = item.Text + "ngu";
                }
            }
            MessageBox.Show("Total Controls: " + index);
           
        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }
        public List<CheckBox> Getch(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            List<CheckBox> result = new List<CheckBox>();
            foreach (var item in controls)
            {
                if (item.GetType()==type)
                {
                }
            }
            return result;
        }

        private void CheckBox_CheckedChange(object? sender, EventArgs e)
        {
            CheckBox check = sender as CheckBox;
            string checkbox = "uncheck";
            if (check.Checked==true)
            {
                checkbox = "checked";
            }
            MessageBox.Show(checkbox + "Sadsa"+ check.Text);
        }



    }
}