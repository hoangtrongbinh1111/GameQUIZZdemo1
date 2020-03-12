namespace GameQUIZZdemo1
{
     partial class Form1
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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
               this.pictureBox1 = new System.Windows.Forms.PictureBox();
               this.bPlay = new System.Windows.Forms.Button();
               this.bInstruct = new System.Windows.Forms.Button();
               this.button1 = new System.Windows.Forms.Button();
               this.tbName = new System.Windows.Forms.TextBox();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
               this.SuspendLayout();
               // 
               // pictureBox1
               // 
               this.pictureBox1.Location = new System.Drawing.Point(-23, -46);
               this.pictureBox1.Name = "pictureBox1";
               this.pictureBox1.Size = new System.Drawing.Size(16, 49);
               this.pictureBox1.TabIndex = 1;
               this.pictureBox1.TabStop = false;
               // 
               // bPlay
               // 
               this.bPlay.BackColor = System.Drawing.Color.Transparent;
               this.bPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bPlay.BackgroundImage")));
               this.bPlay.Location = new System.Drawing.Point(184, 475);
               this.bPlay.Name = "bPlay";
               this.bPlay.Size = new System.Drawing.Size(223, 74);
               this.bPlay.TabIndex = 2;
               this.bPlay.UseVisualStyleBackColor = false;
               this.bPlay.Click += new System.EventHandler(this.bPlay_Click);
               // 
               // bInstruct
               // 
               this.bInstruct.Location = new System.Drawing.Point(22, 26);
               this.bInstruct.Name = "bInstruct";
               this.bInstruct.Size = new System.Drawing.Size(75, 23);
               this.bInstruct.TabIndex = 4;
               this.bInstruct.Text = "Hướng dẫn";
               this.bInstruct.UseVisualStyleBackColor = true;
               // 
               // button1
               // 
               this.button1.Location = new System.Drawing.Point(443, 44);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(75, 23);
               this.button1.TabIndex = 5;
               this.button1.Text = "cài đặt";
               this.button1.UseVisualStyleBackColor = true;
               // 
               // tbName
               // 
               this.tbName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.tbName.Location = new System.Drawing.Point(184, 408);
               this.tbName.Multiline = true;
               this.tbName.Name = "tbName";
               this.tbName.Size = new System.Drawing.Size(223, 39);
               this.tbName.TabIndex = 6;
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
               this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
               this.ClientSize = new System.Drawing.Size(584, 611);
               this.Controls.Add(this.tbName);
               this.Controls.Add(this.button1);
               this.Controls.Add(this.bInstruct);
               this.Controls.Add(this.bPlay);
               this.Controls.Add(this.pictureBox1);
               this.Name = "Form1";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "Form1";
               this.Load += new System.EventHandler(this.Form1_Load);
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion
          private System.Windows.Forms.PictureBox pictureBox1;
          private System.Windows.Forms.Button bPlay;
          private System.Windows.Forms.Button bInstruct;
          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.TextBox tbName;
     }
}

