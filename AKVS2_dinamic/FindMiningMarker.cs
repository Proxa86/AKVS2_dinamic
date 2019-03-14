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
    class FindMiningMarker
    {
        SaveFileDialog saveFile;

        public FindMiningMarker()
        {
            saveFile = new SaveFileDialog();

        }
        public void findLinkFunc(string path)
        {
            string[] allLinesInFile = File.ReadAllLines(path);
            saveFile.FileName = "akvs_dyn_thread_3.log";
            //File.WriteAllText(saveFile.FileName, "",Encoding.ASCII);
            

            foreach (var line in allLinesInFile)
            {
                string paternFind = "called";
                //string paternFind = "not_called";

                Regex regex = new Regex(paternFind);
                Match matchCall = regex.Match(line);

                while (matchCall.Success)
                {
                    paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                    regex = new Regex(paternFind);
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        File.AppendAllText(saveFile.FileName, match.Value + ":f:i\n", Encoding.ASCII);
                        string second = match.Value;
                        match = match.NextMatch().NextMatch().NextMatch();
                        if (match.Success)
                        {
                            File.AppendAllText(saveFile.FileName, match.Value + ":f:i\n", Encoding.ASCII);
                            File.AppendAllText(saveFile.FileName, match.Value + ":f:o\n", Encoding.ASCII);
                        }
                        File.AppendAllText(saveFile.FileName, second + ":f:o\n", Encoding.ASCII);
                        break;

                    }
                }
            }
        }

        public void findLinkBranch(string path)
        {
            string[] allLinesInFile = File.ReadAllLines(path);
            saveFile.FileName = "akvs_dyn_thread_5.log";
            //File.WriteAllText(saveFile.FileName, "", Encoding.ASCII);
            
            List<Numbers> lNumbers = new List<Numbers>();

            foreach (var line in allLinesInFile)
            {
                string paternFind = "called";
                //string paternFind = "not_called";

                Regex regex = new Regex(paternFind);
                Match matchCall = regex.Match(line);

                if (matchCall.Success)
                {
                    paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                    regex = new Regex(paternFind);
                    Match match = regex.Match(line);
                    Numbers numbers = new Numbers();
                    if (match.Success)
                    {
                        
                        numbers.QidIn = match.Value;
                        match = match.NextMatch().NextMatch().NextMatch();
                        if (match.Success)
                        {
                            numbers.QidOut = match.Value;
                        }

                    }
                    lNumbers.Add(numbers);
                }
            }

            recursing(lNumbers);
            MessageBox.Show("!!!");
            
        }

        public void recursing(List<Numbers> lNumbers)
        {
            foreach(var n in lNumbers)
            {
                string s = n.QidIn;
                File.AppendAllText(saveFile.FileName, n.QidIn + ":f:i\n", Encoding.ASCII);
                findNumber(n, lNumbers);
                File.AppendAllText(saveFile.FileName, s + ":f:o\n", Encoding.ASCII);
            }


        }

        public void findNumber(Numbers n, List<Numbers> lNumbers)
        {
            if (lNumbers.Any(x => x.QidIn.Equals(n.QidOut)))
            {

                var find = lNumbers.FindIndex(x => x.QidIn.Equals(n.QidOut));
                if (find != 0)
                {
                    n.QidIn = n.QidOut;
                    File.AppendAllText(saveFile.FileName, n.QidIn + ":b:i\n", Encoding.ASCII);
                    n.QidOut = lNumbers[find].QidOut;

                    findNumber(n, lNumbers);
                    File.AppendAllText(saveFile.FileName, n.QidIn + ":b:o\n", Encoding.ASCII);
                }
            }
            else
            {
                File.AppendAllText(saveFile.FileName, n.QidOut + ":b:i\n", Encoding.ASCII);
                File.AppendAllText(saveFile.FileName, n.QidOut + ":b:o\n", Encoding.ASCII);
            }
        }



        
    }
}
