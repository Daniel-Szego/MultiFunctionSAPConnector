using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class ControllingArea
    {
        public string ControllingAreaCode;
        public string ControllingAreaName;

        public static List<ControllingArea> getAllControllingAreas(RfcDestination destination)
        {
            List<ControllingArea> ret = new List<ControllingArea>();

            RfcRepository repo = destination.Repository;
            IRfcFunction controllingAreaList = repo.CreateFunction("BAPI_CONTROLLINGAREA_GETLIST");

            controllingAreaList.Invoke(destination);
            IRfcTable controllingAreas = controllingAreaList.GetTable("CONTROLLINGAREA_LIST");

            for (int cuIndex = 0; cuIndex < controllingAreas.RowCount; cuIndex++)
            {
                controllingAreas.CurrentIndex = cuIndex;
                ControllingArea area = new ControllingArea();
                area.ControllingAreaCode = controllingAreas.GetString("CO_AREA");
                area.ControllingAreaName = controllingAreas.GetString("Name");
                ret.Add(area);
            }
            return ret;

        }

    }
}
