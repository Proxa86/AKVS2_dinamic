using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKVS2_dinamic
{
    class LinkBranchBranch
    {
        public string QidOut { get; set; } // вызывающая ветвь
        public string NameBranchQidOut { get; set; }
        public string QidIn { get; set; } // вызываемая ветвь
        public string NameBranchQidIn { get; set; }
    }
}
