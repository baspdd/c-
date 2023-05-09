using PT1.Models;
using System.Text.RegularExpressions;

namespace PT1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PT11Context context = new PT11Context();
        private void button1_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            if (string.IsNullOrEmpty(code) || !Regex.Match(code, "[0-9]+").Success)
            {
                MessageBox.Show("Please enter assert type code");
                return;
            }
            string name = txtName.Text;
            if (string.IsNullOrEmpty(name) || !Regex.Match(name, "[a-zA-Z ]+").Success)
            {
                MessageBox.Show("Please enter assert type name");
                return;
            }
           
            try
            {
                AssetType assetType = new AssetType
                {
                    AssetTypeCode = code,
                    AssetTypeName = name,
                    AssetTypeGroupId = (byte)cboGr.SelectedValue,
                    IsDetail = checkBox1.Checked ? true : false
                };
                // Add vào DB
                context.AssetTypes.Add(assetType);
                if (context.SaveChanges() > 0)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("add " + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var data = context.AssetTypeGroups.ToList();
            cboGr.DataSource = data;
            cboGr.DisplayMember = "GroupName";
            cboGr.ValueMember = "AssetTypeGroupId";
        }
    }
}