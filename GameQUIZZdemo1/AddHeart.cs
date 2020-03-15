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
namespace GameQUIZZdemo1
{
     public partial class AddHeart : Form
     {
          public int surNum;
          public string name = "";
          public int point = 0;
          public AddHeart(int surNum1 = 10, string nameClient = "", int pointClient = 0)
          {
               InitializeComponent();
               surNum = surNum1;               
               name = nameClient;//lấy tên người chơi
               point = pointClient;
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
          private void timer1_Tick(object sender, EventArgs e)
          {
               prMang.Step = -1;
               prMang.PerformStep();
          }

          private void button1_Click(object sender, EventArgs e)
          {
               timer1.Start();
               if(prMang.Value==100)
               {
                    timer1.Stop();
                    DialogResult dlr= MessageBox.Show("Bạn đã được thêm 3 mạng!", "Thông báo",MessageBoxButtons.OK);
                    if(dlr==DialogResult.OK)
                    {
                         surNum += 3;//thêm 3 mạng                         
                         updateDB();//update cơ sở dữ liệu                  
                         this.Close();
                         
                    }
               }
               prMang.Step = 10;
               prMang.PerformStep();
          }
     }
}
