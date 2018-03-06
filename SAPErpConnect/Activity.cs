using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class Activity
    {
        public string CostCenterCode;
        public string ActivityTypeCode;
        public string ActivityCurrency;
        public double ActivityFixPrice;
        public double ActivityVariablePrice;
        public int ActivityFiscalYear;
        public int ActivityMonth;

        public ControllingArea controllingArea;

        public static List<Activity> getAllActivies(RfcDestination destination, ControllingArea iControllingArea, int iFiscalYear)
        {
            List<Activity> ret = new List<Activity>();

            RfcRepository repo = destination.Repository;
            IRfcFunction activityList = repo.CreateFunction("BAPI_CTR_GETACTIVITYPRICES");

            activityList.SetValue("COAREA", iControllingArea.ControllingAreaCode);
            activityList.SetValue("FISCYEAR", iFiscalYear);
            //activityList.SetValue("VERSION", 0);
            activityList.SetValue("PERIODFROM", 1);
            activityList.SetValue("PERIODTO", 12);

            activityList.Invoke(destination);

            IRfcTable activities = activityList.GetTable("ACTPRICES");
            IRfcTable rett = activityList.GetTable("RETURN");


            for (int cuIndex = 0; cuIndex < activities.RowCount; cuIndex++)
            {
                activities.CurrentIndex = cuIndex;
                Activity activityT = new Activity();
                activityT.CostCenterCode = activities.GetString("COSTCENTER");
                activityT.ActivityTypeCode = activities.GetString("ACTTYPE");
                activityT.ActivityCurrency = activities.GetString("CURR_COAREA");
                activityT.ActivityFixPrice = double.Parse(activities.GetString("PRICE_CCURR_FIX"));
                activityT.ActivityVariablePrice = double.Parse(activities.GetString("PRICE_CCURR_VAR"));               
                activityT.ActivityFiscalYear = iFiscalYear;              
                activityT.ActivityMonth = int.Parse(activities.GetString("PERIOD"));
                activityT.controllingArea = iControllingArea;
                ret.Add(activityT);
            }
            return ret;
        }
    }
}
