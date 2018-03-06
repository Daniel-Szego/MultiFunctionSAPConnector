using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpSharePoint.BdcSAPSAP
{
    /// <summary>
    /// This class contains the properties for Entity1. The properties keep the data for Entity1.
    /// If you want to rename the class, don't forget to rename the entity in the model xml as well.
    /// </summary>
    public partial class Employee
    {
        //TODO: Implement additional properties here. The property Message is just a sample how a property could look like.
        public string PeronalNr { get; set; }

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
