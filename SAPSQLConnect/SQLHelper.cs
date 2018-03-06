using SAPErpConnect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPSQLConnect
{
    public class SQLHelper
    {
    
        public static void deleteTables()
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                SqlCommand delete1 = new SqlCommand("delete from Dim_ControllingArea", connection); 
                SqlCommand delete2 = new SqlCommand("delete from Dim_ActivityType", connection);
                SqlCommand delete3 = new SqlCommand("delete from Dim_CostCenter", connection);
                SqlCommand delete4 = new SqlCommand("delete from Fact_Activity", connection);

                delete4.ExecuteNonQuery();
                delete2.ExecuteNonQuery();
                delete3.ExecuteNonQuery();
                delete1.ExecuteNonQuery();
            }
        }

        public static void saveControllingAreas(List<ControllingArea> areasToSave)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                foreach (ControllingArea area in areasToSave)
                {
                    string insert = string.Format("insert into Dim_ControllingArea values ('{0}','{1}')", area.ControllingAreaCode, area.ControllingAreaName);
                    SqlCommand insertSQL = new SqlCommand(insert, connection);
                    insertSQL.ExecuteNonQuery();
                }
            }
        }

        public static void saveCostCenrters(List<CostCenter> costCentersToSave)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                foreach (CostCenter cs in costCentersToSave)
                {
                    cs.CostCenterAddressCity = cs.CostCenterAddressCity.Replace('\'',' ');
                    cs.CostCenterAddressDistrict = cs.CostCenterAddressDistrict.Replace('\'', ' ');
                    cs.CostCenterAddressPOBOX = cs.CostCenterAddressPOBOX.Replace('\'', ' ');
                    cs.CostCenterAddressStreet = cs.CostCenterAddressStreet.Replace('\'', ' ');
                    cs.CostCenterCode = cs.CostCenterCode.Replace('\'', ' ');
                    cs.CostCenterName = cs.CostCenterName.Replace('\'', ' ');
                    cs.PersonInCharge = cs.PersonInCharge.Replace('\'', ' ');
                    string insert = string.Format("insert into Dim_CostCenter values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", Guid.NewGuid().ToString(), cs.CostCenterCode, cs.CostCenterName, cs.CostCenterAddressStreet, cs.CostCenterAddressCity, cs.CostCenterAddressDistrict, cs.CostCenterAddressPOBOX, cs.PersonInCharge, cs.ControllingArea.ControllingAreaCode);

                    try
                    {
                        SqlCommand insertSQL = new SqlCommand(insert, connection);
                        insertSQL.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public static void saveActivityTypes(List<ActivityType> activityTypeToSave)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                foreach (ActivityType at in activityTypeToSave)
                {
                    at.ActivityDescription = at.ActivityDescription.Replace('\'', ' ');
                    at.ActivityTypeCode = at.ActivityTypeCode.Replace('\'', ' ');
                    at.ActivityTypeName = at.ActivityTypeName.Replace('\'', ' ');

                    string insert = string.Format("insert into Dim_ActivityType values ('{0}','{1}','{2}','{3}','{4}')", Guid.NewGuid().ToString(), at.ActivityTypeCode, at.ActivityTypeName, at.ActivityDescription, at.ControllingArea.ControllingAreaCode);

                    try
                    {
                        SqlCommand insertSQL = new SqlCommand(insert, connection);
                        insertSQL.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }


        public static void saveActivies(List<Activity> activiesToSave)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                foreach (Activity at in activiesToSave)
                {
                    at.ActivityCurrency = at.ActivityCurrency.Replace('\'', ' ');
                    at.ActivityTypeCode = at.ActivityTypeCode.Replace('\'', ' ');
                    at.CostCenterCode = at.CostCenterCode.Replace('\'', ' ');

                    string insert = string.Format(@"
                           insert into Fact_Activity 
                                select 
                                Fact_Activity_ID = newid(),
                                Fact_Date_ID = (select top(1) Dim_Date_ID from Dim_Date where Dim_Date_FiscalYear = {0} and Dim_Date_Month = {1}),
                                Fact_CostCenter_ID = (select top(1) Dim_CostCenter_ID from Dim_CostCenter where Dim_CostCenterCode like ('{2}') and Dim_ControllingAreaCode like ('{3}')),
                                Fact_ActivityType_ID = (select top(1) Dim_ActivityType_ID from Dim_ActivityType where Dim_ActivityTypeCode like ('{4}') and Dim_ControllingAreaCode like ('{3}')),
                                Fact_CostCenterCode = '{2}',
                                Fact_ActivityTypeCode = '{4}',
                                Fact_ActivityCurrency = '{5}',
                                Fact_ActivityFixPrice = {6},
                                Fact_ActivityVariablePrice = {7}", at.ActivityFiscalYear, at.ActivityMonth, at.CostCenterCode, at.controllingArea.ControllingAreaCode,at.ActivityTypeCode, at.ActivityCurrency, at.ActivityFixPrice, at.ActivityVariablePrice);

                    try
                    {
                        SqlCommand insertSQL = new SqlCommand(insert, connection);
                        insertSQL.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        int i = 0;
                        i++;
                        //throw ex;
                    }
                }
            }
        }

    }
}
