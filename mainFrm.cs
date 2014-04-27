using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;



namespace CG_Exp2_FillGraphicPrimitive
{
    public partial class mainFrm : Form
    {
        private Point curClick;//记录鼠标点的位置
        private Color curColor;//当前选择的颜色
        private Point zero;
        private Canvas mainCanvas; 
        //private static int MAX_FACTOR = 2;
        //public double[] func;
        public mainFrm()
        {
            InitializeComponent();
            zero = new Point(panel_drawArea.Width / 2, panel_drawArea.Height / 2);
            mainCanvas = new Canvas(panel_drawArea.Width, panel_drawArea.Height);
            curColor = Color.Black;

           // func = new double[MAX_FACTOR];
           // for (int i = 0; i < MAX_FACTOR; i++) func[i] = 0 ;
            
        }

        private void textBox_factor_TextChanged(object sender, EventArgs e)
        {
            
        }

        //开始绘制直线
        private void button_startDraw_Click(object sender, EventArgs e)
        {
            
            Point pStart, pEnd;
            try
            {
                pStart = new Point(int.Parse(textBox_LineX0.Text), int.Parse(textBox_LineY0.Text));
                pEnd = new Point(int.Parse(textBox_LineXn.Text), int.Parse(textBox_LineYn.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的坐标格式（有且仅有1个整数，无多余字符）！");
                return;
            }
           
            mainCanvas.drawLine_Bresenham(pStart,pEnd,curColor);
            /*
            drawLine_Bresenham(new Point(20,60), new Point(40,-10), curColor);
            drawLine_Bresenham(new Point(40,-10), new Point(80,80), curColor);
            drawLine_Bresenham(new Point(80,80), new Point(50,90), curColor);
            drawLine_Bresenham(new Point(50,90), new Point(20,60), curColor);*/
            panel_drawArea.Refresh();
        }

        //用canvas填充panel
        private void panel_drawArea_Paint(object sender, PaintEventArgs e)
        {
            //创建工具
            Pen pen = new Pen(Color.Black);
            Graphics g = e.Graphics;
            g.DrawLine(pen, new Point(0, zero.Y), new Point(panel_drawArea.Width, zero.Y));
            g.DrawLine(pen, new Point(zero.X, 0), new Point(zero.X, panel_drawArea.Height));
            g.DrawImageUnscaled(mainCanvas.Bmp, 0, 0);
            
            //释放资源
            g.Dispose();
            pen.Dispose();
        }

        //颜色选择对话框
        private void button_chooseColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlgColor = new ColorDialog();
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                curColor = dlgColor.Color;
            }
        }

        

        //对当前点使用油漆桶工具，4连通递归填充
        private void button_bucket4_Click(object sender, EventArgs e)
        {
            Point p=new Point();
            try
            {
                p.X = int.Parse(textBox_bucketX.Text);
                p.Y = int.Parse(textBox_bucketY.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的坐标格式（有且仅有1个整数，无多余字符）！");
                return;
            }
            mainCanvas.recursiveFill(p, curColor, 4);
            panel_drawArea.Refresh();
        }

        //对当前点使用油漆桶工具，8连通递归填充
        private void button_bucket8_Click(object sender, EventArgs e)
        {
            Point p = new Point();
            try
            {
                p.X = int.Parse(textBox_bucketX.Text);
                p.Y = int.Parse(textBox_bucketY.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的坐标格式（有且仅有1个整数，无多余字符）！");
                return;
            }
            mainCanvas.recursiveFill(p, curColor, 8);
            panel_drawArea.Refresh();
        }

        //清除当前画布
        private void button_clearCanvas_Click(object sender, EventArgs e)
        {
            mainCanvas.clearCanvas();
            panel_drawArea.Refresh();
        }

        //输出到文件
        private void button_output_Click(object sender, EventArgs e)
        {
            Bitmap bmp = mainCanvas.Bmp;
            bmp.Save(@"G:\AgaIn_FieLd\大学\图形学\test.png", System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show("已输出到文件");
        }

        

        //对当前点使用油漆桶工具，扫描线转换填充
        private void button_bucketScan_Click(object sender, EventArgs e)
        {
            Point p = new Point();
            try
            {
                p.X = int.Parse(textBox_bucketX.Text);
                p.Y = int.Parse(textBox_bucketY.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的坐标格式（有且仅有1个整数，无多余字符）！");
                return;
            }
            mainCanvas.scanFill(p, curColor);
            panel_drawArea.Refresh();
        }

        //响应鼠标点击
        private void panel_drawArea_MouseDown(object sender, MouseEventArgs e)
        {
            curClick = e.Location;
            curClick.X = curClick.X - zero.X;
            curClick.Y = zero.Y - curClick.Y;
            textBox_clickX.Text = curClick.X.ToString();
            textBox_clickY.Text = curClick.Y.ToString();
        }

        private void button_setClickStart_Click(object sender, EventArgs e)
        {
            textBox_LineX0.Text = textBox_clickX.Text;
            textBox_LineY0.Text = textBox_clickY.Text;
        }

        private void button_setClickEnd_Click(object sender, EventArgs e)
        {
            textBox_LineXn.Text = textBox_clickX.Text;
            textBox_LineYn.Text = textBox_clickY.Text;
        }

        private void button_setClickFill_Click(object sender, EventArgs e)
        {
            textBox_bucketX.Text = textBox_clickX.Text;
            textBox_bucketY.Text = textBox_clickY.Text;
        }

        private void button_chooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openBmpDlg = new OpenFileDialog();
            openBmpDlg.Filter = "JPG图片(*.jpg,*.jpeg)|*.jpg|BMP图片(*.bmp)|*.bmp|GIF图片(*.gif)|*.gif|PNG图片|*.png";
            openBmpDlg.FilterIndex = 1;
            openBmpDlg.RestoreDirectory = true;
            openBmpDlg.Multiselect = false;
            if (openBmpDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openBmpDlg.FileName;
                    mainCanvas.FillImgae = new Bitmap(filePath);
                }
                catch (Exception)
                {
                    MessageBox.Show("获取文件错误！");
                }
            }
        }

        private void buttonImageFill_Click(object sender, EventArgs e)
        {

        }
    }
}
