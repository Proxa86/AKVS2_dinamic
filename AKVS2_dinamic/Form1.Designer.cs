namespace AKVS2_dinamic
{
    partial class Form1
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
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.buttonPrintReportExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(13, 13);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(148, 52);
            this.buttonOpenFolder.TabIndex = 0;
            this.buttonOpenFolder.Text = "OpenFolder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // buttonPrintReportExcel
            // 
            this.buttonPrintReportExcel.Location = new System.Drawing.Point(180, 13);
            this.buttonPrintReportExcel.Name = "buttonPrintReportExcel";
            this.buttonPrintReportExcel.Size = new System.Drawing.Size(165, 52);
            this.buttonPrintReportExcel.TabIndex = 1;
            this.buttonPrintReportExcel.Text = "PrintReportExcel";
            this.buttonPrintReportExcel.UseVisualStyleBackColor = true;
            this.buttonPrintReportExcel.Click += new System.EventHandler(this.buttonPrintReportExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 77);
            this.Controls.Add(this.buttonPrintReportExcel);
            this.Controls.Add(this.buttonOpenFolder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Button buttonPrintReportExcel;
    }
}

