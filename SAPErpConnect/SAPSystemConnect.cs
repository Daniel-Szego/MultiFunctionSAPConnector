using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace SAPErpConnect
{
    public class SAPSystemConnectMy : IDestinationConfiguration
    {

        bool IDestinationConfiguration.ChangeEventsSupported()
        {
            //throw new NotImplementedException();
            return true;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        //{
        //    add { 
        //        //throw new NotImplementedException(); 
        //    }
        //    remove 
        //    { 
        //        //throw new NotImplementedException(); 
        //    }
        //}

        RfcConfigParameters IDestinationConfiguration.GetParameters(string destinationName)
        {
            if ("K47".Equals(destinationName))
            {
                RfcConfigParameters parms = new RfcConfigParameters();
                parms.Add(RfcConfigParameters.AppServerHost, "169.254.220.238");
                parms.Add(RfcConfigParameters.SystemNumber, "00");
                parms.Add(RfcConfigParameters.User, "root");
                parms.Add(RfcConfigParameters.Password, "maximal");
                parms.Add(RfcConfigParameters.Client, "800");
                parms.Add(RfcConfigParameters.Language, "DE");
                parms.Add(RfcConfigParameters.PoolSize, "50");
                parms.Add(RfcConfigParameters.MaxPoolSize, "100");
                parms.Add(RfcConfigParameters.IdleTimeout, "6000");

                return parms;
            }
            return null;
        }


    }
}
