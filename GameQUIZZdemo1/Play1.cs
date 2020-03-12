using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace GameQUIZZdemo1
{
     public partial class Play1 : Form
     {
          private int count = 0;
          public int surNum ;
          public string name = "";
          public int point = 0;
          public int SurNum { get => surNum; set => surNum = value; }

          public Play1(int surNum1=60,string nameClient="",int pointClient=0)
          {
               InitializeComponent();         
               surNum = surNum1;
               labelSurvive.Text = surNum.ToString();
               name = nameClient;//lấy tên người chơi
               point = pointClient;
               lbPoint.Text = point.ToString();//ghi điểm
          }
          SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6DIRH3U\SQLEXPRESS01;Initial Catalog=GameQuizz;Integrated Security=True");
          public void updateDB()//cập nhật vào database
          {
               //sau mỗi lần chơi sẽ cập nhật lại cơ sở dữ liệu
               string sql = "select * from UserInfo";//THỰC HIỆN lệnh truy vấn đén sql 
               SqlCommand cmd = new SqlCommand(sql, connect);
               cmd.CommandType = CommandType.Text;
               SqlDataAdapter da = new SqlDataAdapter(cmd);//lưu dữ liệu lấy được vào đây
               string sSql = "UPDATE UserInfo SET soMang=" + surNum + ",soDiem="+point+" WHERE user_name='" + name + "'";
               da.InsertCommand = new SqlCommand(sSql, connect);
               connect.Open();
               da.InsertCommand.ExecuteNonQuery();
               connect.Close();
          }
          private void timer1_Tick(object sender, EventArgs e)
          {
               count++;// biến đếm tăng sau mỗi giây
               if(count==1)// sau khi được 1s thì sẽ tắt thông báo 
               {
                    pWrong.Visible = false;
                    pTrue1.Visible = false;
               }
               timer1.Enabled = false;//tắt bộ đếm
               count = 0;//reset lại biến đếm cho vognf lặp tiếp theo
          }

         
          private void panel2_Paint(object sender, PaintEventArgs e)
          {

          }

          private void bNext_Click(object sender, EventArgs e)
          {
               point += 10;
               updateDB();
               //insert dữ liệu
               this.Hide();
               Play2 play = new Play2(surNum,name,point);
               play.ShowDialog();
               this.Close();
          }

          
          private void button3_Click(object sender, EventArgs e)//nút restart
          {          
               DialogResult dlr= MessageBox.Show("Do you want to restart?", "Restart",MessageBoxButtons.YesNo);
               if(dlr==DialogResult.Yes)//đồng ý thì reset lại màn chơi
               {
                    this.Hide();
                    Play1 play = new Play1(surNum,name,point);
                    play.ShowDialog();
                    this.Close();
               }
               
          }

          private void label3_Click(object sender, EventArgs e)
          {

          }

          private void button2_Click(object sender, EventArgs e)//nút home 
          {
               this.Hide();
               Form1 play = new Form1();
               play.ShowDialog();
               this.Close();
          }

          private void button4_Click(object sender, EventArgs e)//nút chuyển qua câu tiếp theo
          {
               DialogResult dlr = MessageBox.Show("Bỏ qua thử thách sẽ tốn 2 mạng. Có hay không?", "Warning", MessageBoxButtons.OK);
               if (dlr == DialogResult.OK)//đồng ý thì reset lại màn chơi
               {                   
                    surNum -=2;//số mạng sống trừ đi 2
                    point += 10;
                    updateDB();
                    this.Hide();
                    Play2 play = new Play2(surNum,name,point);
                    play.ShowDialog();
                    this.Close();                   
               }
          }

          private void button1_Click_1(object sender, EventArgs e)//gợi ý
          {
               DialogResult dlr = MessageBox.Show("WaterMelon <3", "Đáp án", MessageBoxButtons.OK);
               if (dlr == DialogResult.OK)//đồng ý thì reset lại màn chơi
               {
                    surNum -= 1;//số mạng sống trừ đi 1
                    labelSurvive.Text = Convert.ToString(surNum);
               }
          }

          private void Play1_MouseClick(object sender, MouseEventArgs e)
          {
               pWrong.Visible = true;
               pWrong.Location = new Point(e.X-25, e.Y-30);//con trỏ ấn thì dấu X sẽ hiện lên ở vị trí trugn tâm
               timer1.Start();
          }

          private void p1_Click(object sender, EventArgs e)
          {
               pWrong.Visible = true;
               pWrong.Location = new Point(50,287);
               timer1.Start();
          }

          private void p3_Click(object sender, EventArgs e)
          {
               pWrong.Visible = true;
               pWrong.Location = new Point(160,456);
               timer1.Start();
          }

          private void p4_Click(object sender, EventArgs e)
          {
               pWrong.Visible = true;
               pWrong.Location = new Point(400,440);
               timer1.Start();
          }

          private void p2_Click(object sender, EventArgs e)
          {
               pTrue1.Visible = true;
               pTrue1.Location = new Point(407, 222);
               timer1.Start();
               pTrue.Visible = true;
               pTrue.Location = new Point(0, 60);
               pTrue.Size = new Size(582,544);
          }

          private void Play1_Load(object sender, EventArgs e)
          {
               

          }
         
          private void bStastic_Click(object sender, EventArgs e)
          {
               List<int> point = new List<int>();
               pStastic.Location = new Point(76, 0);              
               pStastic.Visible = true;
               pStastic.Size = new Size(409, 259);
               connect.Open();
               string sql = "select UserInfo.user_name,UserInfo.soDiem from UserInfo";//THỰC HIỆN lệnh truy vấn đén sql  
               SqlCommand cmd = new SqlCommand(sql, connect);
               cmd.CommandType = CommandType.Text;
               SqlDataAdapter da = new SqlDataAdapter(cmd);//lưu dữ liệu lấy được vào đây
               DataTable dt = new DataTable();//tạo 1 kho dữ liệu ảo
               da.Fill(dt);// đổ dữ liệu vào kho               
               connect.Close();
               //int CompareTo(int x,int y)
               //{
               //     if (x > y)
               //          return 1;
               //     else if (x <y)
               //          return -1;
               //     return 0;
               //}
               if (dt != null)
               {
                    foreach (DataRow dr in dt.Rows)
                    {                       
                         point.Add(int.Parse(dr["soDiem"].ToString()));
                    }
               }
               int length = point.Count();
               point.Sort();
               int numTop1 = 0;
               int numTop2 = 0;
               //hàm dưới đây tức là xét xem số điểm ai cao nhất sẽ xếp trước, và cho 1 biến đếm chạyh, và nó chỉ duyệt qua
               //1 lần mà thôi, để tranh hiện tượng lặp lại người

               foreach (DataRow dr in dt.Rows)
               {
                    if(int.Parse(dr["soDiem"].ToString())== int.Parse(point[length - 1].ToString())&&numTop1!=1)
                    {
                         top1.Text = dr["user_name"].ToString() + "(" + point[length - 1].ToString() + ")";
                         numTop1++;
                         continue;
                    }
                    else if(int.Parse(dr["soDiem"].ToString()) == int.Parse(point[length - 2].ToString())&&numTop2!=1)
                    {
                         top2.Text = dr["user_name"].ToString() + "(" + point[length - 2].ToString() + ")";
                         numTop2++;
                         continue;
                    }
                    else if(int.Parse(dr["soDiem"].ToString()) == int.Parse(point[length - 3].ToString()))
                    {
                         top3.Text = dr["user_name"].ToString() + "(" + point[length - 3].ToString() + ")";
                         continue;
                    }
               }
               
               
          }

          private void button5_Click(object sender, EventArgs e)
          {
               pStastic.Visible = false;
          }

          private void button7_Click(object sender, EventArgs e)//hệ thống câu hỏi
          {
               MenuQues.Size = new Size(475,166);
               MenuQues.Location = new Point(74,68);
               textBox1.Size = new Size(89,77);
               textBox2.Size = new Size(89, 77);
               textBox3.Size = new Size(89, 77);
               textBox4.Size = new Size(89, 77);
               textBox5.Size = new Size(89, 77);
               textBox6.Size = new Size(89, 77);
               textBox7.Size = new Size(89, 77);
               textBox8.Size = new Size(89, 77);
               textBox9.Size = new Size(89, 77);
               textBox10.Size = new Size(89, 77);
               MenuQues.Visible = true;
          }

          private void textBox1_Click(object sender, EventArgs e)//click vào câu 1 thì sẽ ẩn đi
          {
               MenuQues.Visible = false;
          }
     }
}
