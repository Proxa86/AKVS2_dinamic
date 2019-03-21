using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AKVS2_dinamic
{
    public partial class Form1 : Form
    {

        //static public string LabelInformation { get; set; }

        public bool CheckCalled { get; set; }
        public bool CheckNotCalled { get; set; }
        public bool CheckCallInDynamic { get; set; }
        public bool CheckReportFunctions { get; set; }
        public bool CheckReportFunctionsFunctions { get; set; }
        public bool CheckReportBranchBranch { get; set; }
        public bool CheckSaveInFile { get; set; }
        public bool CheckExportInFileExcel { get; set; }

        public string LabelInformation {
            get => this.labelInformations.Text;
            set => this.labelInformations.Text = value;}

        public Form1()
        {
            InitializeComponent();

            //listBoxOutReport.Items.Add("Вывести в excel не отработанные функции.");
            //listBoxOutReport.SelectedIndex = 2;

            this.Text = "Какого цвета зеркало?";

            CheckCalled = false;
            CheckNotCalled = false;
            //this.labelInformations.Text = LabelInformation;
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            
            if (!this.CheckCalled & !this.CheckNotCalled & !this.CheckCallInDynamic)
            {
                this.LabelInformation = "You don't choose type searching information in file!";
                return;
            }
            else
            {
                OpenFolder openFolder = new OpenFolder(this);
                openFolder.openFolderWithFiles();
            }
        }

        private void buttonOutReport_Click(object sender, EventArgs e)
        {
            //BuildReport buildReport = new BuildReport();
            //buildReport.buildReport(listBoxOutReport.SelectedIndex);
        }

        private void checkBoxAllCall_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAllCall.Checked)
                CheckCalled = true;
            else
                CheckCalled = false;
        }

        private void checkBoxNotCall_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNotCall.Checked)
                CheckNotCalled = true;
            else
                CheckNotCalled = false;
        }

        private void checkBoxCallInDynamic_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCallInDynamic.Checked)
                CheckCallInDynamic = true;
            else
                CheckCallInDynamic = false;
        }

        private void checkBoxAnalysisFunctions_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAnalysisFunctions.Checked)
                CheckReportFunctions = true; 
            else
                CheckReportFunctions = false;
        }

        private void checkBoxAnalysisLinkFunctionFunction_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAnalysisLinkFunctionFunction.Checked)
                CheckReportFunctionsFunctions = true;
            else
                CheckReportFunctionsFunctions = false;
        }

        private void checkBoxAnalysisLinkBranchBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAnalysisLinkBranchBranch.Checked)
            {
                CheckReportBranchBranch = true;
                //checkBoxAllCall.Enabled = false;
                //checkBoxNotCall.Enabled = false;
                //checkBoxCallInDynamic.Enabled = false;
                //checkBoxAllCall.Checked = true;
                //checkBoxNotCall.Checked = true;
                //checkBoxCallInDynamic.Checked = true;
            }               
            else
            {
                CheckReportBranchBranch = false;
                //checkBoxAllCall.Enabled = true;
                //checkBoxNotCall.Enabled = true;
                //checkBoxCallInDynamic.Enabled = true;
                //checkBoxAllCall.Checked = false;
                //checkBoxNotCall.Checked = false;
                //checkBoxCallInDynamic.Checked = false;
            }
        }

        private void checkBoxSaveInFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSaveInFile.Checked)
                CheckSaveInFile = true;
            else
                CheckSaveInFile = false;
        }

        private void checkBoxExportInFileExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxExportInFileExcel.Checked)
                CheckExportInFileExcel = true;
            else
                CheckExportInFileExcel = false;
        }
    }
}
