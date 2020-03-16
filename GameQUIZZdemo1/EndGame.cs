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
     public partial class EndGame : Form
     {
          string name = "";
          public bool soundMode;
          public EndGame(string name1 = "", bool sound = true)
          {
               InitializeComponent();
               name = name1;
               soundMode = sound;
          }

          private void button1_Click(object sender, EventArgs e)
          {
               if (soundMode == true)
               {
                    SoundPlayer sp = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.CLick);
                    sp.Play();
               }
               SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-6DIRH3U\SQLEXPRESS01;Initial Catalog=GameQuizz;Integrated Security=True");
               string sql = "select * from UserInfo";//THỰC HIỆN lệnh truy vấn đén sql 
               SqlCommand cmd = new SqlCommand(sql, connect);
               cmd.CommandType = CommandType.Text;
               SqlDataAdapter da = new SqlDataAdapter(cmd);//lưu dữ liệu lấy được vào đây
               string sSql = "UPDATE UserInfo SET soMang=" + 10 + ",soDiem=" + 10 + " WHERE user_name='" + name + "'";
               da.InsertCommand = new SqlCommand(sSql, connect);
               connect.Open();
               da.InsertCommand.ExecuteNonQuery();
               connect.Close();

               this.Hide();
               Form1 play = new Form1();
               play.ShowDialog();
               this.Close();
          }

          private void EndGame_Load(object sender, EventArgs e)
          {
               if (soundMode == true)
               {
                    SoundPlayer sp = new SoundPlayer(GameQUIZZdemo1.Properties.Resources.happyyyy);
                    sp.Play();
               }
          }
     }
}
