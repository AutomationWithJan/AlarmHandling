using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AlarmHandling.Models
{
    public class AlarmsModel : PageModel
    {
        public int AlarmId { get; set;  }
        public string ActivationTime { get; set; }
        public string Acknowledge { get; set; }
        public string AcknowledgeTime { get; set; }
        public string AcknowledgePerson { get; set; }
        public string TypeOfAlarm { get; set; }
        public int TagId { get; set; }
        public string AlarmLimits { get; set; }
        public string TextualDescription { get; set; }
        string connectionstring = "Integrated Security=SSPI;Persist Security Info=False;Initial" +
                                " Catalog=Scada_Systems2;Data Source=DESKTOP-M7KT76S\\SQLEXPRESS";

        public List<AlarmsModel> GetAlarmsModelsParameters()
        {
            List<AlarmsModel> AlarmParameterList = new List<AlarmsModel>();
            
            SqlConnection con = new SqlConnection(connectionstring);
            string sqlQuery = "select AlarmId, ActivationTime, Acknowledge, AcknowledgeTime, AcknowledgePerson, TypeOfAlarm, TagId, AlarmLimits, TextualDescription from ALARMDATA";
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    AlarmsModel AlarmParameter = new AlarmsModel();

                    AlarmParameter.AlarmId = Convert.ToInt32(dr["AlarmId"]);
                    AlarmParameter.ActivationTime =  dr["ActivationTime"].ToString();
                    AlarmParameter.Acknowledge = dr["Acknowledge"].ToString();
                    AlarmParameter.AcknowledgeTime = dr["AcknowledgeTime"].ToString();
                   
                    AlarmParameter.AcknowledgePerson = dr["AcknowledgePerson"].ToString();
                    AlarmParameter.TypeOfAlarm = dr["TypeOfAlarm"].ToString();
                    AlarmParameter.TagId = Convert.ToInt32(dr["TagId"]);
                    AlarmParameter.AlarmLimits = dr["AlarmLimits"].ToString();
                    AlarmParameter.TextualDescription = dr["TextualDescription"].ToString();
                    
                   


                    AlarmParameterList.Add(AlarmParameter);
                }

            }
            return AlarmParameterList;


        }
        public AlarmsModel GetAlarmData(string connectionString, int AlarmId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string selectSQL = "Select AlarmId, AcknowledgePerson from ALARMDATA where AlarmID ="+ AlarmId;
            con.Open();
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();

            AlarmsModel alarm = new AlarmsModel();

            if(dr!=null)
            {
                while(dr.Read())
                {
                    alarm.AlarmId = Convert.ToInt32(dr["AlarmId"]);
                    alarm.AcknowledgePerson = dr["AcknowledgePerson"].ToString();
                }
            }


            return alarm;
        }
        public void OnGet()
        {
        }
    }
}
