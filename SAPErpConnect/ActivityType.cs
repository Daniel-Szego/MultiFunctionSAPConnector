using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class ActivityType
    {
        //public string ControllingAreaCode;
        public string ActivityTypeCode;
        public string ActivityTypeName;
        public string ActivityDescription;

        public ControllingArea ControllingArea;

        public static List<ActivityType> getAllActivityTypes(RfcDestination destination, ControllingArea iControllingArea)
        {
            List<ActivityType> ret = new List<ActivityType>();

            RfcRepository repo = destination.Repository;
            IRfcFunction activityTypeList = repo.CreateFunction("BAPI_ACTIVITYTYPE_GETLIST");

            activityTypeList.SetValue("CONTROLLINGAREA", iControllingArea.ControllingAreaCode);
            activityTypeList.SetValue("DATE", DateTime.Now);

            activityTypeList.Invoke(destination);

            IRfcTable activityTypes = activityTypeList.GetTable("ACTIVITYTYPE_LIST");

            for (int cuIndex = 0; cuIndex < activityTypes.RowCount; cuIndex++)
            {
                activityTypes.CurrentIndex = cuIndex;
                ActivityType activityT = new ActivityType();
                activityT.ActivityTypeCode = activityTypes.GetString("ACTTYPE");
                activityT.ActivityTypeName = activityTypes.GetString("NAME");
                activityT.ActivityDescription = activityTypes.GetString("DESCRIPT");
                activityT.ControllingArea = iControllingArea;
                ret.Add(activityT);
            }
            return ret;
        }
    }
}
