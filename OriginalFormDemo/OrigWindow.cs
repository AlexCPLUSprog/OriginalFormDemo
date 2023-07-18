using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OriginalFormDemo
{
    internal class OrigWindow
    {
        static public void setOriginalForm(Form form, string _form = "normal")
        {
            // Создаём форму границ - объект GraphicsPath
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            if (_form == "polygon")
            {
                // Выключаем элементы управления формой
                form.FormBorderStyle = FormBorderStyle.None;
                form.BackColor = Color.Orange;
                // Формируем вершины
                Point[] myPoint = { new Point(0,0),
                new Point(form.Width, 0),
                new Point(form.Width-50, form.Height),
                new Point(50, form.Height)};
                //myPath.AddPolygon(new Point[] { new Point(0, 0), //Верхняя левая точка
                //                                new Point(form.Width, 0), //Верхняя правая точка
                //                                new Point(0, form.Height), //Нижняя левая точка
                //                                new Point(form.Width, form.Height) }); //Нижняя правая точка
                //myPath.AddEllipse(0, 0, form.Width, form.Height);
                myPath.AddPolygon(myPoint);
                // Устанавливаем видимую область                           
                Region myRegion = new Region(myPath);
                form.Region = myRegion;
            }
            else
            {
                if (_form == "ellipse")
                {
                    // Выключаем элементы управления формой
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.BackColor = Color.Yellow;
                    // Эллипс с высотой и шириной формы
                    myPath.AddEllipse(0, 0, form.Width, form.Height);
                    // Устанавливаем видимую область                           
                    Region myRegion = new Region(myPath);
                    form.Region = myRegion;
                }
                else
                    if (_form == "octahedron")
                 {
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.BackColor = Color.Green;

                    Point[] myPoint = { 
                    new Point(0,form.Height / 3),                   // 1 точка
                    new Point(form.Width / 3, 0),                   // 2 точка
                    new Point(2*(form.Width / 3), 0),               // 3 точка
                    new Point(form.Width, form.Height / 3),         // 4 точка
                    new Point(form.Width, 2* (form.Height / 3)),    // 5 точка
                    new Point(2*(form.Width / 3),form.Height),      // 6 точка
                    new Point(form.Width / 3, form.Height),         // 7 точка
                    new Point(0, 2* (form.Height / 3)),             // 8 точка
                    };
                    myPath.AddPolygon(myPoint);
                    Region myRegion = new Region(myPath);
                    form.Region = myRegion;
                 }
                     else
                        {
                            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                            form.BackColor = Form.DefaultBackColor;
                        }
            }
        }
    }
}
