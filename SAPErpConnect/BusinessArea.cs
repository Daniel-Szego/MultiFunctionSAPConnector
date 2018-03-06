using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class BusinessArea
    {
        public string BusinessAreaCode;
        public string BusinessAreaName;

        public static List<BusinessArea> getAllBusinessAreas(RfcDestination destination)
        {
            List<BusinessArea> ret = new List<BusinessArea>();

            RfcRepository repo = destination.Repository;
            IRfcFunction businessAreaList = repo.CreateFunction("BAPI_BUSINESSAREA_GETLIST");

            businessAreaList.Invoke(destination);
            IRfcTable businessAreas = businessAreaList.GetTable("BUSINESSAREA_LIST");

            for (int cuIndex = 0; cuIndex < businessAreas.RowCount; cuIndex++)
            {
                businessAreas.CurrentIndex = cuIndex;
                BusinessArea area = new BusinessArea();
                area.BusinessAreaCode = businessAreas.GetString("BUS_AREA");
                area.BusinessAreaName = businessAreas.GetString("BUS_AR_DES");
                ret.Add(area);
            }
            return ret;
        }

    }
}
