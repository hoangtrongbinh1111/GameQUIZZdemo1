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
     public partial class Play8 : Form
     {
          public int surNum;//số mạng
          public string name = "";//tên ng chơi
          public int point = 0;
          public Play8(int surNum1 = 60, string nameClient = "", int pointClient = 0)
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
     }
}
