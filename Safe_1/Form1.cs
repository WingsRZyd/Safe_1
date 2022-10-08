using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Safe_1
{ 
    /*public class Button_game
    {
        Button button = new Button();
        
    }*/
    public partial class Form1 : Form
    {
        private Panel TableContainer = new Panel();
        public Bitmap OnTexture = Resource1.on,
                      OffTexture = Resource1.off;
            private Button[] buttons = new Button[10 * 10];

        public Form1()
        {
            InitializeComponent();

            Button[] buttons = new Button[10 * 10];

            // ������ ��� ��������� �������
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(button1);     
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
 
            button1.Click += new System.EventHandler(CreateTable);
             

            // ��������� ��� ������ ������� �������
            TableContainer.Dock = DockStyle.Fill;

            // ��������� ����������� �������� �� �����
            
            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(TableContainer);

            this.Controls.SetChildIndex(flowLayoutPanel1, 1);
            this.Controls.SetChildIndex(TableContainer, 0);
        }

        private void CreateTable(object sender, EventArgs e)
        {
            // ������� ���������� �������
            TableContainer.Controls.Clear();

            // ������� �����
            var tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Visible = true;

            tableLayoutPanel.ColumnCount = Convert.ToInt32(textBox1.Text);

            // ��������� ��������� ����� ��� ��������� ������� (����� ���� �����)
            var rnd = new Random(DateTime.Now.Millisecond);

            // ���������� ������ ����� ������� � ������, � ���������
            int width = 100 / tableLayoutPanel.ColumnCount;
            int height = 100 / tableLayoutPanel.ColumnCount;

            this.Text = String.Format("{0}x{1}", width, height);

            // ��������� ������� � ������
            for (int col = 0; col < tableLayoutPanel.ColumnCount; col++)
            {
                // ��������� �������
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));

                for (int row = 0; row < tableLayoutPanel.ColumnCount; row++)
                {
                    // ��������� ������
                    if (col == 0)
                    {
                        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, height));
                    }
                }
            }

                    // ��������� ������� ������, ����� ���� ����� ������ � �������
                    var panel = new Panel();
                    //Button[] buttons = new Button[tableLayoutPanel.RowCount * tableLayoutPanel.RowCount];
                    int count = 0;
                    int val = 0;

                    //panel.BackColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    //panel.Dock = DockStyle.Top;
                    panel.Size = OnTexture.Size;
                    //tableLayoutPanel.Controls.Add(panel, col, row);
                    
                    for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
                    {
                        for (int j = 0; j < tableLayoutPanel.ColumnCount; j++)
                        {
                            buttons[count] = new Button();
                            buttons[count].Height = 100;
                            buttons[count].Width = 100;
                            int flag = 0;
                            flag = rnd.Next(0, 2);
                            if (flag == 1)
                            {
                                buttons[count].Text = "|";
                            }
                            else
                            {
                                buttons[count].Text = "�";
                                //buttons[count].Text = Convert.ToString(count);
                            }
                            buttons[count].Click += new EventHandler(button_Click);
                            tableLayoutPanel.Controls.Add(buttons[count], i, j);
                            count++;
                        }
                        
                    }
          

            // ��������� ������� � ���������
            TableContainer.Controls.Add(tableLayoutPanel);
        }

        private void button_Click(object sender, EventArgs e) 
        {
            Button button = (Button)sender;
            //buttons[0].EnabledChanged += button_Click;
            //buttons[0].PerformClick();
            button1_Click(buttons[15], null);
            //button.Text = Convert.ToString((int)button.Tag);
            if (button.Text == "|")
            {
                button.Text = "�";
            }
            else if (button.Text == "�")
            {
                button.Text = "|";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //buttons[0].EnabledChanged += button_Click;
            //buttons[0].PerformClick();
            //button_Click(buttons[0], null);
            //button.Text = Convert.ToString((int)button.Tag);
            if (button.Text == "|")
            {
                button.Text = "�";
            }
            else if (button.Text == "�")
            {
                button.Text = "|";
            }
        }
    }

}