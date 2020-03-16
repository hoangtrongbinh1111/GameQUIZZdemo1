using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;
namespace GameQUIZZdemo1
{
     public partial class Play6 : Form
     {
          public int surNum;//số mạng
          public string name = "";//tên ng chơi
          public int point = 0;
          public bool soundMode;
          public Play6(int surNum1 = 60, string nameClient = "", int pointClient = 0,bool sound=true)
          {
               InitializeComponent();
               surNum = surNum1;
               labelSurvive.Text = surNum.ToString();
               name = nameClient;//lấy tên người chơi
               point = pointClient;
               lbPoint.Text = point.ToString();//ghi điểm
               Text = "Màn 6 - Player: " + name;//ghi tên vòng với tên người chơi
               soundMode = sound;
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

          private void pictureBox7_Click(object sender, EventArgs e)//miếng dưa hấu được chọn
          {
               Sound(4);
               //hiện bảng submit
               pTrue.Location = new Point(0, 60);
               pTrue.Visible = true;
               pTrue.Size = new Size(582, 544);
               Congra();
          }
          private Point MouseDownLocation;

          private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    MouseDownLocation = e.Location;
               }
          }

          private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    pictureBox4.Left = e.X + pictureBox4.Left - MouseDownLocation.X;
                    pictureBox4.Top = e.Y + pictureBox4.Top - MouseDownLocation.Y;
               }
          }
          private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    MouseDownLocation = e.Location;
               }
          }

          private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    pictureBox1.Left = e.X + pictureBox1.Left - MouseDownLocation.X;
                    pictureBox1.Top = e.Y + pictureBox1.Top - MouseDownLocation.Y;
               }
          }
          private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    MouseDownLocation = e.Location;
               }
          }

          private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    pictureBox3.Left = e.X + pictureBox3.Left - MouseDownLocation.X;
                    pictureBox3.Top = e.Y + pictureBox3.Top - MouseDownLocation.Y;
               }
          }
          private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    MouseDownLocation = e.Location;
               }
          }

          private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    pictureBox6.Left = e.X + pictureBox6.Left - MouseDownLocation.X;
                    pictureBox6.Top = e.Y + pictureBox6.Top - MouseDownLocation.Y;
               }
          }
          private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    MouseDownLocation = e.Location;
               }
          }

          private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    pictureBox5.Left = e.X + pictureBox5.Left - MouseDownLocation.X;
                    pictureBox5.Top = e.Y + pictureBox5.Top - MouseDownLocation.Y;
               }
          }
          private void pictureBox8_MouseDown(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    MouseDownLocation = e.Location;
               }
          }

          private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
          {
               if (e.Button == System.Windows.Forms.MouseButtons.Left)
               {
                    pictureBox8.Left = e.X + pictureBox8.Left - MouseDownLocation.X;
                    pictureBox8.Top = e.Y + pictureBox8.Top - MouseDownLocation.Y;
               }
          }

          private void textBox6_Click(object sender, EventArgs e)//câu 6
          {
               Sound(3);
               MenuQues.Visible = false;
          }

          private void bHome_Click(object sender, EventArgs e)
          {
               Sound(3);
               this.Hide();
               Form1 play = new Form1();
               play.ShowDialog();
               this.Close();
          }
          private void bRes_Click(object sender, EventArgs e)//restart
          {
               Sound(3);
               DialogResult dlr = MessageBox.Show("Do you want to restart?", "Restart", MessageBoxButtons.YesNo);
               if (dlr == DialogResult.Yes)//đồng ý thì reset lại màn chơi
               {
                    this.Hide();
                    Play6 play = new Play6(surNum, name, point, soundMode);
                    play.ShowDialog();
                    this.Close();
               }
          }

          private void bNextControl_Click(object sender, EventArgs e)
          {
               Sound(3);
               DialogResult dlr = MessageBox.Show("Bỏ qua thử thách sẽ tốn 2 mạng. Có hay không?", "Warning", MessageBoxButtons.YesNo);
               if (dlr == DialogResult.Yes)//đồng ý thì sẽ chuyển sang câu tiếp theo
               {
                    if (surNum <= 2)//nếu mạng mà nhỏ hơn or bằng 2 thì phải thêm mạng
                    {
                         MessageBox.Show("Bạn phải thêm mạng để tiếp tục chơi!", "Warning", MessageBoxButtons.OK);
                         AddHeart ah = new AddHeart(surNum, name, point, soundMode);
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
                         Play7 play = new Play7(surNum, name, point, soundMode);
                         play.ShowDialog();
                         this.Close();
                    }
               }
          }
          int countInstruct = 0;//để ấn button 1 lần thôi
          int countReturn = 0;//dùng để ấn lại câu hướng dẫn
          private void bInstruct_Click(object sender, EventArgs e)
          {
               Sound(3);
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
                         MessageBox.Show("Kéo các miếng dưa háu ra sẽ thấy", "Đáp án", MessageBoxButtons.OK);
                    }
               }
               else if (countInstruct == 2 && countReturn == 1)
               {
                    MessageBox.Show("Kéo các miếng dưa háu ra sẽ thấy", "Đáp án", MessageBoxButtons.OK);
                    surNum--;
                    labelSurvive.Text = Convert.ToString(surNum);
               }
               else
               {
                    MessageBox.Show("Kéo các miếng dưa háu ra sẽ thấy", "Đáp án", MessageBoxButtons.OK);
               }
          }

          private void bShowQues_Click(object sender, EventArgs e)
          {
               Sound(3);
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
               Sound(3);
               if (surNum == 0)
               {
                    MessageBox.Show("Bạn phải thêm mạng để tiếp tục chơi!", "Warning", MessageBoxButtons.OK);
                    AddHeart ah = new AddHeart(surNum, name, point, soundMode);
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
                    Play7 play = new Play7(surNum, name, point, soundMode);
                    play.ShowDialog();
                    this.Close();
               }
          }

          private void bStastic_Click(object sender, EventArgs e)
          {
               Sound(3);
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
               Sound(3);
               pStastic.Visible = false;
          }

          private void btnAddHeart_Click(object sender, EventArgs e)//thêm mạng
          {
               Sound(3);
               if (surNum == 0)//nếu hết mạng thì mới cho sự trợ giúp
               {
                    AddHeart ah = new AddHeart(surNum, name, point, soundMode);
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

          private void Sound(int mode)
          {
               if (soundMode == true)
               {
                    if (mode == 1)//âm thanh sai
                    {
                         SoundPlayer s = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.wrong_21);
                         s.Play();
                    }
                    else if (mode == 2)//âm thanh đúng
                    {
                         SoundPlayer s = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.true_ans_3);
                         s.Play();
                    }
                    else if (mode == 3)//âm thanh click
                    {
                         SoundPlayer s = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.click3);
                         s.Play();
                    }
                    else if (mode == 4)//chúc mừng
                    {
                         SoundPlayer s = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.congra);
                         s.Play();
                    }
               }
          }
     }
}
