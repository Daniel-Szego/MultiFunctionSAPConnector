using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class Company
    {
        public string ID;
        public string Name;

        public static List<Company> getAllCompanyNames(RfcDestination destination)
        {
            List<Company> ret = new List<Company>();

            RfcRepository repo = destination.Repository;
            IRfcFunction companyList = repo.CreateFunction("BAPI_COMPANY_GETLIST");

            companyList.Invoke(destination);
            IRfcTable companies = companyList.GetTable("COMPANY_LIST");

            for (int cuIndex = 0; cuIndex < companies.RowCount; cuIndex++)
            {
                companies.CurrentIndex = cuIndex;
                Company comp = new Company();
                comp.ID = companies.GetString("Company");
                comp.Name = companies.GetString("Name1");
                ret.Add(comp);
            }
            return ret;
        }

    }
}
