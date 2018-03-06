using SAPErpConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPErpSharePoint
{
    public partial class EmployeeEntity
    {
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
