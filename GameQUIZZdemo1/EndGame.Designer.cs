namespace GameQUIZZdemo1
{
     partial class EndGame
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
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndGame));
               this.button1 = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // button1
               // 
               this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
               this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
               this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
               this.button1.FlatAppearance.BorderSize = 0;
               this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
               this.button1.Location = new System.Drawing.Point(227, 324);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(323, 139);
               this.button1.TabIndex = 0;
               this.button1.TabStop = false;
               this.button1.UseVisualStyleBackColor = false;
               this.button1.Click += new System.EventHandler(this.button1_Click);
               // 
               // EndGame
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
               this.ClientSize = new System.Drawing.Size(584, 611);
               this.Controls.Add(this.button1);
               this.Name = "EndGame";
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "EndGame";
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.Button button1;
     }
}