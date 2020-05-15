using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SRS.Models
{
    public class WorkOrder
    {
       
        public int ID { get; set; }
        [DisplayName]
        public string Description { get; set; }
        public string MostRecentNote { get; set; }
        public string RequestStatus { get; set; }

        public string WONumber { get; set; }
        public string Workflow { get; set; }
        public string WOTitle { get; set; }

        public string ClientWorkRequestIDPrefix { get; set; }
        public string ClientWorkRequestIDNumber { get; set; }
        public string ZurichSubProjectCode { get; set; }
        public string BusinessUnitID { get; set; }
        public string ClientWorkRequestID { get; set; }
        public string RelatedWorkOrderRequests { get; set; }

        public string GAMSRNumber { get; set; }
        public string GAMSRNumberLink { get; set; }

        public string ClientSAPID { get; set; }
        public string ClientStrategicProgramID { get; set; }
        public string ClientProgramID { get; set; }
        public string ClientProjectID { get; set; }
        public string ClientStrategicProjectID { get; set; }
      

    }
}
