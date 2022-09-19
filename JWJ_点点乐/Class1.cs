using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JWJ_点点乐
{
    public class happy_click
    {
        Point cur_house;//当前位置
        Point[] houses;//宠物所有的可去位置（所有的家）
        int playtime;//游戏时长
        int difficult;//难度值
        Image pet;//宠物
        int pet_index;//宠物索引号
        Size pet_size;//宠物大小
        bool flag;//true表示正在进行搬家（切换到另一个位置）
        bool flag2;//true可以搬家********改进单击宠物时多切换一次草丛的问题
        int score;//得分


        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="ipet">当前宠物图片</param>
        /// <param name="imgindex">当前宠物索引号</param>
        /// <param name="ihouses">宠物所有的位置（家）集合</param>
        /// <param name="h_index">当前位置（家）的索引号</param>
        /// <param name="isize">宠物大小</param>
        public happy_click(Image ipet, int imgindex, Point[] ihouses, int h_index, Size isize)
        {
            pet = ipet;//从参数获取默认宠物图片
            pet_index = imgindex;//默认宠物索引号为

            houses = new Point[ihouses.Length];
            Array.Copy(ihouses, houses, ihouses.Length);

            pet_size = isize;//从参数获取宠物的大小
            cur_house = houses[h_index];
            playtime = 1;//默认时长1分钟
            difficult = 1;//默认难度值为简单=1
            score = 0;//得分默认为零
            flag = false;//默认并未进行搬家活动
            flag2 = true;//默认可以搬家
        }
        public Point CUR_HOUSE
        {
            get { return cur_house; }
        }
        public int PLAYTIME
        {
            get { return playtime; }
            set
            {
                Regex r = new Regex(@"^[1-9]\d*$");
                if (r.IsMatch(value.ToString())) playtime = value;
                else MessageBox.Show("游戏时长只能赋值为正数");
            }
        }

        public int DIFFICULT
        {
            get { return difficult; }
            set
            {
                Regex r = new Regex(@"^[1-9]\d*$");
                if (r.IsMatch(value.ToString())) difficult = value;
                else MessageBox.Show("游戏难度值不合法");
            }
        }
        public Image PET
        {
            get { return pet; }
            set { pet = value; }
        }
        public int PET_INDEX
        {
            get { return pet_index; }
            set
            {
                Regex r = new Regex(@"^\d+$");
                if (r.IsMatch(value.ToString())) pet_index = value;
                else MessageBox.Show("索引属性值不合法");
            }
        }
        public int SCORE
        {
            get { return score; }
            set
            {
                Regex r = new Regex(@"^\d+$");
                if (r.IsMatch(value.ToString())) score = value;
                else MessageBox.Show("得分数据不合法");
            }
        }
        public bool FLAG
        {
            get { return flag; }
        }
        public void change_house()
        {
            Random r = new Random((int)DateTime.Now.Millisecond);
            int i;
            i = r.Next(0, houses.Length);
            if (cur_house.Equals(houses[i]))
                i = (i + 2) % houses.Length;
            cur_house = houses[i];
        }

        public bool do_run(int x, int y)
        {
            int d = 30 * difficult;
            if (x > cur_house.X - d && x < cur_house.X + pet_size.Width + d &&
                y > cur_house.Y - d && y < cur_house.Y + pet_size.Height + d)
            {
                flag = true;
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                while (dt.AddSeconds(0.3 / difficult) > DateTime.Now)
                {
                    Application.DoEvents();
                }
                if (flag2 == true)
                {
                    change_house();
                    flag = false;
                    return true;
                }
                else
                {
                    flag = false;
                    flag2 = true;
                }
            }
            return false;
        }
        public void catched()
        {
            score += 10;
            change_house();
            flag2 = false;
        }


    }//class
}
