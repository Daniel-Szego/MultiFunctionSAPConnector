using SAP.Middleware.Connector;
using SAPErpConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SAPBDCConnect.SABCDC
{
    public partial class BusinessAreaEntityService
    {
        static RfcDestination rfcDest = null;

        static BusinessAreaEntityService()
        {
            SAPSystemConnectMy sapCfg = new SAPSystemConnectMy();
            RfcDestinationManager.RegisterDestinationConfiguration(sapCfg);
            rfcDest = RfcDestinationManager.GetDestination("K47");            
        }

        public static IEnumerable<BusinessAreaEntity> ReadList()
        {
            List<BusinessAreaEntity> ret = new List<BusinessAreaEntity>();
             //get all Basic employee information from SAP

            List<BusinessArea> areas = SAPErpConnect.BusinessArea.getAllBusinessAreas(rfcDest);
            foreach (SAPErpConnect.BusinessArea area in areas)
            {
                ret.Add(new BusinessAreaEntity(area));
            }

            //CompanyEntity compent = new CompanyEntity();
            //compent.Company = "Comp1";
            //compent.Name = "Comp1";
            //ret.Add(compent);

            return ret;          
        }

        public static BusinessAreaEntity ReadItem(string Code)
        {
            BusinessAreaEntity ret = null;
            // get all Basic employee information from SAP

            List<BusinessArea> areas = SAPErpConnect.BusinessArea.getAllBusinessAreas(rfcDest);
            foreach (SAPErpConnect.BusinessArea area in areas)
            {
                if (area.BusinessAreaCode.Equals(Code))
                {
                    ret = new BusinessAreaEntity(area);
                }
            }

            //ret = new CompanyEntity();
            //ret.Company = "Comp1";
            //ret.Name = "Comp1";

            return ret; 
        }

    }
}
