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
    public partial class TestForm : Form
    {
        TableLayoutPanel t = new TableLayoutPanel();
        int r = 0, c = 0;
        string s;
        public TestForm(int r1, int c1, string s1)
        {
            InitializeComponent();
            r = r1;
            c = c1;
            s = s1;
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            
            s = Func(s);
            var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            path += @"\files\" + s;
            string[] s1 = File.ReadAllLines(path + @"\a.txt");
            string[] s2 = File.ReadAllLines(path + @"\b.txt");

            int n = s1.Length;
            t.ColumnCount = 2;
            //t.Size = new Size(440, n * 30);
            t.AutoSize = true;
            t.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            t.Padding = new Padding(30);
            t.RowCount = n;
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            t.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            t.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            for (int i = 0; i < n; i++)
            {
                Label l1 = new Label();
                l1.Text = s1[i];
                TextBox txt1 = new TextBox();

                t.Controls.Add(l1, 0, i);
                t.Controls.Add(txt1, 1, i);
            }
            
            Controls.Add(t);
            Button btn = new Button();
            btn.Text = "ok";
            btn.Click += btn_Click;
            btn.Location = new Point(t.Location.X + t.Size.Width - btn.Size.Width, t.Location.Y + t.Size.Height + 10);
            Controls.Add(btn);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
        }

        private void TestForm_SizeChanged(object sender, EventArgs e)
        {
            t.Left = (this.ClientSize.Width - t.Width) / 2;
        }

        private string Func(string s)
        {
            string s1 = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if (!(s[i] == '.'))
                {
                    s1 += s[i];
                }
            }
            return s1;
        }
    }
}
