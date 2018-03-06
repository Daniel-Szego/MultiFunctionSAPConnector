using SAPErpConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPBDCConnect.SABCDC
{
    /// <summary>
    /// This class contains the properties for Entity1. The properties keep the data for Entity1.
    /// If you want to rename the class, don't forget to rename the entity in the model xml as well.
    /// </summary>
    public partial class EmployeeEntity
    {
        //TODO: Implement additional properties here. The property Message is just a sample how a property could look like.
        public EmployeeEntity(Employee emp)
        {
            this.Job = emp.Job;
            this.JobID = emp.JobID;
            this.Name = emp.Name;
            this.Organisation = emp.Organisation;
            this.OrgID = emp.OrgID;
            this.PeronalNr = emp.PeronalNr;
        }

        public EmployeeEntity()
        {
        }


        // BAPI_EMPLOYEE_GETLIST - PERSNR
        public string PeronalNr {get; set;}

        // BAPI_EMPLOYEE_GETLIST - ENAME
        public string Name { get; set; }

        // BAPI_EMPLOYEE_GETLIST - ORG_ID
        public string OrgID { get; set; }

        // BAPI_EMPLOYEE_GETLIST - ORG_TEXT
        public string Organisation { get; set; }

        // BAPI_EMPLOYEE_GETLIST - JOB_ID
        public string JobID { get; set; }

        // BAPI_EMPLOYEE_GETLIST - JOB_TEXT
        public string Job { get; set; }
    }
}
