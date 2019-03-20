using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace AKVS2_dinamic
{
    class WorkExcel
    {

        public void DisplayFunctions(List<Functions> lFunc)
        {
            try
            {
                var excelApp = new Excel.Application();

                excelApp.Visible = true;
                excelApp.Workbooks.Add();
                Excel._Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;
                worksheet.Cells[1, "A"] = "Id file : Id function";
                worksheet.Cells[1, "B"] = "Functions";

                int i = 0;
                foreach (var result in lFunc)
                {
                    worksheet.Cells[i + 2, "A"].NumberFormat = "@";
                    //worksheet.Cells[i + 2, "B"].NumberFormat = "@";
                    worksheet.Cells[i + 2, "A"] = result.QidIn;
                    worksheet.Cells[i + 2, "B"] = result.NameFunction;
                    ++i;
                }

                worksheet.Columns[1].AutoFit();
                worksheet.Columns[2].AutoFit();
            }
            catch(Exception ex)
            {
                MessageBox.Show("List is empty!");
            }     
        }

        public void DisplayLinkFunctionFunction(List<LinkFunctionsFunctions> lLinkFuncFunc)
        {
            try
            {
                var excelApp = new Excel.Application();

                excelApp.Visible = true;
                excelApp.Workbooks.Add();
                Excel._Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;

                worksheet.Cells[1, "A"] = "Id file : IdOut function";
                worksheet.Cells[1, "B"] = "Function external";
                worksheet.Cells[1, "C"] = "Id file : IdIn function";
                worksheet.Cells[1, "D"] = "Function internal";

                int i = 0;
                foreach (var result in lLinkFuncFunc)
                {
                    worksheet.Cells[i + 2, "A"].NumberFormat = "@";
                    worksheet.Cells[i + 2, "C"].NumberFormat = "@";

                    worksheet.Cells[i + 2, "A"] = result.QidOut;
                    worksheet.Cells[i + 2, "B"] = result.NameFunctionQidOut;
                    worksheet.Cells[i + 2, "C"] = result.QidIn;
                    worksheet.Cells[i + 2, "D"] = result.NameFunctionQidIn;
                    ++i;
                }

                worksheet.Columns[1].AutoFit();
                worksheet.Columns[2].AutoFit();
                worksheet.Columns[3].AutoFit();
                worksheet.Columns[4].AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("List is empty!");
            }
        }

        public void DisplayLinkBranchBranch(List<LinkBranchBranch> lLinkBranBran)
        {
            try
            {
                var excelApp = new Excel.Application();

                excelApp.Visible = true;
                excelApp.Workbooks.Add();
                Excel._Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;

                worksheet.Cells[1, "A"] = "Id file : IdOut branch";
                worksheet.Cells[1, "B"] = "Branch external";
                worksheet.Cells[1, "C"] = "Id file : IdIn branch";
                worksheet.Cells[1, "D"] = "Branch internal";

                int i = 0;
                foreach (var result in lLinkBranBran)
                {
                    worksheet.Cells[i + 2, "A"].NumberFormat = "@";
                    worksheet.Cells[i + 2, "C"].NumberFormat = "@";

                    worksheet.Cells[i + 2, "A"] = result.QidOut;
                    worksheet.Cells[i + 2, "B"] = result.NameBranchQidOut;
                    worksheet.Cells[i + 2, "C"] = result.QidIn;
                    worksheet.Cells[i + 2, "D"] = result.NameBranchQidIn;
                    ++i;
                }

                worksheet.Columns[1].AutoFit();
                worksheet.Columns[2].AutoFit();
                worksheet.Columns[3].AutoFit();
                worksheet.Columns[4].AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("List is empty!");
            }
        }

    }
}
