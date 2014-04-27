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
        private Timer timer;//秒表

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
        /// 待填充的图像
        /// </summary>
        public Bitmap FillImgae
        {
            get
            {
                return fillImage;
            }
            set
            {
                fillImage = value;
            }
        }
        private Bitmap fillImage;//需要填充的图像

        /// <summary>
        /// 构造函数，输入画布的宽度和高度
        /// </summary>
        /// <param name="width">画布的宽度</param>
        /// <param name="height">画布的高度</param>
        public Canvas(int width,int height)
        {
            bmp = new Bitmap(width, height);
            zero.X = width / 2;
            zero.Y = height / 2;
            timer = new Timer();
        }

        /// <summary>
        /// 清空画布
        /// </summary>
        public void clearCanvas()
        {
            bmp = new Bitmap(zero.X * 2, zero.Y * 2);
        }

        /// <summary>
        /// 填充时，判断点是否可以在画布上
        /// </summary>
        /// <param name="p">点在参考坐标系中的位置</param>
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
            if (model.ToArgb() == color.ToArgb())
            {
                MessageBox.Show("所选颜色和当前点颜色相同");
                return;
            }
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
            //起点作为种子点加入队列
            pointList.Enqueue(start);
            Point cur, seed, left, right;
            bool upBlocked, downBlocked;//上下两行确定种子点时是否遇到不能填充的点
            Color model = bmp.GetPixel(start.X + zero.X, zero.Y - start.Y);
            int max = 0;
            if (model.ToArgb() == color.ToArgb())
            {
                MessageBox.Show("所选颜色和当前点颜色相同");
                return;
            }
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
                    left.X--;
                }
                left.X++;
                //向右扫描
                right = seed;
                right.X++;
                while (canPaintInCanvas(right, model) == true)
                {
                    drawOnCanvas(right, color);
                    right.X++;
                }
                right.X--;
                //确定这一行上下行的种子点
                cur = left;
                upBlocked = true;
                downBlocked = true;
                while (cur.X <= right.X)
                {
                    //上一行
                    if (canPaintInCanvas(new Point(cur.X, cur.Y + 1), model) == true)
                    {
                        if (upBlocked == true)
                        {
                            upBlocked = false;
                            pointList.Enqueue(new Point(cur.X, cur.Y + 1));
                        }
                    }
                    else
                    {
                        upBlocked = true;
                    }
                    //下一行
                    if (canPaintInCanvas(new Point(cur.X, cur.Y - 1), model) == true)
                    {
                        if (downBlocked == true)
                        {
                            downBlocked = false;
                            pointList.Enqueue(new Point(cur.X, cur.Y - 1));
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
    }
}