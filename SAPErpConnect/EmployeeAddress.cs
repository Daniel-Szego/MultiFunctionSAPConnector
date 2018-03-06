using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class EmployeeAddress
    {
        //  BAPI_ADDRESSEMPGETDETAILEDLIST - NAMEOFADDRESSTYPE
        public string TypeOfAddress;

        //  BAPI_ADDRESSEMPGETDETAILEDLIST - STREETANDHOUSENO
        public string Address;

        public static List<EmployeeAddress> getEmployeeAddress(RfcDestination destination, string employeeNum)
        {
            List<EmployeeAddress> ret = new List<EmployeeAddress>();

            RfcRepository repo = destination.Repository;
            IRfcFunction employeeList = repo.CreateFunction("BAPI_ADDRESSEMPGETDETAILEDLIST");
            employeeList.SetValue("EMPLOYEENUMBER", employeeNum);

            employeeList.Invoke(destination);
            IRfcTable employeedetails = employeeList.GetTable("ADDRESS");

            for (int cuIndex = 0; cuIndex < employeedetails.RowCount; cuIndex++)
            {
                EmployeeAddress adr = new EmployeeAddress();
                    adr.TypeOfAddress = employeedetails.GetString("NAMEOFADDRESSTYPE");
                    adr.Address = employeedetails.GetString("STREETANDHOUSENO");
                ret.Add(adr);
            }
            return ret;
        }

    }
}
