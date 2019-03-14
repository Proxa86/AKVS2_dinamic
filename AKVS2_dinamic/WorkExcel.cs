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

        public void DisplayNotCallFunctions(List<NotCallFunctions> lNotCallFunc)
        {
            try
            {
                var excelApp = new Excel.Application();

                excelApp.Visible = true;
                excelApp.Workbooks.Add();
                Excel._Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;
                worksheet.Cells[1, "A"] = "Id file : Id function";
                worksheet.Cells[1, "B"] = "Not call functions";

                int i = 0;
                foreach (var result in lNotCallFunc)
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

    }
}
