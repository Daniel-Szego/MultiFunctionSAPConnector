using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPErpSharePoint.BDCSAP
{
    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for Entity1.
    /// </summary>
    public class Entity1Service
    {
        /// <summary>
        /// This is a sample specific finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity1</returns>
        public static Entity1 ReadItem(string id)
        {
            //TODO: This is just a sample. Replace this simple sample with valid code.
            Entity1 entity1 = new Entity1();
            //entity1.Identifier1 = id;
            //entity1.Message = "Hello World";
            return entity1;
        }
        /// <summary>
        /// This is a sample finder method for Entity1.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <returns>IEnumerable of Entities</returns>
        public static IEnumerable<Entity1> ReadList()
        {
            //TODO: This is just a sample. Replace this simple sample with valid code.
            Entity1[] entityList = new Entity1[1];
            Entity1 entity1 = new Entity1();
            //entity1.Identifier1 = "0";
            //entity1.Message = "Hello World";
            //entityList[0] = entity1;
            return entityList;
        }
    }
}
