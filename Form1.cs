using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


/*
to-do:
set the sizes of all elements (almost done)
set label and buttons when new row creates (done)
set the space between cells in TableLayoutPanel (not started)
make function to get cell, which was pressed (done)
set some design, colors (not started)
algo to save and show data (not started)

send me to telegram button
placeholder to the testform
*/

namespace EnglishApp
{
    public partial class Form1 : Form
    {
        public TableLayoutPanel tb = new TableLayoutPanel();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            button1.Text = Convert.ToString(tb.RowCount);
            tb.Left = (this.ClientSize.Width - tb.Width) / 2;
            tb.ColumnCount = 3;
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.7F));
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.15F));
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.15F));
            show_table();
        }
        public void show_table()
        {

            var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            path += @"\files";
            Directory.CreateDirectory(path);
            string[] directories = Directory.GetDirectories(path);
            
            foreach (string i in directories)
            {
                string s = Getdate(i);
                
                if (tb.RowCount == 0)
                {
                    tb.Location = new Point(21, 120);
                    tb.Margin = new Padding(0, 0, 0, 0);
                    tb.Size = new Size(600, 0);
                    tb.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                    Controls.Add(tb);
                }
                tb.RowCount += 1;
                tb.Height += 70;
                tb.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
                Label l = new Label(); l.Text = s;
                Button view = new Button(); view.Text = "View";
                Button test = new Button(); test.Text = "Test";
                foreach (Control C in tb.Controls)
                {
                    tb.SetRow(C, tb.GetRow(C) + 1);
                }
                tb.Controls.Add(l, 0, 0);
                tb.Controls.Add(view, 1, 0);
                tb.Controls.Add(test, 2, 0);
                tb.Left = (this.ClientSize.Width - tb.Width) / 2;
                button1.Text = Convert.ToString(tb.ColumnCount);

                try
                {
                    Control c = tb.GetControlFromPosition(0, 0); c.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
                    Control c1 = tb.GetControlFromPosition(1, 0); c1.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
                    Control c2 = tb.GetControlFromPosition(2, 0); c2.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
                }
                catch
                {

                }
            }
            
        }

        private string Getdate(string i)
        {
            char[] arr = i.ToCharArray();
            Array.Reverse(arr);
            string s = new string(arr);
            s = s.Substring(0, 8);
            char[] arr2 = s.ToCharArray();
            Array.Reverse(arr2);
            string s1 = new string(arr2);
            s1 = s1.Insert(2, ".");
            s1 = s1.Insert(5, ".");
            return s1;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
            tb.Left = (this.ClientSize.Width - tb.Width) / 2;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            add_row();
        }
        public void add_row()
        {
            Create_row form = new Create_row();
            form.ShowDialog();

            if (tb.RowCount == 0)
            {
                tb.Location = new Point(21, 120);
                tb.Margin = new Padding(0, 0, 0, 0);
                tb.Size = new Size(600, 0);
                tb.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                Controls.Add(tb);
            }
            tb.RowCount += 1;
            tb.Height += 70;
            tb.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            Label l = new Label(); l.Text = DateTime.Now.ToString("dd.MM.yyyy");
            Button view = new Button(); view.Text = "View";
            Button test = new Button(); test.Text = "Test";
            foreach(Control C in tb.Controls)
            {
                tb.SetRow(C, tb.GetRow(C) + 1);
            }
            tb.Controls.Add(l, 0, 0);
            tb.Controls.Add(view, 1, 0);
            tb.Controls.Add(test, 2, 0);
            tb.Left = (this.ClientSize.Width - tb.Width) / 2;
            button1.Text = Convert.ToString(tb.ColumnCount);

            try
            {
                Control c = tb.GetControlFromPosition(0, 0); c.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
                Control c1 = tb.GetControlFromPosition(1, 0); c1.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
                Control c2 = tb.GetControlFromPosition(2, 0); c2.MouseClick += new MouseEventHandler(ClickOnTableLayoutPanel);
            } catch
            {

            }
            
        }
        public void ClickOnTableLayoutPanel(object sender, MouseEventArgs e)
        {
            int c = tb.GetColumn((Control)sender), r = tb.GetRow((Control)sender);
            Control c1 = tb.GetControlFromPosition(0, r);

            if (c == 1)
            {
                View_Form view_form = new View_Form(c1.Text);
                view_form.ShowDialog();
            }
            else if (c == 2)
            {
                TestForm test = new TestForm(r, c, c1.Text);
                test.ShowDialog();
            }
            //MessageBox.Show("Cell chosen: (" + tb.GetRow((Control)sender) + ", " + tb.GetColumn((Control)sender) + ")");
        }
    }
}
