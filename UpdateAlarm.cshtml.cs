using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AlarmHandling.Models;
using System.Data.SqlClient;

namespace AlarmHandling.Pages
{
    public class UpdataAlarmModel : PageModel
    {
        public AlarmsModel AlarmDB = new AlarmsModel();
            public int AlarmId;
        public string connectionString;

        public void OnGet()
        {
            AlarmId = Convert.ToInt16(Request.Query["AlarmId"]);

            AlarmsModel Alarm = new AlarmsModel();
            connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial" +
                                " Catalog=Scada_Systems2;Data Source=DESKTOP-M7KT76S\\SQLEXPRESS";
            AlarmDB = Alarm.GetAlarmData(connectionString, AlarmId);


        }
        public void OnPost()
        {

            
            AlarmsModel alarm = new AlarmsModel();
            alarm.AlarmId = Convert.ToInt32(Request.Form["AlarmId"]);
            alarm.AcknowledgePerson = Request.Form["AcknowledgePerson"];

            connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial" +
                                " Catalog=Scada_Systems2;Data Source=DESKTOP-M7KT76S\\SQLEXPRESS";
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = String.Format("UPDATE ALARMDATA SET Acknowledge=1, " +
                " AcknowledgePerson='{0}' from ALARMDATA where AlarmID ='{1}'", 
                alarm.AcknowledgePerson, alarm.AlarmId) ;

            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            cmd.ExecuteNonQuery();


            Response.Redirect("./Alarmdata");

        }
    }
}
