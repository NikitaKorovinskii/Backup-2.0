﻿namespace carrr
{
    partial class EventCar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventCar));
            this.button1 = new System.Windows.Forms.Button();
            this.repair = new System.Windows.Forms.Button();
            this.Technical = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(85, 69);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "<--";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // repair
            // 
            this.repair.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.repair.Location = new System.Drawing.Point(403, 147);
            this.repair.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.repair.Name = "repair";
            this.repair.Size = new System.Drawing.Size(317, 135);
            this.repair.TabIndex = 2;
            this.repair.Text = "Ремонт";
            this.repair.UseVisualStyleBackColor = true;
            this.repair.Click += new System.EventHandler(this.button2_Click);
            // 
            // Technical
            // 
            this.Technical.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Technical.Location = new System.Drawing.Point(403, 349);
            this.Technical.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Technical.Name = "Technical";
            this.Technical.Size = new System.Drawing.Size(317, 135);
            this.Technical.TabIndex = 3;
            this.Technical.Text = "ТО";
            this.Technical.UseVisualStyleBackColor = true;
            this.Technical.Click += new System.EventHandler(this.Technical_Click);
            // 
            // EventCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1066, 692);
            this.Controls.Add(this.Technical);
            this.Controls.Add(this.repair);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "EventCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "События с машиной";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button repair;
        private Button Technical;
    }
}