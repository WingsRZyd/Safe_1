using System.Diagnostics;
using System.Drawing.Printing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Safe_1
{ 
    public partial class Form1 : Form
    {
        private Panel TableContainer = new Panel();
        public Bitmap OnTexture = Resource1.on,
                      OffTexture = Resource1.off;
        private Button[] buttons = new Button[50 * 50];
        private int countRow = 0;

        public Form1()
        {
            InitializeComponent();

            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(button1);     
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            label2.Text = "Сейф до сих пор закрыт";
            label2.Height = 1000;
            label2.Width = 1000;
            label2.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            button1.Click += new System.EventHandler(CreateTable);

            TableContainer.Dock = DockStyle.Fill;

            this.Controls.Add(flowLayoutPanel1);
            this.Controls.Add(TableContainer);

            this.Controls.SetChildIndex(flowLayoutPanel1, 1);
            this.Controls.SetChildIndex(TableContainer, 0);
        }

        //создание таблицы
        private void CreateTable(object sender, EventArgs e)
        {
            label2.Text = "Сейф до сих пор закрыт";
            TableContainer.Controls.Clear();

            var tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Visible = true;

            tableLayoutPanel.ColumnCount = Convert.ToInt32(textBox1.Text);
            countRow = tableLayoutPanel.ColumnCount;

            var rnd = new Random(DateTime.Now.Millisecond);

            int width = 100 / tableLayoutPanel.ColumnCount;
            int height = 100 / tableLayoutPanel.ColumnCount;

            this.Text = String.Format("{0}x{1}", width, height);

            for (int col = 0; col < tableLayoutPanel.ColumnCount; col++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));

                for (int row = 0; row < tableLayoutPanel.ColumnCount; row++)
                {
                    if (col == 0)
                    {
                        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, height));
                    }
                }
            }
                    var panel = new Panel();
                    int count = 0;
                    int val = 0;

                    panel.Size = OnTexture.Size;
                    
                    for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
                    {
                        for (int j = 0; j < tableLayoutPanel.ColumnCount; j++)
                        {
                            buttons[count] = new Button();
                            buttons[count].Height = 100;
                            buttons[count].Width = 100;
                            
                            //случайное положение рычага
                            int flag = 0;
                            flag = rnd.Next(0, 2);
                            if (flag == 1)
                            {
                                buttons[count].Text = "|";
                                buttons[count].Tag = count;
                            }
                            else
                            {
                                buttons[count].Text = "—";
                                buttons[count].Tag = count;
                            }
                            buttons[count].Click += new EventHandler(button_Click);
                            tableLayoutPanel.Controls.Add(buttons[count], i, j);
                            count++;
                        }
                        
                    }
            TableContainer.Controls.Add(tableLayoutPanel);
        }
        //функционал кнопок (рычагов) в таблице (на сейфе) 
        private void button_Click(object sender, EventArgs e) 
        {
            Button button = (Button)sender;  
            if ((Convert.ToInt32(button.Tag) % countRow) == 0)
            {
                for (int i = 0; i < (countRow); i++)
                {
                    button1_Click(buttons[Convert.ToInt32(button.Tag) + i], null);
                }
                for (int i = 0; i < countRow * countRow; i = i + countRow)
                {
                    button1_Click(buttons[i], null);
                }
            }
            else if ((Convert.ToInt32(button.Tag) % countRow) == countRow - 1)
            {
                for (int i = Convert.ToInt32(button.Tag) - countRow + 1; i % countRow < (countRow) - 1; i++)
                {
                    button1_Click(buttons[i], null);
                }
                for (int i = countRow - 1; i < countRow * countRow; i = i + countRow)
                {
                    button1_Click(buttons[i], null);
                }
                button1_Click(button, null);
            }
            else
            {
                for (int i = Convert.ToInt32(button.Tag) - (Convert.ToInt32(button.Tag) % countRow); i % countRow < (countRow) - 1; i++)
                {
                    button1_Click(buttons[i], null);
                }
                for (int i = Convert.ToInt32(button.Tag) % countRow; i < countRow * countRow; i = i + countRow)
                {
                    button1_Click(buttons[i], null);
                }
                button1_Click(buttons[((Convert.ToInt32(button.Tag) / countRow) * countRow) + countRow - 1], null);
            }
            if (button.Text == "|")
            {
                button.Text = "—";
            }
            else if (button.Text == "—")
            {
                button.Text = "|";
            } 

            //проверка на правильнось положения рычагов
            bool flag = true;
            for (int i = 0; i < countRow * countRow; i++)
            {
                if (buttons[i].Text == "|")
                {
                    flag = true;
                }
                else
                {
                flag = false;
                break;
                }
            }
            if (flag == true)
            {
                label2.Text = "Поздравляем! Сейф открыт";
            }

            flag = true;
            for (int i = 0; i < countRow * countRow; i++)
            {
                if (buttons[i].Text == "—")
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                label2.Text = "Поздравляем! Сейф открыт";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "|")
            {
                button.Text = "—";
            }
            else if (button.Text == "—")
            {
                button.Text = "|";
            }
        }
    }

}