using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class CostCenter
    {
        //public string ControllingAreaCode;
        public string CostCenterCode;
        public string CostCenterName;
        public string CostCenterAddressStreet;
        public string CostCenterAddressCity;
        public string CostCenterAddressDistrict;
        public string CostCenterAddressPOBOX;
        public string PersonInCharge;

        public ControllingArea ControllingArea;

        public static List<CostCenter> getAllCostCenters(RfcDestination destination, ControllingArea iControllingArea)
        {
            List<CostCenter> ret = new List<CostCenter>();

            RfcRepository repo = destination.Repository;
            IRfcFunction costCenterList = repo.CreateFunction("BAPI_COSTCENTER_GETLIST");

            costCenterList.SetValue("CONTROLLINGAREA", iControllingArea.ControllingAreaCode);

            costCenterList.Invoke(destination);

            IRfcTable costCenters = costCenterList.GetTable("COSTCENTER_LIST");

            for (int cuIndex = 0; cuIndex < costCenters.RowCount; cuIndex++)
            {
                costCenters.CurrentIndex = cuIndex;
                CostCenter costC = new CostCenter();
                costC.CostCenterCode = costCenters.GetString("COSTCENTER");
                costC.CostCenterName = costCenters.GetString("COCNTR_TXT");
                costC.ControllingArea = iControllingArea;
                ret.Add(costC);
            }
            return ret;
        }

        public void fillDetailInformation(RfcDestination destination)
        {

            RfcRepository repo = destination.Repository;
            IRfcFunction costCenterList = repo.CreateFunction("BAPI_COSTCENTER_GETDETAIL");

            costCenterList.SetValue("CONTROLLINGAREA", ControllingArea.ControllingAreaCode);
            costCenterList.SetValue("COSTCENTER", this.CostCenterCode);
            costCenterList.SetValue("DATE", DateTime.Now);
            
            costCenterList.Invoke(destination);

            this.PersonInCharge = costCenterList.GetValue("PERSON_IN_CHARGE").ToString();
            IRfcStructure costCenters = costCenterList.GetStructure("ADDRESS");

            this.CostCenterAddressCity = costCenters.GetString("CITY");
            this.CostCenterAddressDistrict = costCenters.GetString("DISTRICT");
            this.CostCenterAddressPOBOX = costCenters.GetString("PO_BOX");
            this.CostCenterAddressStreet = costCenters.GetString("STREET");
        }
    }
}
