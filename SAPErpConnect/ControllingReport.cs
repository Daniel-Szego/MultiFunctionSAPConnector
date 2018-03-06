using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class ControllingReport
    {

        public static void GetControllingReport(RfcDestination destination)
        {
            try
            {
                RfcRepository repo = destination.Repository;
                IRfcFunction report = repo.CreateFunction("RFC_READ_TABLE");

                report.Invoke(destination);
            }
            catch (Exception ex)
            {
                int i = 0;
                i++;
            }


        }
    }
}
