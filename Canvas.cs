﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CG_Exp2_FillGraphicPrimitive
{
    /// <summary>
    /// 计时器，秒表
    /// </summary>
    class Timer
    {
        private DateTime startTime,curTime;
        private bool started;

        /// <summary>
        /// 开始
        /// </summary>
        public void start()
        {
            curTime = new DateTime();
            startTime = new DateTime();
            startTime = DateTime.Now;
            started = true;
        }

        /// <summary>
        /// 计时
        /// </summary>
        /// <returns>从开始到现在经过的时间，以秒为单位</returns>
        public double count()
        {
            if (started == true)
            {
                curTime = DateTime.Now;
                return (curTime - startTime).TotalSeconds;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 停止计时
        /// </summary>
        /// <returns>从开始到现在经过的时间，以秒为单位</returns>
        public double stop()
        {
            double ret = count();
            //待添加
            started = false;
            return ret;
        }
    }

    /// <summary>
    /// 画布类
    /// </summary>
    class Canvas
    {
        private Point zero; //坐标系的(0,0)在panel中的位置
        private Line line;//直线
        private Circle circle;//圆
        private Timer timer;//秒表

        /// <summary>
        /// 图层的名字
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private string name;

        /// <summary>
        /// 图层默认背景色
        /// </summary>
        public Color BGColor
        {
            get
            {
                return bgColor;
            }
            set
            {
                bgColor = value;
            }
        }
        private Color bgColor;

        /// <summary>
        /// 图层是否锁定（无法删除）
        /// </summary>
        public bool Locked
        {
            get
            {
                return locked;
            }
            set
            {
                locked = value;
            }
        }
        private bool locked;

        /// <summary>
        /// 图层是否隐藏
        /// </summary>
        public bool Hidden
        {
            get
            {
                return hidden;
            }
            set
            {
                hidden = value;
            }
        }
        private bool hidden;
        /// <summary>
        /// 主绘图区
        /// </summary>
        public Bitmap Bmp
        {
            get
            {
                return bmp;
            }
            set
            {
                bmp = value;
            }
        }
        private Bitmap bmp;//表示要画到panel控件中的图

        /// <summary>
        /// 构造函数，输入画布的宽度和高度
        /// </summary>
        /// <param name="width">画布的宽度</param>
        /// <param name="height">画布的高度</param>
        /// <param name="bg">背景色</param>
        public Canvas(int width,int height,Color bg, string str)
        {
            bmp = new Bitmap(width, height);
            zero.X = width / 2;
            zero.Y = height / 2;
            timer = new Timer();
            bgColor = bg;//默认为透明色
            locked = false;
            hidden = false;
            name = str;
            clearCanvas();
        }

        /// <summary>
        /// 清空画布，使用图层默认背景色填充
        /// </summary>
        public void clearCanvas()
        {
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                    bmp.SetPixel(i, j, bgColor);
        }

        /// <summary>
        /// 填充时，判断点是否可以在画布上，包含边界判断
        /// </summary>
        /// <param name="p">点在参考坐标系中的位置</param>
        /// <param name="model">种子点的颜色</param>
        /// <returns>true:可以; false:不可以</returns>
        private bool canPaintInCanvas(Point p, Color model)
        {
            int x, y;//实际画布中的位置
            x = p.X + zero.X;
            y = zero.Y - p.Y;
            if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
            {
                if (bmp.GetPixel(x, y).ToArgb() == model.ToArgb()) return true;
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// 对于参照坐标系的点，得出画布中的位置
        /// </summary>
        /// <param name="p">参考坐标系中的坐标</param>
        /// <param name="c">颜色</param>
        private bool drawOnCanvas(Point p, Color c)
        {
            int x, y;//实际画布中的位置
            x = p.X + zero.X;
            y = zero.Y - p.Y;
            if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
            {
                bmp.SetPixel(x, y, c);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 对当前输入的直线，使用Bresenham算法画出图像
        /// </summary>
        /// <param name="pStart">直线起点</param>
        /// <param name="pEnd">直线终点</param>
        /// <param name="color">直线颜色</param>
        public void drawLine_Bresenham(Point pStart, Point pEnd, Color color)
        {
            line = new Line(pStart, pEnd);
            foreach (Point cur in line.curPoint())
            {
                drawOnCanvas(cur, color);
            }
            while (line.getNextPoint() == true)
            {
                foreach (Point cur in line.curPoint())
                {
                    drawOnCanvas(cur, color);
                }
            }
        }

        /// <summary>
        /// 对当前输入的参数使用bresenham算法画圆
        /// </summary>
        /// <param name="center">圆心坐标</param>
        /// <param name="R">半径</param>
        /// <param name="color">颜色</param>
        public void drawCircle_Bresenham(Point center, int R, Color color)
        {
            circle = new Circle(center, R);
            foreach (Point cur in circle.curPoint())
            {
                drawOnCanvas(cur, color);
            }
            while (circle.getNextPoint() == true)
            {
                foreach (Point cur in circle.curPoint())
                {
                    drawOnCanvas(cur, color);
                }
            }
        }

        /// <summary>
        /// 递归填充当前点
        /// </summary>
        /// <param name="start">起始点</param>
        /// <param name="color">待填充的颜色</param>
        /// <param name="connective">连通性(只接受4或8)</param>
        public void recursiveFill(Point start, Color color, int connective)
        {
            if (connective != 4 && connective != 8)
            {
                MessageBox.Show("连通性请输入4或8！");
                return;
            }
            //记录时间
            timer.start();
            //判断点是否加入过队列
            bool[,] addedQueue = new bool[bmp.Width + 5, bmp.Height + 5];
            for (int i = 0; i < bmp.Width + 5; i++)
                for (int j = 0; j < bmp.Height + 5; j++) addedQueue[i, j] = false;
            Queue<Point> pointList = new Queue<Point>();

            pointList.Enqueue(start);
            //int connective = 8;//连通性
            Point cur, next;
            Color model = bmp.GetPixel(start.X + zero.X, zero.Y - start.Y);
            int max = 0;//记录队列最长长度
            while (pointList.Count > 0)
            {
                if (pointList.Count > max) max = pointList.Count;
                cur = pointList.Dequeue();
                if (canPaintInCanvas(cur, model) == false)
                {
                    continue;
                }
                drawOnCanvas(cur, color);
                next = cur;
                if (connective == 8)
                {
                    for (int i = 0; i < connective; i++)
                    {
                        switch (i)
                        {
                            case 0: next.X++; break;//右
                            case 1: next.Y++; break;//右上
                            case 2: next.X--; break;//上
                            case 3: next.X--; break;//左上
                            case 4: next.Y--; break;//左
                            case 5: next.Y--; break;//左下
                            case 6: next.X++; break;//下
                            case 7: next.X++; break;//右下
                        };
                        if (canPaintInCanvas(next, model) == true && addedQueue[next.X + zero.X, zero.Y - next.Y] == false)
                        {
                            pointList.Enqueue(next);
                            addedQueue[next.X + zero.X, zero.Y - next.Y] = true;
                        }
                    }
                }
                if (connective == 4)
                {
                    for (int i = 0; i < connective; i++)
                    {
                        switch (i)
                        {
                            case 0: next.X++; break;//右
                            case 1: next.X--; next.Y++; break;//上
                            case 2: next.Y--; next.Y--; break;//下
                            case 3: next.Y++; next.X--; break;//左
                        };
                        if (canPaintInCanvas(next, model) == true && addedQueue[next.X + zero.X, zero.Y - next.Y] == false)
                        {
                            pointList.Enqueue(next);
                            addedQueue[next.X + zero.X, zero.Y - next.Y] = true;
                        }
                    }
                }
            }
            MessageBox.Show("填充完毕，队列最大长度为:" + max.ToString() + "\n用时:" + timer.stop().ToString("f3")+"秒");
        }

        /// <summary>
        /// 对当前点采用扫描线转换填充为color颜色
        /// </summary>
        /// <param name="start">起始点</param>
        /// <param name="color">待填充的颜色</param>
        public void scanFill(Point start, Color color)
        {
            //记录时间
            timer.start();

            //创建队列
            Queue<Point> pointList = new Queue<Point>();
            //判断点是否加入过队列
            bool[,] addedQueue = new bool[bmp.Width + 5, bmp.Height + 5];
            for (int i = 0; i < bmp.Width + 5; i++)
                for (int j = 0; j < bmp.Height + 5; j++) addedQueue[i, j] = false;
            //起点作为种子点加入队列
            pointList.Enqueue(start);
            Point cur, seed, left, right;
            bool upBlocked, downBlocked;//上下两行确定种子点时是否遇到不能填充的点，即每一行中，一段连续的可填充的点只需要一个种子点进入队列
            Color model = bmp.GetPixel(start.X + zero.X, zero.Y - start.Y);
            int max = 0;
            while (pointList.Count > 0)
            {
                if (pointList.Count > max) max = pointList.Count;
                seed = pointList.Dequeue();
                drawOnCanvas(seed, color);
                //向左扫描
                left = seed;
                left.X--;
                while (canPaintInCanvas(left, model) == true)
                {
                    drawOnCanvas(left, color);
                    addedQueue[left.X + zero.X, zero.Y - left.Y] = true;
                    left.X--;
                }
                left.X++;
                //向右扫描
                right = seed;
                right.X++;
                while (canPaintInCanvas(right, model) == true)
                {
                    drawOnCanvas(right, color);
                    addedQueue[right.X + zero.X, zero.Y - right.Y] = true;
                    right.X++;
                }
                right.X--;
                //确定这一行上下行的种子点
                cur = left;
                upBlocked = true;
                downBlocked = true;
                Point next = new Point();
                while (cur.X <= right.X)
                {
                    //上一行
                    next.X = cur.X;
                    next.Y = cur.Y + 1;
                    if (canPaintInCanvas(next, model) == true)
                    {
                        if (upBlocked == true)
                        {
                            upBlocked = false;
                            if (addedQueue[next.X + zero.X, zero.Y - next.Y] == false)
                            {
                                pointList.Enqueue(next);
                                addedQueue[next.X + zero.X, zero.Y - next.Y] = true;
                            }
                        }
                    }
                    else
                    {
                        upBlocked = true;
                    }
                    //下一行
                    next.X = cur.X;
                    next.Y = cur.Y - 1;
                    if (canPaintInCanvas(next, model) == true)
                    {
                        if (downBlocked == true)
                        {
                            downBlocked = false;
                            if (addedQueue[next.X + zero.X, zero.Y - next.Y] == false)
                            {
                                pointList.Enqueue(next);
                                addedQueue[next.X + zero.X, zero.Y - next.Y] = true;
                            }
                        }
                    }
                    else
                    {
                        downBlocked = true;
                    }
                    cur.X++;
                }
            }
            MessageBox.Show("填充完毕，队列最大长度为:" + max.ToString() + "\n用时:" + timer.stop().ToString("f3")+"秒");
        }

        /// <summary>
        /// 获取以当前点为种子点的相同（相似）颜色区域（魔棒工具），采用4连通算法
        /// </summary>
        /// <param name="start">种子点</param>
        /// <returns>一张与本图层大小相同的bmp图像，选区为深蓝色(DarkBlue)，其余为默认透明色</returns>
        public Bitmap getSelection(Point start)
        {
            Bitmap selection = new Bitmap(this.bmp.Width,this.bmp.Height);
            //判断点是否加入过队列
            bool[,] addedQueue = new bool[bmp.Width + 5, bmp.Height + 5];
            for (int i = 0; i < bmp.Width + 5; i++)
                for (int j = 0; j < bmp.Height + 5; j++) addedQueue[i, j] = false;
            Queue<Point> pointList = new Queue<Point>();
            pointList.Enqueue(start);
            Point cur, next;
            Color model = bmp.GetPixel(start.X + zero.X, zero.Y - start.Y);
            int max = 0;//记录队列最长长度
            while (pointList.Count > 0)
            {
                if (pointList.Count > max) max = pointList.Count;
                cur = pointList.Dequeue();
                if (canPaintInCanvas(cur, model) == false)
                {
                    continue;
                }
                selection.SetPixel(cur.X + zero.X, zero.Y - cur.Y, Color.DarkBlue);
                next = cur;
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0: next.X++; break;//右
                        case 1: next.X--; next.Y++; break;//上
                        case 2: next.Y--; next.Y--; break;//下
                        case 3: next.Y++; next.X--; break;//左
                    };
                    if (canPaintInCanvas(next, model) == true && addedQueue[next.X + zero.X, zero.Y - next.Y] == false)
                    {
                        pointList.Enqueue(next);
                        addedQueue[next.X + zero.X, zero.Y - next.Y] = true;
                    }
                }
            }
            return selection;
        }

        /// <summary>
        /// 填充选区为指定颜色
        /// </summary>
        /// <param name="selection">选区</param>
        /// <param name="color">待填充的颜色</param>
        public void fillSelection(Bitmap selection, Color color)
        {
            for (int i=0;i<selection.Width;i++)
                for (int j = 0; j < selection.Height; j++)
                {
                    if (selection.GetPixel(i, j).ToArgb() == Color.DarkBlue.ToArgb())
                    {
                        bmp.SetPixel(i, j, color);
                    }
                }
        }

        /// <summary>
        /// 图像填充
        /// </summary>
        /// <param name="selection">选区</param>
        /// <param name="image">待填充的图像</param>
        public void imageFill(Bitmap selection, Bitmap image)
        {
            int i,j;
            //记录选区
            bool[,] canPaint = new bool[bmp.Width + 5, bmp.Height + 5];
            for (i = 0; i < bmp.Width + 5; i++)
                for (j = 0; j < bmp.Height + 5; j++) canPaint[i, j] = false;
            //获取选区
            for (i=0;i<selection.Width;i++)
                for (j = 0; j < selection.Height; j++)
                {
                    if (selection.GetPixel(i, j).ToArgb() == Color.DarkBlue.ToArgb())
                    {
                        canPaint[i, j] = true;
                    }
                }
            
            //填充了图像的背景图层（范围大于选区）
            Bitmap tmp = new Bitmap(bmp.Width, bmp.Height);
            //获取左上角的一个选区点
            for (i = 0; i < bmp.Width; i++)
            {
                for (j = 0; j < bmp.Height; j++)
                {
                    if (canPaint[i, j] == true)
                    {
                        break;
                    }
                }
                if (j < bmp.Height) break;
            }
            //填充背景图层

            while (i < bmp.Width)
            {
                j = 0;
                while (j < bmp.Height)
                {
                    for (int x = 0; x < image.Width; x++)
                        for (int y = 0; y < image.Height; y++)
                        {
                            if (i + x < tmp.Width && j + y < tmp.Height)
                            {
                                tmp.SetPixel(i + x, j + y, image.GetPixel(x, y));
                            }
                        }
                    j = j + image.Height;
                }
                i = i + image.Width;
            }
            //遍历在选区内的点，将bmp中的像素值替换为背景图层
            for (i = 0; i < bmp.Width; i++)
                for (j = 0; j < bmp.Height; j++)
                {
                    if (canPaint[i, j] == true) bmp.SetPixel(i, j, tmp.GetPixel(i, j));
                }
        }
    }
}
