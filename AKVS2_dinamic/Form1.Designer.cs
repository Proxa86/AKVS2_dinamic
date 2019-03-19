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
            this.buttonOutReport = new System.Windows.Forms.Button();
            this.labelInformations = new System.Windows.Forms.Label();
            this.checkBoxNotCall = new System.Windows.Forms.CheckBox();
            this.checkBoxAllCall = new System.Windows.Forms.CheckBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.checkBoxAnalysisLinkFunctionFunction = new System.Windows.Forms.CheckBox();
            this.checkBoxAnalysisLinkBranchBranch = new System.Windows.Forms.CheckBox();
            this.checkBoxAnalysisFunctions = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveInFile = new System.Windows.Forms.CheckBox();
            this.checkBoxExportInFileExcel = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(13, 13);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(119, 31);
            this.buttonOpenFolder.TabIndex = 0;
            this.buttonOpenFolder.Text = "OpenFolder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // buttonOutReport
            // 
            this.buttonOutReport.Location = new System.Drawing.Point(13, 54);
            this.buttonOutReport.Name = "buttonOutReport";
            this.buttonOutReport.Size = new System.Drawing.Size(119, 32);
            this.buttonOutReport.TabIndex = 1;
            this.buttonOutReport.Text = "OutReport";
            this.buttonOutReport.UseVisualStyleBackColor = true;
            this.buttonOutReport.Click += new System.EventHandler(this.buttonOutReport_Click);
            // 
            // labelInformations
            // 
            this.labelInformations.AutoSize = true;
            this.labelInformations.Location = new System.Drawing.Point(12, 121);
            this.labelInformations.Name = "labelInformations";
            this.labelInformations.Size = new System.Drawing.Size(0, 13);
            this.labelInformations.TabIndex = 3;
            // 
            // checkBoxNotCall
            // 
            this.checkBoxNotCall.AutoSize = true;
            this.checkBoxNotCall.Location = new System.Drawing.Point(147, 100);
            this.checkBoxNotCall.Name = "checkBoxNotCall";
            this.checkBoxNotCall.Size = new System.Drawing.Size(153, 17);
            this.checkBoxNotCall.TabIndex = 4;
            this.checkBoxNotCall.Text = "Not called function/branch";
            this.checkBoxNotCall.UseVisualStyleBackColor = true;
            this.checkBoxNotCall.CheckedChanged += new System.EventHandler(this.checkBoxNotCall_CheckedChanged);
            // 
            // checkBoxAllCall
            // 
            this.checkBoxAllCall.AutoSize = true;
            this.checkBoxAllCall.Location = new System.Drawing.Point(147, 77);
            this.checkBoxAllCall.Name = "checkBoxAllCall";
            this.checkBoxAllCall.Size = new System.Drawing.Size(134, 17);
            this.checkBoxAllCall.TabIndex = 5;
            this.checkBoxAllCall.Text = "Called function/branch";
            this.checkBoxAllCall.UseMnemonic = false;
            this.checkBoxAllCall.UseVisualStyleBackColor = true;
            this.checkBoxAllCall.CheckedChanged += new System.EventHandler(this.checkBoxAllCall_CheckedChanged);
            // 
            // checkBoxAnalysisLinkFunctionFunction
            // 
            this.checkBoxAnalysisLinkFunctionFunction.AutoSize = true;
            this.checkBoxAnalysisLinkFunctionFunction.Location = new System.Drawing.Point(147, 31);
            this.checkBoxAnalysisLinkFunctionFunction.Name = "checkBoxAnalysisLinkFunctionFunction";
            this.checkBoxAnalysisLinkFunctionFunction.Size = new System.Drawing.Size(201, 17);
            this.checkBoxAnalysisLinkFunctionFunction.TabIndex = 6;
            this.checkBoxAnalysisLinkFunctionFunction.Text = "Analysis report link function - function";
            this.checkBoxAnalysisLinkFunctionFunction.UseVisualStyleBackColor = true;
            this.checkBoxAnalysisLinkFunctionFunction.CheckedChanged += new System.EventHandler(this.checkBoxAnalysisLinkFunctionFunction_CheckedChanged);
            // 
            // checkBoxAnalysisLinkBranchBranch
            // 
            this.checkBoxAnalysisLinkBranchBranch.AutoSize = true;
            this.checkBoxAnalysisLinkBranchBranch.Location = new System.Drawing.Point(147, 54);
            this.checkBoxAnalysisLinkBranchBranch.Name = "checkBoxAnalysisLinkBranchBranch";
            this.checkBoxAnalysisLinkBranchBranch.Size = new System.Drawing.Size(191, 17);
            this.checkBoxAnalysisLinkBranchBranch.TabIndex = 7;
            this.checkBoxAnalysisLinkBranchBranch.Text = "Analysis report link branch - branch";
            this.checkBoxAnalysisLinkBranchBranch.UseVisualStyleBackColor = true;
            this.checkBoxAnalysisLinkBranchBranch.CheckedChanged += new System.EventHandler(this.checkBoxAnalysisLinkBranchBranch_CheckedChanged);
            // 
            // checkBoxAnalysisFunctions
            // 
            this.checkBoxAnalysisFunctions.AutoSize = true;
            this.checkBoxAnalysisFunctions.Location = new System.Drawing.Point(147, 8);
            this.checkBoxAnalysisFunctions.Name = "checkBoxAnalysisFunctions";
            this.checkBoxAnalysisFunctions.Size = new System.Drawing.Size(140, 17);
            this.checkBoxAnalysisFunctions.TabIndex = 8;
            this.checkBoxAnalysisFunctions.Text = "Analysis report functions";
            this.checkBoxAnalysisFunctions.UseVisualStyleBackColor = true;
            this.checkBoxAnalysisFunctions.CheckedChanged += new System.EventHandler(this.checkBoxAnalysisFunctions_CheckedChanged);
            // 
            // checkBoxSaveInFile
            // 
            this.checkBoxSaveInFile.AutoSize = true;
            this.checkBoxSaveInFile.Location = new System.Drawing.Point(147, 121);
            this.checkBoxSaveInFile.Name = "checkBoxSaveInFile";
            this.checkBoxSaveInFile.Size = new System.Drawing.Size(78, 17);
            this.checkBoxSaveInFile.TabIndex = 9;
            this.checkBoxSaveInFile.Text = "Save in file";
            this.checkBoxSaveInFile.UseVisualStyleBackColor = true;
            this.checkBoxSaveInFile.CheckedChanged += new System.EventHandler(this.checkBoxSaveInFile_CheckedChanged);
            // 
            // checkBoxExportInFileExcel
            // 
            this.checkBoxExportInFileExcel.AutoSize = true;
            this.checkBoxExportInFileExcel.Location = new System.Drawing.Point(147, 145);
            this.checkBoxExportInFileExcel.Name = "checkBoxExportInFileExcel";
            this.checkBoxExportInFileExcel.Size = new System.Drawing.Size(111, 17);
            this.checkBoxExportInFileExcel.TabIndex = 10;
            this.checkBoxExportInFileExcel.Text = "Export in file excel";
            this.checkBoxExportInFileExcel.UseVisualStyleBackColor = true;
            this.checkBoxExportInFileExcel.CheckedChanged += new System.EventHandler(this.checkBoxExportInFileExcel_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 179);
            this.Controls.Add(this.checkBoxExportInFileExcel);
            this.Controls.Add(this.checkBoxSaveInFile);
            this.Controls.Add(this.checkBoxAnalysisFunctions);
            this.Controls.Add(this.checkBoxAnalysisLinkBranchBranch);
            this.Controls.Add(this.checkBoxAnalysisLinkFunctionFunction);
            this.Controls.Add(this.checkBoxAllCall);
            this.Controls.Add(this.checkBoxNotCall);
            this.Controls.Add(this.labelInformations);
            this.Controls.Add(this.buttonOutReport);
            this.Controls.Add(this.buttonOpenFolder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Button buttonOutReport;
        private System.Windows.Forms.Label labelInformations;
        private System.Windows.Forms.CheckBox checkBoxNotCall;
        private System.Windows.Forms.CheckBox checkBoxAllCall;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.CheckBox checkBoxAnalysisLinkFunctionFunction;
        private System.Windows.Forms.CheckBox checkBoxAnalysisLinkBranchBranch;
        private System.Windows.Forms.CheckBox checkBoxAnalysisFunctions;
        private System.Windows.Forms.CheckBox checkBoxSaveInFile;
        private System.Windows.Forms.CheckBox checkBoxExportInFileExcel;
    }
}

