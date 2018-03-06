using SAP.Middleware.Connector;
using SAPErpConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SAPBDCConnect.SABCDC
{
    public partial class CompanyEntityService
    {
        static RfcDestination rfcDest = null;

        static CompanyEntityService()
        {
            SAPSystemConnectMy sapCfg = new SAPSystemConnectMy();
            RfcDestinationManager.RegisterDestinationConfiguration(sapCfg);
            rfcDest = RfcDestinationManager.GetDestination("K47");            
        }

        public static IEnumerable<CompanyEntity> ReadList()
        {
            List<CompanyEntity> ret = new List<CompanyEntity>();
             //get all Basic employee information from SAP

            List<Company> comps = SAPErpConnect.Company.getAllCompanyNames(rfcDest);
            foreach (SAPErpConnect.Company comp in comps)
            {
                ret.Add(new CompanyEntity(comp));
            }

            //CompanyEntity compent = new CompanyEntity();
            //compent.Company = "Comp1";
            //compent.Name = "Comp1";
            //ret.Add(compent);

            return ret;          
        }

        public static CompanyEntity ReadItem(string Company)
        {
            CompanyEntity ret = null;
            // get all Basic employee information from SAP

            List<Company> copms = SAPErpConnect.Company.getAllCompanyNames(rfcDest);
            foreach (SAPErpConnect.Company comp in copms)
            {
                if (comp.ID.Equals(Company))
                {
                    ret = new CompanyEntity(comp);
                }
            }

            //ret = new CompanyEntity();
            //ret.Company = "Comp1";
            //ret.Name = "Comp1";

            return ret; 
        }
    }
}
