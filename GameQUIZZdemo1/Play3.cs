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
     public partial class Play3 : Form
     {
          public int surNum;//số mạng
          public string name = "";//tên ng chơi
          public int point = 0;
          public Play3(int surNum1 = 60, string nameClient = "", int pointClient = 0)
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
          private void bDec_Click(object sender, EventArgs e)//giảm đi 1 đơn vị
          {
               int ans=0;
               ans = int.Parse(lbAns.Text);
               if (ans <= 0)
                    ans = 0;
               else
                    ans--;
               lbAns.Text = ans.ToString();
          }

          private void bInc_Click(object sender, EventArgs e)//tăng số hình lên 1 đvi
          {
               int ans = 0;
               ans = int.Parse(lbAns.Text);
               ans++;
               lbAns.Text = ans.ToString();
          }

          private void bDel_Click(object sender, EventArgs e)//del đi số hình
          {
               lbAns.Text = "0";
          }

          private void bSubmit_Click(object sender, EventArgs e)
          {
               if (lbAns.Text == "5")//nếu đáp án đúng
               {
                    pTrue.Location = new Point(0, 60);
                    pTrue.Visible = true;
                    pTrue.Size = new Size(582, 544);
               }
               else//ko thì reset lại câu trả lời
               {
                    lbAns.Text = "0";
               }
          }

          private void bNext_Click(object sender, EventArgs e)//next câu tiếp
          {
               point += 10;
               updateDB();
               //insert dữ liệu
               this.Hide();
               Play4 play = new Play4(surNum, name,point);
               play.ShowDialog();
               this.Close();
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

          private void button6_Click(object sender, EventArgs e)//return
          {
               pStastic.Visible = false;
          }

          private void bHome_Click(object sender, EventArgs e)
          {
               this.Hide();
               Form1 play = new Form1();
               play.ShowDialog();
               this.Close();
          }

          private void bRes_Click(object sender, EventArgs e)
          {
               DialogResult dlr = MessageBox.Show("Do you want to restart?", "Restart", MessageBoxButtons.YesNo);
               if (dlr == DialogResult.Yes)//đồng ý thì reset lại màn chơi
               {
                    this.Hide();
                    Play3 play = new Play3(surNum, name,point);
                    play.ShowDialog();
                    this.Close();
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
                    Play4 play = new Play4(surNum, name, point);
                    play.ShowDialog();
                    this.Close();
               }
          }

          private void bInstruct_Click(object sender, EventArgs e)
          {
               DialogResult dlr = MessageBox.Show("Số hình là 22", "Đáp án", MessageBoxButtons.OK);
               if (dlr == DialogResult.OK)//đồng ý thì reset lại màn chơi
               {
                    surNum -= 1;//số mạng sống trừ đi 2
                    labelSurvive.Text = Convert.ToString(surNum);
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

          private void textBox3_Click(object sender, EventArgs e)
          {
               MenuQues.Visible = false;
          }
     }
}
