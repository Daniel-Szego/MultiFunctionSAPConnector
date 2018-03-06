using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPErpConnect;
using SAP.Middleware.Connector;

namespace SAPSQLConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Start");

                SQLHelper.deleteTables();

                SAPSystemConnectMy sapCfg = new SAPSystemConnectMy();

                RfcDestinationManager.RegisterDestinationConfiguration(sapCfg);
                RfcDestination rfcDest = RfcDestinationManager.GetDestination("K47");

                // fill and save controlling areas
                List<ControllingArea> controllingAreas = ControllingArea.getAllControllingAreas(rfcDest);
                SQLHelper.saveControllingAreas(controllingAreas);

                // fill and save CostCenters
                List<CostCenter> costCSum = new List<CostCenter>();
                foreach (ControllingArea area in controllingAreas)
                {
                    List<CostCenter> css = CostCenter.getAllCostCenters(rfcDest, area);
                    foreach (CostCenter cs in css)
                    {
                        cs.fillDetailInformation(rfcDest);
                    }

                    SQLHelper.saveCostCenrters(css); 
                    //costCSum.AddRange(css);
                }

                
                // fill activity types
                List<ActivityType> acttcpyesSum = new List<ActivityType>();
                foreach (ControllingArea area in controllingAreas)
                {
                    List<ActivityType> acttcpyes = ActivityType.getAllActivityTypes(rfcDest, area);
                    SQLHelper.saveActivityTypes(acttcpyes);
                    //acttcpyesSum.AddRange(acttcpyes);
                }

                // fill activities
                foreach (ControllingArea area in controllingAreas)
                {
                    for (int year = 1990; year < 2010; year++)
                    {
                        List<Activity> actt = Activity.getAllActivies(rfcDest, area, year);
                        SQLHelper.saveActivies(actt);
                    }
                }



                //ControllingArea ca = new ControllingArea() { ControllingAreaCode = "1000", ControllingAreaName = "" };

                //List<ActivityType> acttcpyes = ActivityType.getAllActivityTypes(rfcDest, ca);

                //List<Activity> acts = Activity.getAllActivies(rfcDest, ca, 1999);

                int i = 0;
                i++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }

            Console.WriteLine("End of import");
            Console.ReadLine();
        }
    }
}
