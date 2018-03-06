using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class Employee
    {
        // BAPI_EMPLOYEE_GETLIST - PERSNR
        public string PeronalNr;

        // BAPI_EMPLOYEE_GETLIST - ENAME
        public string Name;

        // BAPI_EMPLOYEE_GETLIST - ORG_ID
        public string OrgID;

        // BAPI_EMPLOYEE_GETLIST - ORG_TEXT
        public string Organisation;

        // BAPI_EMPLOYEE_GETLIST - JOB_ID
        public string JobID;

        // BAPI_EMPLOYEE_GETLIST - JOB_TEXT
        public string Job;

        public EmployeeDetail empDetail;

        public List<EmployeeAddress> empAddr;

        public static List<Employee> getAllEmployees(RfcDestination destination)
        {
            List<Employee> ret = new List<Employee>();

            RfcRepository repo = destination.Repository;
            IRfcFunction employeeList = repo.CreateFunction("BAPI_EMPLOYEE_GETLIST");
            employeeList.SetValue("ORG_SEARK", "*");
            employeeList.SetValue("JOB_SEARK", "*");
            employeeList.SetValue("SUR_NAME_SEARK", "*");
            employeeList.SetValue("LST_NAME_SEARK", "*");

            employeeList.Invoke(destination);
            IRfcTable employees = employeeList.GetTable("EMPLOYEE_LIST");

            for (int cuIndex = 0; cuIndex < employees.RowCount; cuIndex++)
            {
                employees.CurrentIndex = cuIndex;
                Employee emp = new Employee();
                emp.PeronalNr = employees.GetString("PERNR");
                emp.Name = employees.GetString("ENAME");
                emp.OrgID = employees.GetString("ORG_ID");
                emp.Organisation = employees.GetString("ORG_TEXT");
                emp.JobID = employees.GetString("JOB_ID");
                emp.Job = employees.GetString("JOB_TEXT");

                emp.empDetail = EmployeeDetail.getEmployeeDetail(destination, emp.PeronalNr);

                emp.empAddr = EmployeeAddress.getEmployeeAddress(destination, emp.PeronalNr);

                ret.Add(emp);
            }
            return ret;
        }

    }
}
