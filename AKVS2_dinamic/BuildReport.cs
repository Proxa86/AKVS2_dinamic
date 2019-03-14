using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKVS2_dinamic
{
    class BuildReport
    {
        //public void buildReportExcel(int index)
        //{
        //    WorkExcel workExcel = new WorkExcel();

        //    switch (index)
        //    {
        //        case 0:
        //            workExcel.DisplayInExcelFoundMarker(ComparisonTmpMarkers.lResultAllMarkers);
        //            break;
        //        case 1:
        //            workExcel.DisplayInExcelNotFoundMarker(ComparisonTmpMarkers.lResultNotFoundMarker);
        //            break;
        //        case 2:
        //            workExcel.DisplayInExcelFoundInBinMarker(ComparisonTmpMarkers.lResultMarkersInBin);
        //            break;
        //    }            
        //}

        public void buildReportExcel()
        {
            WorkExcel workExcel = new WorkExcel();
            workExcel.DisplayNotCallFunctions(FindMiningMarker.lNotCallFunctions);
        }
    }
}
