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
        //private Canvas canvasBG; //背景图层
        private List<Canvas> layers;//图层
        private Canvas curCanvas;//当前操作的图层
        //private static int MAX_FACTOR = 2;
        //public double[] func;
        
        //构造函数
        public mainFrm()
        {
            InitializeComponent();
            //定义坐标原点
            zero = new Point(panel_drawArea.Width / 2, panel_drawArea.Height / 2);
            //创建背景图层
            Canvas canvasBG;
            canvasBG = new Canvas(panel_drawArea.Width, panel_drawArea.Height, Color.White);
            canvasBG.Locked = true;
            listBox_layers.Items.Add("背景图层");
            //当前默认颜色设置为黑色
            curColor = Color.Black;
            //创建图层数组
            layers = new List<Canvas>();
            layers.Add(canvasBG);
            //当前图层默认为背景图层
            curCanvas = canvasBG;
            panel_drawArea.Refresh();
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

            curCanvas.drawLine_Bresenham(pStart, pEnd, curColor);
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
            //g.DrawLine(pen, new Point(0, zero.Y), new Point(panel_drawArea.Width, zero.Y));
            //g.DrawLine(pen, new Point(zero.X, 0), new Point(zero.X, panel_drawArea.Height));
            for (int i = 0; i < layers.Count; i++)
            {
                g.DrawImageUnscaled(layers[i].Bmp, 0, 0);
            }
            
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
            curCanvas.recursiveFill(p, curColor, 4);
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
            curCanvas.recursiveFill(p, curColor, 8);
            panel_drawArea.Refresh();
        }

        //清除当前画布内容
        private void button_clearCanvas_Click(object sender, EventArgs e)
        {
            curCanvas.clearCanvas();
            panel_drawArea.Refresh();
        }

        //输出到文件
        private void button_output_Click(object sender, EventArgs e)
        {
            Bitmap bmp = curCanvas.Bmp;
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
            curCanvas.scanFill(p, curColor);
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

        //设置直线起始点为当前点击的点
        private void button_setClickStart_Click(object sender, EventArgs e)
        {
            textBox_LineX0.Text = textBox_clickX.Text;
            textBox_LineY0.Text = textBox_clickY.Text;
        }

        //设置直线终点为当前点击的点
        private void button_setClickEnd_Click(object sender, EventArgs e)
        {
            textBox_LineXn.Text = textBox_clickX.Text;
            textBox_LineYn.Text = textBox_clickY.Text;
        }

        //设置填充点
        private void button_setClickFill_Click(object sender, EventArgs e)
        {
            textBox_bucketX.Text = textBox_clickX.Text;
            textBox_bucketY.Text = textBox_clickY.Text;
        }

        //选择图像填充的图像
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
                    curCanvas.FillImgae = new Bitmap(filePath);
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

        //新建透明图层
        private void button_createLayer_Click(object sender, EventArgs e)
        {
            Canvas newlayers=new Canvas(panel_drawArea.Width,panel_drawArea.Height,Color.Transparent);
            layers.Add(newlayers);
            listBox_layers.Items.Add("图层"+(listBox_layers.Items.Count).ToString());
            panel_drawArea.Refresh();
        }

        //选择图层
        private void listBox_layers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox_layers.SelectedIndex;
            if (index >= 0 && index < listBox_layers.Items.Count)
            {
                curCanvas = layers[index];
                textBox_selectedLayer.Text = "图层" + index.ToString();
            }
        }

        //删除图层
        private void button_deleteLayer_Click(object sender, EventArgs e)
        {
            int index = listBox_layers.SelectedIndex;
            if (layers[index].Locked==true)
            {
                MessageBox.Show("无法删除图层 已锁定！");
                return;
            }
            else
            {
                layers.RemoveAt(index);
                listBox_layers.SelectedIndex--;
                listBox_layers.Items.RemoveAt(index);
                panel_drawArea.Refresh();
            }
        }

        //图层上移
        private void button_layerUp_Click(object sender, EventArgs e)
        {
            int index = listBox_layers.SelectedIndex;
            if (index <= 1) return;//背景图层不能被移动顺序
            else
            {
                listBox_layers.SelectedIndex--;
                var tmp = listBox_layers.Items[index];
                listBox_layers.Items[index] = listBox_layers.Items[index - 1];
                listBox_layers.Items[index - 1] = tmp;
                var tmp2 = layers[index];
                layers[index] = layers[index - 1];
                layers[index - 1] = tmp2;
                panel_drawArea.Refresh();
            }
        }

        //图层下移
        private void button_layerDown_Click(object sender, EventArgs e)
        {
            int index = listBox_layers.SelectedIndex;
            if (index == listBox_layers.Items.Count - 1 || index == 0) return;//背景图层不能被移动
            else
            {
                listBox_layers.SelectedIndex++;
                var tmp = listBox_layers.Items[index];
                listBox_layers.Items[index] = listBox_layers.Items[index + 1];
                listBox_layers.Items[index + 1] = tmp;
                var tmp2 = layers[index];
                layers[index] = layers[index + 1];
                layers[index + 1] = tmp2;
                panel_drawArea.Refresh();
            }
        }
    }
}
