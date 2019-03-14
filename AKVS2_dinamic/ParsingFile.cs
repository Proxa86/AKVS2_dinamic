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
    class ParsingFile
    {
        FolderBrowserDialog fbd;
       

        public ParsingFile()
        {
            
            
        }

        public ParsingFile(FolderBrowserDialog fbd)
        {
            this.fbd = fbd;
            
        }

        public void parsingReport()
        {
            List<string[]> lParentFilters = new List<string[]>();
          
            lParentFilters.Add(Directory.GetFiles(fbd.SelectedPath, "*", SearchOption.AllDirectories));

            try
            {
                FindMiningMarker findMiningMarker = new FindMiningMarker();

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
                                    findMiningMarker.findFunc(path);
                                }
                                break;
                            case "3.txt":
                                {
                                    findMiningMarker.findLinkFunc(path);
                                }
                                break;
                            case "5.txt":
                                {
                                    findMiningMarker.findLinkBranch(path);
                                }
                                break;
                        }

                        //string[] allLinesInFile = File.ReadAllLines(path);

                        //foreach (var line in allLinesInFile)
                        //{
                        //    //string paternFind = "not_called";
                        //    string paternFind = "not_called";

                        //    Regex regex = new Regex(paternFind);
                        //    Match matchCall = regex.Match(line);

                        //    while (matchCall.Success)
                        //    {
                        //        paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                        //        regex = new Regex(paternFind);
                        //        Match match = regex.Match(line);
                        //        if (match.Success)
                        //        {
                        //            //File.AppendAllText(saveFile.FileName, match.Value + ":f:i\n", Encoding.UTF8);
                        //            string second = match.Value;
                        //            match = match.NextMatch().NextMatch().NextMatch();
                        //            if (match.Success)
                        //            {
                        //                File.AppendAllText(saveFile.FileName, match.Value + ":b:i\n", Encoding.UTF8);
                        //                File.AppendAllText(saveFile.FileName, match.Value + ":b:o\n", Encoding.UTF8);
                        //            }
                        //            File.AppendAllText(saveFile.FileName, second + ":f:o\n", Encoding.UTF8);
                        //            break;

                        //        }
                        //    }
                        //}

                    }
                }
                MessageBox.Show("Game Over!");

            }
            catch (Exception e)
            {
                MessageBox.Show("Can't open file.\nOriginal error: " + e.Message);
            }

        }
    }
}
