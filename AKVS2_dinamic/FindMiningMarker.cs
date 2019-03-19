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
        //public string flagEndWork { get; set; }
        SaveFileDialog saveFile;
        Form1 CopyForm;
        WorkExcel workExcel;
        public List<NotCallFunctions> lNotCallFunctions { get; set; }
        //public bool CheckCall { get; set; }
        //public bool CheckNotCall { get; set; }
        public string InformationDisplay { get; set; }

        public FindMiningMarker()
        {
        }

        public FindMiningMarker(Form1 f)
        {
            saveFile = new SaveFileDialog();
            
            CopyForm = f;
        }

        public void findFunc(string path)
        {
            if(CopyForm.CheckReportFunctions)
            {
                string[] allLinesInFile = File.ReadAllLines(path);
                lNotCallFunctions = new List<NotCallFunctions>();
                int i = 0;

                Regex regex;

                foreach (var line in allLinesInFile)
                {
                    bool call = callAndNotCallFuncOrBranch(line);
                    while (call)
                    {
                        ++i;
                        NotCallFunctions notCallFunction = new NotCallFunctions();
                        string paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                        regex = new Regex(paternFind);
                        Match match = regex.Match(line);
                        if (match.Success)
                        {
                            notCallFunction.QidIn = match.Value;

                            paternFind = "\\w+\\:{0,2}[\\w!=]+\\({1}[\\w\\s:;*,&]*\\){1}";

                            regex = new Regex(paternFind);
                            match = regex.Match(line);

                            if (match.Success)
                            {
                                notCallFunction.NameFunction = match.Value;
                            }
                            else
                            {
                                paternFind = "\\w+\\:{2}\\w+\\:{2}\\w+";
                                regex = new Regex(paternFind);
                                match = regex.Match(line);
                                notCallFunction.NameFunction = match.Value;
                            }

                            lNotCallFunctions.Add(notCallFunction);
                            break;
                        }
                    }
                }

                if (CopyForm.CheckReportFunctions & CopyForm.CheckExportInFileExcel)
                {
                    workExcel = new WorkExcel();
                    workExcel.DisplayNotCallFunctions(lNotCallFunctions);
                }
                else if(CopyForm.CheckReportFunctions & CopyForm.CheckSaveInFile)
                {

                }
            }

            
            
        }

        public void findLinkFunc(string path)
        {
            if(CopyForm.CheckReportFunctionsFunctions & CopyForm.CheckSaveInFile)
            {
                string[] allLinesInFile = File.ReadAllLines(path);
                saveFile.FileName = "akvs_dyn_thread_3.log";
                //File.WriteAllText(saveFile.FileName, "",Encoding.ASCII);
                Regex regex;

                foreach (var line in allLinesInFile)
                {

                    bool call = callAndNotCallFuncOrBranch(line);

                    while (call)
                    {
                        string paternFind = "[0-9]{1,7}:[0-9]{1,7}";
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
        }

        public void findLinkBranch(string path)
        {
            if(CopyForm.CheckReportBranchBranch & CopyForm.CheckSaveInFile)
            {
                string[] allLinesInFile = File.ReadAllLines(path);
                saveFile.FileName = "akvs_dyn_thread_5.log";
                //File.WriteAllText(saveFile.FileName, "", Encoding.ASCII);

                List<Numbers> lNumbers = new List<Numbers>();

                BuildReport buildReport = new BuildReport();
                Regex regex;
                foreach (var line in allLinesInFile)
                {

                    bool call = callAndNotCallFuncOrBranch(line);

                    if (call)
                    {
                        string paternFind = "[0-9]{1,7}:[0-9]{1,7}";
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
            }   
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

        public bool callAndNotCallFuncOrBranch(string line)
        {
            Regex regex;
            Match matchCall = null;
            string paternFind = "";
            if (CopyForm.CheckCalled & !CopyForm.CheckNotCalled)
            {
                paternFind = "\\scalled";
                regex = new Regex(paternFind);
                matchCall = regex.Match(line);
            }
            else if (CopyForm.CheckNotCalled & !CopyForm.CheckCalled)
            {
                paternFind = "not_called";
                regex = new Regex(paternFind);
                matchCall = regex.Match(line);
            }
            else if (!(CopyForm.CheckCalled & CopyForm.CheckNotCalled))
            {
                paternFind = "\\scalled";
                regex = new Regex(paternFind);
                matchCall = regex.Match(line);
                if (!matchCall.Success)
                {
                    paternFind = "not_called";
                    regex = new Regex(paternFind);
                    matchCall = regex.Match(line);
                }
            }

            return matchCall.Success;
        }



        
    }
}
