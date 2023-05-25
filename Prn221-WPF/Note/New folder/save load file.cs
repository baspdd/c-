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
