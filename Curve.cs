using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CG_Exp2_FillGraphicPrimitive
{
    
    abstract class Curve<T>
    {
        /// <summary>
        /// 绘制曲线时，当前点的坐标
        /// </summary>
        private Point cur;
        private T decision_Pk;//当前的决策参数Pk
        private struct tagParam { };//决定曲线形状的参数列表
        private tagParam param;

        public abstract Point pointBySymmetry();//根据对称性求点
        public abstract void getNextDecision();//获取下一个决策参数
        public abstract bool getNextPoint();//获取cur点的下一个点的坐标
        public abstract Point[] curPoint();//获取包含当前的点以及其对称点的点集
        /// <summary>
        /// 交换两个点的坐标
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void swap<U>(ref U a,ref U b)
        {
            U tmp;
            tmp = a;
            a = b;
            b = tmp;
        }
    }
    /// <summary>
    /// 直线类
    /// </summary>
    class Line:Curve<int>
    {
        /*    k=-1   k=1
         *      \  |  /   
         *       \3|2/
         *      4 \|/ 1
         *   --------------
         *         |
         *         |
         * */
        private Point cur;
        /// <summary>
        /// 决策参数
        /// </summary>
        private int decision_Pk;
        private struct tagParam
        {
            public Point start, end;//起始点
        }
        /// <summary>
        /// 起点和终点的坐标
        /// </summary>
        private tagParam param;
        /// <summary>
        /// const_1=2delta y;  const_2=2delta y-2delta x
        /// </summary>
        private int const_1, const_2;//计算决策变量时的几个参数，详见构造函数中的说明
        /// <summary>
        /// 表示若以原直线的起始点为原点，直线位于的区域，将xy坐标系平分成8个区域，用于对称性
        /// </summary>
        private int area;

        /// <summary>
        /// 构造函数，传入的参数为起始点横纵坐标、终点横纵坐标，并求出曲线对应在坐标系区域1的对称点
        /// </summary>
        /// <param name="a">起点横坐标</param>
        /// <param name="b">起点纵坐标</param>
        /// <param name="c">终点横坐标</param>
        /// <param name="d">终点纵坐标</param>
        public Line(Point pStart,Point pEnd)
        {
            param = new tagParam();
            param.start = pStart;
            param.end = pEnd;
            //方便起见，默认起点在终点的下方
            if (param.start.X > param.end.X)
            {
                swap(ref param.start, ref param.end);
            }
            if (param.start.Y > param.end.Y)
            {
                swap(ref param.start, ref param.end);
            }
            
            this.initialize();
        }

        /// <summary>
        /// 初始化各种参数
        /// </summary>
        private void initialize()
        {
            area = 1;
            //根据对称性将直线翻折到区域1
            if (param.end.X == param.start.X)//直线与y轴平行，则按在区域2处理
            {
                area = 2;
            }
            else
            {
                double k = Convert.ToDouble(param.end.Y - param.start.Y) / Convert.ToDouble(param.end.X - param.start.X);
                if (k > 1)//在区域2
                {
                    area = 2;
                }
                if (k < -1)//区域3
                {
                    area = 3;
                }
                if (k >= -1 && k < 0)//区域4
                {
                    area = 4;
                }
            }
            //区域3和区域4先做关于y轴的对称
            if (area == 3 || area == 4)
            {
                param.end.X = -1 * param.end.X;
                param.start.X = -1 * param.start.X;
            }
            //区域2和区域4需要再做一次关于y=x的对称
            if (area == 2 || area == 3)
            {
                int tmp;
                tmp = param.start.X;
                param.start.X = param.start.Y;
                param.start.Y = tmp;
                tmp = param.end.X;
                param.end.X = param.end.Y;
                param.end.Y = tmp;
            }
            //求计算过程中要用的参数，此时只要根据|k|<1做参数就可以了
            const_1 = 2 * Math.Abs(param.end.Y - param.start.Y);// 2delta y
            const_2 = const_1 - 2 * Math.Abs(param.end.X - param.start.X);//2delta y-2delta x
            decision_Pk = const_1 - Math.Abs(param.end.X - param.start.X);//p0=2delta y-delta x
            cur = param.start;
        }

        /// <summary>
        /// 获取下一个决策参数
        /// </summary>
        public override void getNextDecision()
        {
            if (decision_Pk < 0)
            {
                decision_Pk = decision_Pk + const_1;
            }
            else
            {
                decision_Pk = decision_Pk + const_2;
            }
        }

        /// <summary>
        /// 获得关于当前点的对称点，对于直线来说即是原直线所在区域的对称点
        /// </summary>
        /// <returns></returns>
        public override Point pointBySymmetry()
        {
            Point ret = cur ;
            int tmp;
            if (area == 1) return ret;
            if (area == 2 || area == 3)
            {
                tmp = ret.X;
                ret.X = ret.Y;
                ret.Y = tmp;
            }
            if (area == 3 || area == 4)
            {
                ret.X = -1 * ret.X;
            }
            return ret;
        }
        
        /// <summary>
        /// 获取下一个点的位置
        /// </summary>
        /// <returns>true:成功获取;false:所有点已获取完毕</returns>
        public override bool getNextPoint()
        {
            if (cur.X >= param.end.X) return false;
            Point[] retArr = new Point[1];
            if (decision_Pk < 0)
            {
                cur.X++;
            }
            else
            {
                cur.X++;
                cur.Y++;
            }
            getNextDecision();
            
            return true;
        }

        /// <summary>
        /// 获取当前点的坐标，因为是直线，一次返回一个点
        /// </summary>
        /// <returns>当前点</returns>
        public override Point[] curPoint()
        {
            Point[] arr = new Point[1];
            arr[0] = pointBySymmetry();
            return arr;
        }
    }
}
