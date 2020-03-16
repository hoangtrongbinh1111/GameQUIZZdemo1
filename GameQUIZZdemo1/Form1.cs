using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.SqlClient;

namespace GameQUIZZdemo1
{
    
     public partial class Form1 : Form
     {
          //tạo kết nối
          SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6DIRH3U\SQLEXPRESS01;Initial Catalog=GameQuizz;Integrated Security=True");
          public Form1()
          {
               InitializeComponent();
               //Water mark
               tbName.ForeColor = Color.LightGray;
               tbName.Text = "Enter your name";
               this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
               this.tbName.Enter += new System.EventHandler(this.tbName_Enter);
          }
          
          private void tbName_Leave(object sender,EventArgs e)
          {
               if(tbName.Text=="")
               {
                    tbName.Text = "Enter your name";
                    tbName.ForeColor = Color.Gray;
               }
          }

          private void tbName_Enter(object sender, EventArgs e)
          {
               if (tbName.Text == "Enter your name")
               {
                    tbName.Text = "";
                    tbName.ForeColor = Color.Black;
               }
          }

          private void bPlay_Click(object sender, EventArgs e)
          {
               if(soundMode==true)
               {
                    SoundPlayer sound = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.CLick);
                    sound.Play();
               } 
               string name = "";//tên người chơi
               int round = 0;//só vòng chơi
               
               connect.Open();
               string sql = "select * from UserInfo";//THỰC HIỆN lệnh truy vấn đén sql  
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
                         name = dr["user_name"].ToString();
                         if (tbName.Text == name)
                         {                              
                              round = int.Parse(dr["soDiem"].ToString());// chọn số vòng chơi                           
                              ManChoi(round,int.Parse(dr["soMang"].ToString()),name);//nhảy đến vòng chơi đó
                              goto endd;
                         }
                    }                    
                    //thêm người chơi vào cơ sở dữ liệu                   
                    string sSql = "INSERT INTO UserInfo VALUES ('" + tbName.Text + "',N'" + 10 + "',N'" + 60 + "')";
                    da.InsertCommand = new SqlCommand(sSql, connect);
                    connect.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    connect.Close();
                    ManChoi(10,60,tbName.Text);//nếu chưa có tên nào lưu thì bắt đầu lượt mới
                                      
               }
          endd:
               return;
          }
          private void Scene(Form f)//chuyển màn 
          {
               this.Hide();               
               f.ShowDialog();
               this.Close();
          }
          private void ManChoi(int round,int soMang,string name)//màn chơi
          {
               switch(round)
               {
                    case 10:
                         Play1 pl1 = new Play1(soMang,name,round,soundMode);//số mạng,tên, và số điểm
                         Scene(pl1);
                         break;
                    case 20:
                         Play2 pl2 = new Play2(soMang,name,round, soundMode);
                         Scene(pl2);
                         break;
                    case 30:
                         Play3 pl3 = new Play3(soMang, name, round, soundMode);
                         Scene(pl3);
                         break;
                    case 40:
                         Play4 pl4 = new Play4(soMang, name, round, soundMode);
                         Scene(pl4);
                         break;
                    case 50:
                         Play5 pl5 = new Play5(soMang, name, round, soundMode);
                         Scene(pl5);
                         break;
                    case 60:
                         Play6 pl6 = new Play6(soMang, name, round, soundMode);
                         Scene(pl6);
                         break;
                    case 70:
                         Play7 pl7 = new Play7(soMang, name, round, soundMode);
                         Scene(pl7);
                         break;
                    case 80:
                         Play8 pl8 = new Play8(soMang, name, round, soundMode);
                         Scene(pl8);
                         break;
                    case 90:
                         Play9 pl9 = new Play9(soMang, name, round, soundMode);
                         Scene(pl9);
                         break;
                    case 100:
                         Play10 pl10 = new Play10(soMang, name, round, soundMode);
                         Scene(pl10);
                         break;
                    default:
                         EndGame eg = new EndGame(name, soundMode);
                         Scene(eg);
                         break;
               }
          }
          private void Form1_Load(object sender, EventArgs e)
          {
               if (soundMode == true)
               {
                    SoundPlayer sound = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.background_music);
                    sound.Play();
               }
          }

          private void pStatic_Click(object sender, EventArgs e)
          {

          }
          int countInfo = 0;//nếu số lần lẻ thì hướng dãn xuất hiện, chẵn thì biến mất
          private void bInstruct_Click(object sender, EventArgs e)
          {
               if (soundMode == true)
               {
                    SoundPlayer sound = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.click2);
                    sound.Play();
               }
               countInfo++;
               if (countInfo % 2 == 1)
               {
                    pInstruct.Visible = true;
                    pInstruct.Location = new Point(81, 24);
                    pInstruct.Size = new Size(477, 562);
               }
               else
                    pInstruct.Visible = false;
               
          }

          bool soundMode = true;//âm thanh bật tắt. true là bật. false là tắt
          private void bLoud_Click(object sender, EventArgs e)
          {
               if (soundMode == true)
               {
                    SoundPlayer sound = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.click2);
                    sound.Play();
               }
               bLoud.Visible = false;
               bMute.Visible = true;
               soundMode = false;//tắt âm
          }

          private void bMute_Click(object sender, EventArgs e)
          {
               if (soundMode == true)
               {
                    SoundPlayer sound = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.click2);
                    sound.Play();
               }
               bMute.Visible = false;
               bLoud.Visible = true;
               soundMode = true;//bật âm
          }
     }
}
