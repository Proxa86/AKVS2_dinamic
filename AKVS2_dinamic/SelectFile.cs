using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AKVS2_dinamic
{
    class SelectFile
    {
        FolderBrowserDialog fbd;
        Form1 CopyForm { get; set; }

        public SelectFile()
        {
        }

        public SelectFile(FolderBrowserDialog fbd, Form1 f)
        {
            this.fbd = fbd;
            CopyForm = f;
        }


        public void parsingReport()
        {
            List<string[]> lParentFilters = new List<string[]>();
          
            lParentFilters.Add(Directory.GetFiles(fbd.SelectedPath, "*", SearchOption.AllDirectories));
            

            try
            {
                FindMiningMarker findMiningMarker = new FindMiningMarker(CopyForm);

                //File.WriteAllText(saveFile.FileName, "");
                List<Numbers> numbers = new List<Numbers>();
                string paternPath = "\\w+.{1}txt";

                foreach (var filter in lParentFilters)
                {
                    foreach (var path in filter)
                    {
                        Regex regex = new Regex(paternPath);
                        Match match = regex.Match(path);

                        switch(match.Value)
                        {
                            case "2.txt":
                                {
                                    CopyForm.LabelInformation = "Processing file with functions.";
                                    CopyForm.Refresh();
                                    findMiningMarker.findFunc(path);
                                    CopyForm.LabelInformation = "Processing end.";
                                    CopyForm.Refresh();
                                }
                                break;
                            case "3.txt":
                                {
                                    CopyForm.LabelInformation = "Processing file link function - function.";
                                    CopyForm.Refresh();
                                    findMiningMarker.findLinkFunc(path);
                                    CopyForm.LabelInformation = "Processing end.";
                                    CopyForm.Refresh();
                                }
                                break;
                            case "5.txt":
                                {
                                    CopyForm.LabelInformation = "Processing file link branch - branch.";
                                    CopyForm.Refresh();
                                    findMiningMarker.findLinkBranch(path);
                                    CopyForm.LabelInformation = "Processing end.";
                                    CopyForm.Refresh();
                                }
                                break;
                        }
                    }
                }
                MessageBox.Show("Game Over!\nAnalise End.");

            }
            catch (Exception e)
            {
                MessageBox.Show("Can't open file.\nOriginal error: " + e.Message);
            }

        }
    }
}
