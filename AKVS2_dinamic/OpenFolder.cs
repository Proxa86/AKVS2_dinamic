using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AKVS2_dinamic
{
    class OpenFolder
    {
        Form1 CopyForm { get; set; }

        public OpenFolder()
        {   
        }

        public OpenFolder(Form1 f)
        {
            CopyForm = f;
            f.LabelInformation = "Please, choose folder for analise.";
        }

        public void openFolderWithFiles()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"C:\";
            fbd.ShowNewFolderButton = false;

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SelectFile selectFile = new SelectFile(fbd, CopyForm);
                    selectFile.parsingReport();
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error: can't open folder.\nOriginal error: "+ e.Message);
                }
            }
        }
    }
}
