using SAP.Middleware.Connector;
using SAPErpConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SAPErpSharePoint.BDCSAP
{
    public partial class EmployeeEntityService
    {
        public static EmployeeEntity ReadItem(string id)
        {
            EmployeeEntity ret = null;
            // get all Basic employee information from SAP
            SAPSystemConnectMy sapCfg = new SAPSystemConnectMy();

            RfcDestinationManager.RegisterDestinationConfiguration(sapCfg);
            RfcDestination rfcDest = RfcDestinationManager.GetDestination("K47");


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
            SAPSystemConnectMy sapCfg = new SAPSystemConnectMy();

            RfcDestinationManager.RegisterDestinationConfiguration(sapCfg);
            RfcDestination rfcDest = RfcDestinationManager.GetDestination("K47");


            List<Employee> emps = Employee.getAllEmployees(rfcDest);
            foreach (Employee emp in emps)
            {
               ret.Add(new EmployeeEntity(emp));
            }
            return ret;
        
        }
    }
}
