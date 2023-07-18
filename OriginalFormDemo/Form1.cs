using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OriginalFormDemo
{
    public partial class Form1 : Form
    {
        Point pointStart; // точка для перемещения
        private void addCloseButton() 
        {
            // Кнопка закрытия
            Button buttonClose = new Button();
            buttonClose.Location = new Point(this.Width / 3, this.Height / 3);
            buttonClose.Text = "Х";
            buttonClose.BackColor = Color.White;
            buttonClose.Click += buttonClose_Click;
            this.Controls.Add(buttonClose); 
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addChoiceForm()
        {
            ComboBox cmbChoice = new ComboBox();
            cmbChoice.Location = new Point(this.Width/3, this.Height/3 + 80);
            var items = new object[] { "normal", "ellipse", "polygon", "octahedron" };
            cmbChoice.Items.AddRange(items);
            cmbChoice.SelectedValueChanged += CmbChoice_SelectedValueChanged;
            this.Controls.Add(cmbChoice);
        }

        private void CmbChoice_SelectedValueChanged(object sender, EventArgs e)
        {
            OrigWindow.setOriginalForm(this, ((ComboBox)sender).SelectedItem.ToString());
        }

        public Form1()
        {
            InitializeComponent();
            // Получаем максимальный размер окна
            var size = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            // Получаем разрешение монитора
            var size002 = SystemInformation.PrimaryMonitorSize;
            Text = $"{size002.Width} : {size002.Height}";
            // Устанавливаем длину и ширину формы без возможности изменения (запрещаем менять размер окна)
            this.MaximumSize = this.MinimumSize = new Size(size002.Width / 4, size002.Height / 4);
            /*this.Height = 500;
            this.Width = 500;*/
            addCloseButton();
            addChoiceForm();
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rectCell = new Rectangle(90,150,60,60);
            g.FillRectangle(Brushes.DarkCyan, rectCell);
            Pen pn = new Pen(Brushes.BlueViolet, 20);
            g.DrawEllipse(pn, 15, 10, 300, 140);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if (e.Button == MouseButtons.Left)
            {
                pointStart = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if ((e.Button & MouseButtons.Left) != 0)
            {
                // получаем новую точку положения формы
                Point deltaPos = new Point(e.X - pointStart.X, e.Y - pointStart.Y);
                // устанавливаем положение формы
                this.Location = new Point(this.Location.X + deltaPos.X,
                  this.Location.Y + deltaPos.Y);
            }
        }
    }
}
