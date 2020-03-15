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
               this.tbName = new System.Windows.Forms.TextBox();
               this.bLoud = new System.Windows.Forms.Button();
               this.bMute = new System.Windows.Forms.Button();
               this.pictureBox2 = new System.Windows.Forms.PictureBox();
               this.pInstruct = new System.Windows.Forms.Panel();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
               this.pInstruct.SuspendLayout();
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
               this.bPlay.BackColor = System.Drawing.Color.MediumSeaGreen;
               this.bPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bPlay.BackgroundImage")));
               this.bPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
               this.bPlay.FlatAppearance.BorderSize = 0;
               this.bPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.bPlay.Location = new System.Drawing.Point(184, 475);
               this.bPlay.Name = "bPlay";
               this.bPlay.Size = new System.Drawing.Size(223, 74);
               this.bPlay.TabIndex = 2;
               this.bPlay.TabStop = false;
               this.bPlay.UseVisualStyleBackColor = false;
               this.bPlay.Click += new System.EventHandler(this.bPlay_Click);
               // 
               // bInstruct
               // 
               this.bInstruct.BackColor = System.Drawing.Color.MediumSeaGreen;
               this.bInstruct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bInstruct.BackgroundImage")));
               this.bInstruct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
               this.bInstruct.FlatAppearance.BorderSize = 0;
               this.bInstruct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.bInstruct.Location = new System.Drawing.Point(33, 0);
               this.bInstruct.Name = "bInstruct";
               this.bInstruct.Size = new System.Drawing.Size(42, 41);
               this.bInstruct.TabIndex = 4;
               this.bInstruct.TabStop = false;
               this.bInstruct.UseVisualStyleBackColor = false;
               this.bInstruct.Click += new System.EventHandler(this.bInstruct_Click);
               // 
               // tbName
               // 
               this.tbName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.tbName.Location = new System.Drawing.Point(184, 408);
               this.tbName.Multiline = true;
               this.tbName.Name = "tbName";
               this.tbName.Size = new System.Drawing.Size(223, 39);
               this.tbName.TabIndex = 6;
               this.tbName.TabStop = false;
               // 
               // bLoud
               // 
               this.bLoud.BackColor = System.Drawing.Color.MediumSeaGreen;
               this.bLoud.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bLoud.BackgroundImage")));
               this.bLoud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
               this.bLoud.FlatAppearance.BorderSize = 0;
               this.bLoud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.bLoud.Location = new System.Drawing.Point(-1, 2);
               this.bLoud.Name = "bLoud";
               this.bLoud.Size = new System.Drawing.Size(39, 39);
               this.bLoud.TabIndex = 5;
               this.bLoud.TabStop = false;
               this.bLoud.UseVisualStyleBackColor = false;
               this.bLoud.Click += new System.EventHandler(this.bLoud_Click);
               // 
               // bMute
               // 
               this.bMute.BackColor = System.Drawing.Color.MediumSeaGreen;
               this.bMute.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bMute.BackgroundImage")));
               this.bMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
               this.bMute.FlatAppearance.BorderSize = 0;
               this.bMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.bMute.Location = new System.Drawing.Point(-1, 2);
               this.bMute.Name = "bMute";
               this.bMute.Size = new System.Drawing.Size(39, 39);
               this.bMute.TabIndex = 8;
               this.bMute.TabStop = false;
               this.bMute.UseVisualStyleBackColor = false;
               this.bMute.Visible = false;
               this.bMute.Click += new System.EventHandler(this.bMute_Click);
               // 
               // pictureBox2
               // 
               this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
               this.pictureBox2.Location = new System.Drawing.Point(-27, 36);
               this.pictureBox2.Name = "pictureBox2";
               this.pictureBox2.Size = new System.Drawing.Size(504, 502);
               this.pictureBox2.TabIndex = 0;
               this.pictureBox2.TabStop = false;
               // 
               // pInstruct
               // 
               this.pInstruct.BackColor = System.Drawing.Color.MediumSeaGreen;
               this.pInstruct.Controls.Add(this.pictureBox2);
               this.pInstruct.Location = new System.Drawing.Point(68, 107);
               this.pInstruct.Name = "pInstruct";
               this.pInstruct.Size = new System.Drawing.Size(61, 137);
               this.pInstruct.TabIndex = 7;
               this.pInstruct.Visible = false;
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
               this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
               this.ClientSize = new System.Drawing.Size(584, 611);
               this.Controls.Add(this.bMute);
               this.Controls.Add(this.pInstruct);
               this.Controls.Add(this.tbName);
               this.Controls.Add(this.bLoud);
               this.Controls.Add(this.bInstruct);
               this.Controls.Add(this.bPlay);
               this.Controls.Add(this.pictureBox1);
               this.Name = "Form1";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "Form1";
               this.Load += new System.EventHandler(this.Form1_Load);
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
               this.pInstruct.ResumeLayout(false);
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion
          private System.Windows.Forms.PictureBox pictureBox1;
          private System.Windows.Forms.Button bPlay;
          private System.Windows.Forms.Button bInstruct;
          private System.Windows.Forms.TextBox tbName;
          private System.Windows.Forms.Button bLoud;
          private System.Windows.Forms.Button bMute;
          private System.Windows.Forms.PictureBox pictureBox2;
          private System.Windows.Forms.Panel pInstruct;
     }
}

