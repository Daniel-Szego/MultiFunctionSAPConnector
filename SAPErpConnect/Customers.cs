using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPErpConnect
{
    public class Customers
    {
        public string CustomerNo;
        public string CustomerName;
        public string Address;
        public string City;
        public string StateProvince;
        public string CountryCode;
        public string PostalCode;
        public string Region;
        public string Industry;
        public string District;
        public string SalesOrg;
        public string DistributionChannel;
        public string Division;

        public void GetCustomerDetails(RfcDestination destination)
        {
            try
            {
                RfcRepository repo = destination.Repository;
                IRfcFunction customerList = repo.CreateFunction("BAPI_CUSTOMER_GETLIST");

                //customerList.Invoke(destination);

                IRfcTable idRange = customerList.GetTable("IDRANGE");
                idRange.Insert();
                idRange.SetValue("SIGN", "I");
                idRange.SetValue("OPTION", "BT");
                idRange.SetValue("LOW", "111111");
                idRange.SetValue("HIGH", "999999");                

                //add selection range to customerList function to search for all customers
                customerList.SetValue("IDRANGE", idRange);
                customerList.SetValue("MAXROWS", 20);

                customerList.Invoke(destination);

                IRfcTable addressData = customerList.GetTable("ADDRESSDATA");
                IRfcTable idrange = customerList.GetTable("IDRANGE");
                IRfcTable specialdata = customerList.GetTable("SPECIALDATA");

                for (int cuIndex = 0; cuIndex < addressData.RowCount; cuIndex++)
                {

                    addressData.CurrentIndex = cuIndex;
                    IRfcFunction customerHierachy = repo.CreateFunction("BAPI_CUSTOMER_GETSALESAREAS");
                    IRfcFunction customerDetail1 = repo.CreateFunction("BAPI_CUSTOMER_GETDETAIL1");
                    IRfcFunction customerDetail2 = repo.CreateFunction("BAPI_CUSTOMER_GETDETAIL2");

                    this.CustomerNo = addressData.GetString("Customer");
                    this.CustomerName = addressData.GetString("Name");
                    this.Address = addressData.GetString("Street");
                    this.City = addressData.GetString("City");
                    this.StateProvince = addressData.GetString("Region");
                    this.CountryCode = addressData.GetString("CountryISO");
                    this.PostalCode = addressData.GetString("Postl_Cod1");

                    customerDetail2.SetValue("CustomerNo", this.CustomerNo);
                    customerDetail2.Invoke(destination);
                    IRfcStructure generalDetail = customerDetail2.GetStructure("CustomerGeneralDetail");

                    this.Region = generalDetail.GetString("Reg_Market");
                    this.Industry = generalDetail.GetString("Industry");


                    customerDetail1.Invoke(destination);
                    IRfcStructure detail1 = customerDetail1.GetStructure("PE_CompanyData");

                    this.District = detail1.GetString("District");


                    customerHierachy.Invoke(destination);
                    customerHierachy.SetValue("CustomerNo", this.CustomerNo);
                    customerHierachy.Invoke(destination);

                    IRfcTable otherDetail = customerHierachy.GetTable("SalesAreas");

                    if (otherDetail.RowCount > 0)
                    {
                        this.SalesOrg = otherDetail.GetString("SalesOrg");
                        this.DistributionChannel = otherDetail.GetString("DistrChn");
                        this.Division = otherDetail.GetString("Division");
                    }

                    customerHierachy = null;
                    customerDetail1 = null;
                    customerDetail2 = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }


            }
            catch (RfcCommunicationException e)
            {

            }
            catch (RfcLogonException e)
            {
                // user could not logon...
            }
            catch (RfcAbapRuntimeException e)
            {
                // serious problem on ABAP system side...
            }
            catch (RfcAbapBaseException e)
            {
                // The function module returned an ABAP exception, an ABAP message
                // or an ABAP class-based exception...
            }

        }
    }
}
