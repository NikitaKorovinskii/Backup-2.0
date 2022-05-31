namespace carrr
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openTrip = new System.Windows.Forms.Button();
            this.eventCar = new System.Windows.Forms.Button();
            this.newTrip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openTrip
            // 
            this.openTrip.BackColor = System.Drawing.Color.White;
            this.openTrip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openTrip.Font = new System.Drawing.Font("Centaur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.openTrip.Location = new System.Drawing.Point(339, 115);
            this.openTrip.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.openTrip.Name = "openTrip";
            this.openTrip.Size = new System.Drawing.Size(357, 107);
            this.openTrip.TabIndex = 0;
            this.openTrip.Text = "Открытые заявки";
            this.openTrip.UseVisualStyleBackColor = false;
            this.openTrip.Click += new System.EventHandler(this.openTrip_Click);
            // 
            // eventCar
            // 
            this.eventCar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eventCar.Font = new System.Drawing.Font("Centaur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.eventCar.Location = new System.Drawing.Point(339, 285);
            this.eventCar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.eventCar.Name = "eventCar";
            this.eventCar.Size = new System.Drawing.Size(357, 107);
            this.eventCar.TabIndex = 1;
            this.eventCar.Text = "Ремонт авто";
            this.eventCar.UseVisualStyleBackColor = true;
            this.eventCar.Click += new System.EventHandler(this.eventCar_Click);
            // 
            // newTrip
            // 
            this.newTrip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newTrip.Font = new System.Drawing.Font("Centaur", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newTrip.Location = new System.Drawing.Point(339, 455);
            this.newTrip.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.newTrip.Name = "newTrip";
            this.newTrip.Size = new System.Drawing.Size(357, 107);
            this.newTrip.TabIndex = 2;
            this.newTrip.Text = "Локальная заявка";
            this.newTrip.UseVisualStyleBackColor = true;
            this.newTrip.Click += new System.EventHandler(this.newTrip_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1045, 709);
            this.Controls.Add(this.newTrip);
            this.Controls.Add(this.eventCar);
            this.Controls.Add(this.openTrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главный экран";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openTrip;
        private System.Windows.Forms.Button eventCar;
        private System.Windows.Forms.Button newTrip;
    }
}

