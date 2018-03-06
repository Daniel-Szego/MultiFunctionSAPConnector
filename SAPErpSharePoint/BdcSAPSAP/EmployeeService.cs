using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpSharePoint.BdcSAPSAP
{
    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for Entity1.
    /// </summary>
    public class EmployeeService
    {
        /// <summary>
        /// This is a sample specific finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <param name="PersonalNr"></param>
        /// <returns>Entity1</returns>
        public static Employee ReadItem(string PersonalNr)
        {
            //TODO: This is just a sample. Replace this simple sample with valid code.
            Employee entity1 = new Employee();
            entity1.PeronalNr = PersonalNr;
            entity1.Name = "Hello World";
            return entity1;
        }
        /// <summary>
        /// This is a sample finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <returns>IEnumerable of Entities</returns>
        public static IEnumerable<Employee> ReadList()
        {
            //TODO: This is just a sample. Replace this simple sample with valid code.
            Employee[] entityList = new Employee[1];
            Employee entity1 = new Employee();
            entity1.PeronalNr = "0";
            entity1.Name = "Hello World";
            entityList[0] = entity1;
            return entityList;
        }
    }
}
