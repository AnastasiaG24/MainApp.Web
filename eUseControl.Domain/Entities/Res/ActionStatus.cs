using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Res;


namespace eUseControl.Domain.Entities.Res
{
    public class ActionStatus
    {
        public bool Status { get; set; }
        public string StatusMessage { get; set; }
        public string SessionKey { get; set; }
    }
}
