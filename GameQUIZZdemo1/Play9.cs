﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace GameQUIZZdemo1
{
     public partial class Play9 : Form
     {
          public int surNum;//số mạng
          public string name = "";//tên ng chơi
          public int point = 0;
          public Play9(int surNum1 = 60, string nameClient = "", int pointClient = 0)
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
               string sSql = "UPDATE UserInfo SET soMang=" + surNum + ",soDiem=" + point + " WHERE user_name='" + name + "'";
               da.InsertCommand = new SqlCommand(sSql, connect);
               connect.Open();
               da.InsertCommand.ExecuteNonQuery();
               connect.Close();
          }

          private void textBox9_Click(object sender, EventArgs e)
          {
               MenuQues.Visible = false;
          }
          int count = 0;
          private void timer1_Tick(object sender, EventArgs e)
          {
               count++;
               if (count == 20)//2 giây thì bắt đầu mở panel submit
               {
                    pTrue.Location = new Point(0, 60);
                    pTrue.Visible = true;
                    pTrue.Size = new Size(582, 544);
                    Congra();
               }
          }
          private void bHome_Click(object sender, EventArgs e)
          {
               this.Hide();
               Form1 play = new Form1();
               play.ShowDialog();
               this.Close();
          }
          private void bRes_Click(object sender, EventArgs e)//restart
          {
               DialogResult dlr = MessageBox.Show("Bỏ qua thử thách sẽ tốn 2 mạng. Có hay không?", "Warning", MessageBoxButtons.YesNo);
               if (dlr == DialogResult.Yes)//đồng ý thì sẽ chuyển sang câu tiếp theo
               {
                    if (surNum <= 2)//nếu mạng mà nhỏ hơn or bằng 2 thì phải thêm mạng
                    {
                         MessageBox.Show("Bạn phải thêm mạng để tiếp tục chơi!", "Warning", MessageBoxButtons.OK);
                         AddHeart ah = new AddHeart(surNum, name, point);
                         ah.ShowDialog();
                         surNum += 3;
                         labelSurvive.Text = surNum.ToString();
                    }
                    else
                    {
                         surNum -= 2;//số mạng sống trừ đi 2
                         point += 10;
                         updateDB();
                         this.Hide();
                         Play10 play = new Play10(surNum, name, point);
                         play.ShowDialog();
                         this.Close();
                    }
               }
          }

          private void bNextControl_Click(object sender, EventArgs e)
          {
               DialogResult dlr = MessageBox.Show("Bỏ qua thử thách sẽ tốn 2 mạng. Có hay không?", "Warning", MessageBoxButtons.OK);
               if (dlr == DialogResult.OK)//đồng ý thì reset lại màn chơi
               {
                    point += 10;
                    surNum -= 2;//số mạng sống trừ đi 2
                    updateDB();
                    this.Hide();
                    Play10 play = new Play10(surNum, name, point);
                    play.ShowDialog();
                    this.Close();
               }
          }
          int countInstruct = 0;//để ấn button 1 lần thôi
          int countReturn = 0;//dùng để ấn lại câu hướng dẫn
          private void bInstruct_Click(object sender, EventArgs e)
          {
               countInstruct++;
               if (countInstruct == 1)
               {
                    if (surNum == 0)
                    {
                         countReturn++;
                         MessageBox.Show("Bạn phải thêm mạng để tiếp tục chơi!", "Warning", MessageBoxButtons.OK);
                         AddHeart ah = new AddHeart(surNum, name, point);
                         ah.ShowDialog();
                         surNum += 3;
                         labelSurvive.Text = surNum.ToString();
                    }
                    else
                    {
                         surNum--;
                         labelSurvive.Text = Convert.ToString(surNum);
                         MessageBox.Show("Hãy ấn vào nút công tắc TV để tắt", "Đáp án", MessageBoxButtons.OK);
                    }
               }
               else if (countInstruct == 2 && countReturn == 1)
               {
                    MessageBox.Show("Hãy ấn vào nút công tắc TV để tắt", "Đáp án", MessageBoxButtons.OK);
                    surNum--;
                    labelSurvive.Text = Convert.ToString(surNum);
               }
               else
               {
                    MessageBox.Show("Hãy ấn vào nút công tắc TV để tắt", "Đáp án", MessageBoxButtons.OK);
               }
          }

          private void bShowQues_Click(object sender, EventArgs e)
          {
               MenuQues.Size = new Size(475, 166);
               MenuQues.Location = new Point(74, 68);
               textBox11.Size = new Size(89, 77);
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

          private void bNext_Click(object sender, EventArgs e)
          {
               if (surNum == 0)
               {
                    MessageBox.Show("Bạn phải thêm mạng để tiếp tục chơi!", "Warning", MessageBoxButtons.OK);
                    AddHeart ah = new AddHeart(surNum, name, point);
                    ah.ShowDialog();
                    surNum += 3;
                    labelSurvive.Text = surNum.ToString();
               }
               else
               {
                    point += 10;
                    updateDB();
                    //insert dữ liệu
                    this.Hide();
                    Play10 play = new Play10(surNum, name, point);
                    play.ShowDialog();
                    this.Close();
               }
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
                    if (int.Parse(dr["soDiem"].ToString()) == int.Parse(point[length - 1].ToString()) && numTop1 != 1)
                    {
                         top1.Text = dr["user_name"].ToString() + "(" + point[length - 1].ToString() + ")";
                         numTop1++;
                         continue;
                    }
                    else if (int.Parse(dr["soDiem"].ToString()) == int.Parse(point[length - 2].ToString()) && numTop2 != 1)
                    {
                         top2.Text = dr["user_name"].ToString() + "(" + point[length - 2].ToString() + ")";
                         numTop2++;
                         continue;
                    }
                    else if (int.Parse(dr["soDiem"].ToString()) == int.Parse(point[length - 3].ToString()))
                    {
                         top3.Text = dr["user_name"].ToString() + "(" + point[length - 3].ToString() + ")";
                         continue;
                    }
               }
          }

          private void button6_Click(object sender, EventArgs e)
          {
               pStastic.Visible = false;
          }

          private void button1_Click(object sender, EventArgs e)//nút button tắt con ma đi
          {
               timer1.Start();
               pbTelevision.Visible = false;
               pbTel1.Location = new Point(138,176);
               pbTel1.Size = new Size(281,303);
               pbTel1.Visible = true;
               tbQues.Text = "Hooray đuổi được con ma rồi!";
          }

          private void pictureBox3_Click(object sender, EventArgs e)
          {
               tbQues.Text = "Ma không sợ búa!";
          }

          private void pictureBox4_Click(object sender, EventArgs e)
          {
               tbQues.Text = "Ma không sợ cây thánh giá!";
          }

          private void pictureBox5_Click(object sender, EventArgs e)
          {
               tbQues.Text = "Ma không sợ súng!";
          }

          private void btnAddHeart_Click(object sender, EventArgs e)//thêm mạng
          {
               if (surNum == 0)//nếu hết mạng thì mới cho sự trợ giúp
               {
                    AddHeart ah = new AddHeart(surNum, name, point);
                    ah.ShowDialog();
               }
               else
               {
                    MessageBox.Show("Hết mạng mới được thêm mạng", "Thông báo", MessageBoxButtons.OK);
               }

          }

          public void Congra()//các câu chúc mừng
          {
               int random;
               Random rd = new Random();
               random = rd.Next(1, 10);
               switch (random)
               {
                    case 1:
                         label3.Text = "You are so good";
                         break;
                    case 2:
                         label3.Text = "Good business";
                         break;
                    case 3:
                         label3.Text = "All the best.";
                         break;
                    case 4:
                         label3.Text = "Dream Big. Shine Bright.";
                         break;
                    case 5:
                         label3.Text = "I believe in you";
                         break;
                    case 6:
                         label3.Text = "Good job....";
                         break;
                    case 7:
                         label3.Text = "prettyyyyyyyyy";
                         break;
                    case 8:
                         label3.Text = "Come on go go....";
                         break;
                    case 9:
                         label3.Text = "Much Funnnn ???";
                         break;
                    case 10:
                         label3.Text = "Success and success..";
                         break;
               }
          }
     }
}