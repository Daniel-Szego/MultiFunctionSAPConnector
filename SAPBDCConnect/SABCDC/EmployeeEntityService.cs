using SAP.Middleware.Connector;
using SAPErpConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPBDCConnect.SABCDC
{
    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for Entity1.
    /// </summary>
    public class EmployeeEntityService
    {
        static RfcDestination rfcDest = null;

        static EmployeeEntityService()
        {
            SAPSystemConnectMy sapCfg = new SAPSystemConnectMy();
            RfcDestinationManager.RegisterDestinationConfiguration(sapCfg);
            rfcDest = RfcDestinationManager.GetDestination("K47");            
        }

        /// <summary>
        /// This is a sample specific finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <param name="PeronalNr"></param>
        /// <returns>Entity1</returns>
        public static EmployeeEntity ReadItem(string id)
        {
            EmployeeEntity ret = null;
            // get all Basic employee information from SAP

            List<Employee> emps = Employee.getAllEmployees(rfcDest);
            foreach (Employee emp in emps)
            {
                if (emp.PeronalNr.Equals(id))
                {
                    ret = new EmployeeEntity(emp);
                }
            }
            return ret;
        }

        public static IEnumerable<EmployeeEntity> ReadList()
        {
            List<EmployeeEntity> ret = new List<EmployeeEntity>();
            // get all Basic employee information from SAP

            List<Employee> emps = Employee.getAllEmployees(rfcDest);
            foreach (Employee emp in emps)
            {
                ret.Add(new EmployeeEntity(emp));
            }
            return ret;
        }
    }
}
