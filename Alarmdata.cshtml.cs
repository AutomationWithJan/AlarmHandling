using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlarmHandling.Models;

namespace AlarmHandling
{
    public class AlarmdataModel : PageModel
    {
        public List<AlarmsModel> AlarmParameterList = new List<AlarmsModel>();
        public void OnGet()
        {
            AlarmsModel Alarm = new AlarmsModel();
            AlarmParameterList = Alarm.GetAlarmsModelsParameters();
        }
    }
}
