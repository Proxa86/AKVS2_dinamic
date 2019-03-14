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

        public void openFolderWithFiles()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"C:\";
            fbd.ShowNewFolderButton = false;

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ParsingFile parsingFile = new ParsingFile(fbd);
                    parsingFile.parsingReport();
                    //FindTmpMarker findTmpMarker = new FindTmpMarker(fbd);
                    //findTmpMarker.findTmpMarkerWithSrc();
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error: can't open folder.\nOriginal error: "+ e.Message);
                }
            }
        }

        //public void openFolderWithBin()
        //{
        //    FolderBrowserDialog fbd = new FolderBrowserDialog();
        //    fbd.SelectedPath = @"C:\";
        //    fbd.ShowNewFolderButton = false;

        //    if (fbd.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            FindTmpMarker findTmpMarker = new FindTmpMarker(fbd);
        //            findTmpMarker.findTmpMarkerWithBin();
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show("Error: can't open folder.\nOriginal error: " + e.Message);
        //        }
        //    }
        //}

    }
}
