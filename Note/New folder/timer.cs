private void timer1_Tick(object sender, EventArgs e)
        {

            //if (progressBar1.Value < 90)
            //{
            //    progressBar1.Value += 10;

            //}
            //else
            //{
            //    timer1.Enabled = false;
            //    frmMain f = new frmMain();
            //    f.Show();
            //    this.Hide();

            //}
            progressBar1.Increment(10);
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Enabled = false;
                frmMain f = new frmMain();
                this.Hide();
                f.Show();

            }
        }

 pictureBox1.Image = Image.FromFile(@"..\\..\\..\\pic\\ba.png");
//get image web
 string img = dgCustomer.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            WebRequest request = WebRequest.Create(img);
            using (var response = request.GetResponse())
            {
                using (var str = response.GetResponseStream())
                {
                    pic.Image = Bitmap.FromStream(str);
                }
            }