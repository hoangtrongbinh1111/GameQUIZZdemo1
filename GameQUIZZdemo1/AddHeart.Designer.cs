namespace GameQUIZZdemo1
{
     partial class AddHeart
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.components = new System.ComponentModel.Container();
               this.prMang = new System.Windows.Forms.ProgressBar();
               this.timer1 = new System.Windows.Forms.Timer(this.components);
               this.button1 = new System.Windows.Forms.Button();
               this.label1 = new System.Windows.Forms.Label();
               this.SuspendLayout();
               // 
               // prMang
               // 
               this.prMang.Location = new System.Drawing.Point(34, 132);
               this.prMang.Name = "prMang";
               this.prMang.Size = new System.Drawing.Size(538, 57);
               this.prMang.Step = 5;
               this.prMang.TabIndex = 0;
               // 
               // timer1
               // 
               this.timer1.Interval = 200;
               this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
               // 
               // button1
               // 
               this.button1.Location = new System.Drawing.Point(244, 237);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(75, 41);
               this.button1.TabIndex = 1;
               this.button1.Text = "Push";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new System.EventHandler(this.button1_Click);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label1.Location = new System.Drawing.Point(32, 45);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(540, 62);
               this.label1.TabIndex = 2;
               this.label1.Text = "Hãy ấn thật nhanh đến khi thanh lực đủ 100!\r\n\r\n";
               // 
               // AddHeart
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(584, 301);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.button1);
               this.Controls.Add(this.prMang);
               this.Name = "AddHeart";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "AddHeart";
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.ProgressBar prMang;
          private System.Windows.Forms.Timer timer1;
          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.Label label1;
     }
}