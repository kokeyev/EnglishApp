using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishApp
{
    public partial class Create_row : Form
    {
        
        TableLayoutPanel main = new TableLayoutPanel();
        public Create_row()
        {
            InitializeComponent();
        }

        private void Create_row_Load(object sender, EventArgs e)
        {
            button1.Height = textBox1.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                button1.Text = Convert.ToString(n);
                
                main.AutoSize = true;
                main.Size = new Size(400, n * 40);
                main.ColumnCount = 2;
                main.RowCount = n;
                for (int i = 0; i < n; i++)
                {
                    main.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
                }
                main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                main.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                main.Location = new Point(24, 57);

                TextBox t1 = new TextBox();
                TextBox t2 = new TextBox();
                
                for (int i = 0; i < n; i++)
                {
                    main.Controls.Add(t1, 0, i);
                    main.Controls.Add(t2, 1, i);
                }

                Controls.Add(main);
                button1.Enabled = false;
                textBox1.Enabled = false;
                Button btn = new Button();
                btn.Text = "ok";
                btn.Click += btn_Click;
                btn.Location = new Point(main.Location.X + main.Size.Width - btn.Size.Width, main.Location.Y + main.Size.Height + 30);
                Controls.Add(btn);
            }
            catch { MessageBox.Show("Error"); }

        }
        private void btn_Click(object sender, EventArgs e)
        {
            List<string> l1 = new List<string>();
            List<string> l2 = new List<string>();
            int z = 0;
            foreach (Control c in main.Controls)
            {
                if (z == 0)
                {
                    l1.Add(c.Text);
                    z = 1;
                } else
                {
                    l2.Add(c.Text);
                    z = 0;
                }
            }

            
            string today = DateTime.Now.ToString("ddMMyyyy");

            var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Directory.CreateDirectory(path + @"\files\" + today);
            path += @"\files\" + today;

            try
            {
                foreach(string s in l1)
                {
                    File.AppendAllText(path + @"\a.txt", s + "\n");
                }
                foreach (string s in l2)
                {
                    File.AppendAllText(path + @"\b.txt", s + "\n");
                }
            } catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            this.Close();
        }
    }
}
