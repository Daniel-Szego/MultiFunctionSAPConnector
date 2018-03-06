using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPErpConnect
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start");
            SAPSystemConnectMy sapCfg = new SAPSystemConnectMy();

            RfcDestinationManager.RegisterDestinationConfiguration(sapCfg);
            RfcDestination rfcDest = RfcDestinationManager.GetDestination("K47");

            Workflow.startWorkflow(rfcDest);
            //ControllingArea.getAllControllingAreas(rfcDest);

            //ControllingArea ca = new ControllingArea() { ControllingAreaCode = "1000", ControllingAreaName = "" };
            //List<CostCenter> css = CostCenter.getAllCostCenters(rfcDest, ca);
            //foreach (CostCenter cs in css)
            //{
            //    cs.fillDetailInformation(rfcDest);
            //}

            //List<ActivityType> acttcpyes = ActivityType.getAllActivityTypes(rfcDest, ca);

            //List<Activity> acts = Activity.getAllActivies(rfcDest, ca, 1999);

            int i=0;
            i++;
            
            //ControllingReport.GetControllingReport(rfcDest);

            //Customers customer = new Customers();
            //customer.GetCustomerDetails(rfcDest);

            //Console.WriteLine("Customer Info");

            //Console.WriteLine(string.Format("CustomerNo - {0} ",customer.CustomerNo));
            //Console.WriteLine(string.Format("CustomerName - {0} ",customer.CustomerName));
            //Console.WriteLine(string.Format("Address - {0} ",customer.Address));
            //Console.WriteLine(string.Format("City - {0} ",customer.City));
            //Console.WriteLine(string.Format("StateProvince - {0} ",customer.StateProvince));
            //Console.WriteLine(string.Format("CountryCode - {0} ",customer.CountryCode));
            //Console.WriteLine(string.Format("Region - {0} ",customer.Region));
            //Console.WriteLine(string.Format("Industry - {0} ",customer.Industry));
            //Console.WriteLine(string.Format("District - {0} ",customer.District));
            //Console.WriteLine(string.Format("SalesOrg - {0} ",customer.SalesOrg));
            //Console.WriteLine(string.Format("DistributionChannel - {0} ",customer.DistributionChannel));
            //Console.WriteLine(string.Format("Division - {0} ",customer.Division));

            //List<Company> comps = Company.getAllCompanyNames(rfcDest);
            //foreach (Company comp in comps)
            //{ 
            //    Console.WriteLine(string.Format("Company {0} - {1}", comp.ID, comp.Name));
            //}

            //Console.WriteLine(" - ");

            //List<BusinessArea> businesAreas = BusinessArea.getAllBusinessAreas(rfcDest);
            //foreach (BusinessArea are in businesAreas)
            //{
            //    Console.WriteLine(string.Format("Business Area {0} - {1}", are.Code, are.Name));                            
            //}

            //List<Employee> emps = Employee.getAllEmployees(rfcDest);
            //foreach (Employee emp in emps)
            //{
            //    Console.WriteLine(string.Format("Employee {0} - {1} - {2} - {3}", emp.PeronalNr, emp.empDetail.FirstName, emp.empDetail.LastName, emp.empAddr.Count == 0 ? string.Empty : emp.empAddr[0].Address));
            //}

            Console.ReadLine();

            System.Environment.Exit(0);
        }
    }
}
