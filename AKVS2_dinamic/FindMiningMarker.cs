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
        Form1 CopyForm;
        WorkExcel workExcel;

        public List<Functions> lFunctions { get; set; }
        public List<LinkFunctionsFunctions> lLinkFunctionFunction { get; set; }
        public List<LinkBranchBranch> lLinkBranchBranch { get; set; }
        public string InformationDisplay { get; set; }
        public string NameFile { get; set; }
        public string PathFile { get; set; }

        public FindMiningMarker()
        {
        }

        public FindMiningMarker(Form1 f)
        {
            CopyForm = f;
            if (CopyForm.CheckSaveInFile)
            {
                string pathFile = Application.StartupPath + "\\LogFile\\";
                Directory.CreateDirectory(pathFile);
                PathFile = pathFile;
            }    
        }

        public void findFunc(string path)
        {
            if(CopyForm.CheckReportFunctions)
            {
                string[] allLinesInFile = File.ReadAllLines(path);
                lFunctions = new List<Functions>();

                foreach (var line in allLinesInFile)
                {
                    bool call = call = callAndNotCallFuncOrBranch(line);

                    while (call)
                    {
                        Functions function = new Functions();

                        string paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                        Match match = new Regex(paternFind).Match(line);

                        if (match.Success)
                        {
                            function.QidIn = match.Value;

                            paternFind = "\\w+\\:{0,2}[\\w!=]+\\({1}[\\w\\s:;<>*,&]*\\){1}";
                            match = new Regex(paternFind).Match(line);

                            if (match.Success)
                            {
                                function.NameFunction = match.Value;
                            }
                            else
                            {
                                paternFind = "\\w+\\:{2}\\w+\\:{2}\\w+";
                                match = new Regex(paternFind).Match(line);

                                function.NameFunction = match.Value;
                            }

                            lFunctions.Add(function);
                            break;
                        }
                    }
                }

                if (CopyForm.CheckReportFunctions & CopyForm.CheckExportInFileExcel)
                {
                    workExcel = new WorkExcel();
                    workExcel.DisplayFunctions(lFunctions);
                }

                if(CopyForm.CheckReportFunctions & CopyForm.CheckSaveInFile)
                {
                    
                    NameFile = "akvs_dyn_thread_2.log";

                    foreach (var line in allLinesInFile)
                    {
                        bool call = callAndNotCallFuncOrBranch(line);

                        while (call)
                        {
                            string paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                            Match match = new Regex(paternFind).Match(line);

                            if (match.Success)
                            {
                                File.AppendAllText(Path.Combine(PathFile, NameFile), match.Value + ":f:i\n", Encoding.ASCII);
                                File.AppendAllText(Path.Combine(PathFile, NameFile), match.Value + ":f:o\n", Encoding.ASCII);
                                break;
                            }
                        }
                    }
                }
            }   
        }

        public void findLinkFunc(string path)
        {
            if (CopyForm.CheckReportFunctionsFunctions)
            {
                string[] allLinesInFile = File.ReadAllLines(path);
                lLinkFunctionFunction = new List<LinkFunctionsFunctions>();

                foreach (var line in allLinesInFile)
                {
                    bool call = callAndNotCallFuncOrBranch(line);
                    while (call)
                    {
                        LinkFunctionsFunctions linkFunFun = new LinkFunctionsFunctions();

                        string paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                        Match match = new Regex(paternFind).Match(line);

                        if (match.Success)
                        {
                            linkFunFun.QidOut = match.Value;

                            paternFind = "\\w+\\:{0,2}[\\w!=]+\\({1}[\\w\\s:;<>*,&]*\\){1}";
                            match = new Regex(paternFind).Match(line);

                            if (match.Success)
                            {
                                linkFunFun.NameFunctionQidOut = match.Value;

                                paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                                match = new Regex(paternFind).Match(line);

                                match = match.NextMatch().NextMatch().NextMatch();

                                if (match.Success)
                                {
                                    linkFunFun.QidIn = match.Value;

                                    paternFind = "\\w+\\:{0,2}[\\w!=]+\\({1}[\\w\\s:;<>*,&]*\\){1}";
                                    match = new Regex(paternFind).Match(line);

                                    match = match.NextMatch().NextMatch();

                                    if (match.Success)
                                    {
                                        linkFunFun.NameFunctionQidIn = match.Value;
                                    }
                                }
                            }
                        }
                        lLinkFunctionFunction.Add(linkFunFun);
                        break;
                    }
                }

                if (CopyForm.CheckReportFunctionsFunctions & CopyForm.CheckExportInFileExcel)
                {
                    workExcel = new WorkExcel();
                    workExcel.DisplayLinkFunctionFunction(lLinkFunctionFunction);
                }

                if (CopyForm.CheckReportFunctionsFunctions & CopyForm.CheckSaveInFile)
                {
                    NameFile = "akvs_dyn_thread_3.log";

                    foreach (var line in allLinesInFile)
                    {

                        bool call = callAndNotCallFuncOrBranch(line);

                        while (call)
                        {
                            string paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                            Match match = new Regex(paternFind).Match(line);

                            if (match.Success)
                            {
                                File.AppendAllText(Path.Combine(PathFile, NameFile), match.Value + ":f:i\n", Encoding.ASCII);
                                string second = match.Value;
                                match = match.NextMatch().NextMatch().NextMatch();

                                if (match.Success)
                                {
                                    File.AppendAllText(Path.Combine(PathFile, NameFile), match.Value + ":f:i\n", Encoding.ASCII);
                                    File.AppendAllText(Path.Combine(PathFile, NameFile), match.Value + ":f:o\n", Encoding.ASCII);
                                }

                                File.AppendAllText(Path.Combine(PathFile, NameFile), second + ":f:o\n", Encoding.ASCII);
                                break;

                            }
                        }
                    }
                }
            }


        }

        public void findLinkBranch(string path)
        {
            List<string> lBranchKey = new List<string> { "do", "if", "forrange", "while", "catch", "for" };
            if (CopyForm.CheckReportBranchBranch)
            {
                string[] allLinesInFile = File.ReadAllLines(path);

                lLinkBranchBranch = new List<LinkBranchBranch>();

                foreach (var line in allLinesInFile)
                {
                    bool call = callAndNotCallFuncOrBranch(line);
                    while (call)
                    {
                        LinkBranchBranch linkBranBran = new LinkBranchBranch();
                        string paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                        Match match = new Regex(paternFind).Match(line);

                        if (match.Success)
                        {
                            linkBranBran.QidOut = match.Value;

                            paternFind = "\\w+\\:{0,2}[\\w!=]+\\({1}[\\w\\s:;<>*,&]*\\){1}";
                            match = new Regex(paternFind).Match(line);

                            if (match.Success)
                            {
                                linkBranBran.NameBranchQidOut = match.Value;

                                paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                                match = new Regex(paternFind).Match(line);

                                match = match.NextMatch().NextMatch().NextMatch();

                                if (match.Success)
                                {
                                    linkBranBran.QidIn = match.Value;

                                    paternFind = "\\w+\\:{0,2}[\\w!=]+\\({1}[\\w\\s:;<>*,&]*\\){1}";
                                    match = new Regex(paternFind).Match(line);

                                    match = match.NextMatch().NextMatch();
                                    if (match.Success)
                                    {
                                        linkBranBran.NameBranchQidIn = match.Value;
                                    }
                                    else
                                    {
                                        foreach (var item2 in lBranchKey)
                                        {
                                            paternFind = item2;
                                            match = new Regex(paternFind).Match(line);

                                            if (!match.Success)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                linkBranBran.NameBranchQidIn = match.Value;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (var item1 in lBranchKey)
                                {
                                    paternFind = item1;
                                    match = new Regex(paternFind).Match(line);

                                    if (!match.Success)
                                    {
                                        continue;
                                    }

                                    linkBranBran.NameBranchQidOut = match.Value;

                                    paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                                    match = new Regex(paternFind).Match(line);

                                    match = match.NextMatch().NextMatch().NextMatch();

                                    if (match.Success)
                                    {
                                        linkBranBran.QidIn = match.Value;

                                        paternFind = "\\w+\\:{0,2}[\\w!=]+\\({1}[\\w\\s:;<>*,&]*\\){1}";
                                        match = new Regex(paternFind).Match(line);
     
                                        match = match.NextMatch().NextMatch();
                                        if (match.Success)
                                        {
                                            linkBranBran.NameBranchQidIn = match.Value;
                                        }
                                        else
                                        {
                                            foreach (var item2 in lBranchKey)
                                            {
                                                paternFind = item2;
                                                match = new Regex(paternFind).Match(line);

                                                if (!match.Success)
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    linkBranBran.NameBranchQidIn = match.Value;
                                                    break;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                        lLinkBranchBranch.Add(linkBranBran);
                        break;
                    }
                }

                if (CopyForm.CheckReportBranchBranch & CopyForm.CheckExportInFileExcel)
                {
                    workExcel = new WorkExcel();
                    workExcel.DisplayLinkBranchBranch(lLinkBranchBranch);
                }

                if (CopyForm.CheckReportBranchBranch & CopyForm.CheckSaveInFile)
                {
                    NameFile = "akvs_dyn_thread_5.log";

                    List<NumberMarker> lNumbers = new List<NumberMarker>();
                    LinkFunctionsFunctions buildReport = new LinkFunctionsFunctions();

                    foreach (var line in allLinesInFile)
                    {
                        bool call = callAndNotCallFuncOrBranch(line);

                        if (call)
                        {
                            NumberMarker number = new NumberMarker();

                            string paternFind = "[0-9]{1,7}:[0-9]{1,7}";
                            Match match = new Regex(paternFind).Match(line);
                                                        
                            if (match.Success)
                            {
                                number.QidIn = match.Value;
                                match = match.NextMatch().NextMatch().NextMatch();
                                if (match.Success)
                                {
                                    number.QidOut = match.Value;
                                }
                            }
                            lNumbers.Add(number);
                        }
                    }
                    recursing(lNumbers);
                }
            }
        }

        public void recursing(List<NumberMarker> lNumbers)
        {
            
            foreach (var n in lNumbers)
            {
                string saveQidIn = n.QidIn;
                File.AppendAllText(Path.Combine(PathFile, NameFile), n.QidIn + ":f:i\n", Encoding.ASCII);
                findNumber(n, lNumbers);
                File.AppendAllText(Path.Combine(PathFile, NameFile), saveQidIn + ":f:o\n", Encoding.ASCII);
            }
        }

        public void findNumber(NumberMarker n, List<NumberMarker> lNumbers)
        {
            if (lNumbers.Any(x => x.QidIn.Equals(n.QidOut)))
            {

                var find = lNumbers.FindIndex(x => x.QidIn.Equals(n.QidOut));
                if (find != 0)
                {
                    n.QidIn = n.QidOut;
                    File.AppendAllText(Path.Combine(PathFile, NameFile), n.QidIn + ":b:i\n", Encoding.ASCII);
                    n.QidOut = lNumbers[find].QidOut;
                    string saveQidIn = n.QidIn;
                    findNumber(n, lNumbers);
                    File.AppendAllText(Path.Combine(PathFile, NameFile), saveQidIn + ":b:o\n", Encoding.ASCII);
                }
            }
            else
            {
                File.AppendAllText(Path.Combine(PathFile, NameFile), n.QidOut + ":b:i\n", Encoding.ASCII);
                File.AppendAllText(Path.Combine(PathFile, NameFile), n.QidOut + ":b:o\n", Encoding.ASCII);
            }
        }

        public bool callAndNotCallFuncOrBranch(string line)
        {
                Match matchCall = null;
                string paternFind = "";
                if (CopyForm.CheckCalled & !CopyForm.CheckNotCalled & !CopyForm.CheckCallInDynamic)
                {
                    paternFind = "\\scalled";
                    matchCall = new Regex(paternFind).Match(line);
                }
                else if (CopyForm.CheckNotCalled & !CopyForm.CheckCalled & !CopyForm.CheckCallInDynamic)
                {
                    paternFind = "not_called";
                    matchCall = new Regex(paternFind).Match(line);
                }
                else if (CopyForm.CheckCallInDynamic & !CopyForm.CheckCalled & !CopyForm.CheckNotCalled)
                {
                    paternFind = "dynamic_called";
                    matchCall = new Regex(paternFind).Match(line);
                }
                else if (CopyForm.CheckCalled & CopyForm.CheckNotCalled & CopyForm.CheckCallInDynamic)
                {
                    paternFind = "\\scalled";
                    matchCall = new Regex(paternFind).Match(line);
                    if (!matchCall.Success)
                    {
                        paternFind = "not_called";
                        matchCall = new Regex(paternFind).Match(line);
                        if (!matchCall.Success)
                        {
                            paternFind = "dynamic_called";
                            matchCall = new Regex(paternFind).Match(line);
                        }
                    }
                }
            return matchCall.Success;
        }
        
    }
}
