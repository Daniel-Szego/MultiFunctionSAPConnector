using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class EmployeeDetail
    {
        // BAPI_PERSDATA_GETDETAILEDLIST - FIRSTNAME
        public string FirstName;

        // BAPI_PERSDATA_GETDETAILEDLIST - LASTNAME
        public string LastName;

        // BAPI_PERSDATA_GETDETAILEDLIST - NAMEOFLANGUAGE
        public string Language;

        // BAPI_PERSDATA_GETDETAILEDLIST - NAMEOFNATIONALI
        public string Nationality;

        public static EmployeeDetail getEmployeeDetail(RfcDestination destination, string employeeNum)
        {
            EmployeeDetail ret = new EmployeeDetail();

            RfcRepository repo = destination.Repository;
            IRfcFunction employeeList = repo.CreateFunction("BAPI_PERSDATA_GETDETAILEDLIST");
            employeeList.SetValue("EMPLOYEENUMBER", employeeNum);

            employeeList.Invoke(destination);
            IRfcTable employeedetails = employeeList.GetTable("PERSONALDATA");

            for (int cuIndex = 0; cuIndex < employeedetails.RowCount; cuIndex++)
            {
                ret.FirstName = employeedetails.GetString("FIRSTNAME");
                ret.LastName = employeedetails.GetString("LASTNAME");
                ret.Nationality = employeedetails.GetString("NAMEOFNATIONALITY");
                ret.Language = employeedetails.GetString("NAMEOFLANGUAGE");
            }

            return ret;
        }



    }
}
