using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpConnect
{
    public class Workflow
    {

        public static void startWorkflow(RfcDestination destination)
        {
            try
            {
                RfcRepository repo = destination.Repository;
                IRfcFunction wf = repo.CreateFunction("SAP_WAPI_START_WORKFLOW");

                wf.Invoke(destination);
                //IRfcTable companies = companyList.GetTable("COMPANY_LIST");
            }
            catch (Exception ex)
            {
                int i=0;
                i++;
            }
        }

    }
}
