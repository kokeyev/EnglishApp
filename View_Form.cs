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
    public partial class View_Form : Form
    {
        TableLayoutPanel table = new TableLayoutPanel();
        public string s;
        public View_Form(string s1)
        {
            InitializeComponent();
            s = s1;
        }

        private void View_Form_Load(object sender, EventArgs e)
        {
            MessageBox.Show(s);
            s = Func(s);
            MessageBox.Show(s);
            var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            path += @"\files\" + s;
            string[] s1 = File.ReadAllLines(path + @"\a.txt");
            string[] s2 = File.ReadAllLines(path + @"\b.txt");

            int n = s1.Length;
            //table.Size = new Size(440, n * 30);
            table.AutoSize = true;
            table.ColumnCount = 2;
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            table.Padding = new Padding(30);
            table.RowCount = n;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            for (int i = 0; i < n; i++)
            {
                Label l1 = new Label();
                Label l2 = new Label();
                l1.Text = s1[i];
                l2.Text = s2[i];
                table.Controls.Add(l1, 0, i);
                table.Controls.Add(l2, 1, i);
            }            
            Controls.Add(table);
            
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

        private void View_Form_SizeChanged(object sender, EventArgs e)
        {
            table.Left = (this.ClientSize.Width - table.Width) / 2;
        }
    }
}
