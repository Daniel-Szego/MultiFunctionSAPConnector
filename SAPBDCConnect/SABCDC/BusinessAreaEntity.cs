using SAPErpConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPBDCConnect.SABCDC
{
    public partial class BusinessAreaEntity
    {

        public BusinessAreaEntity(BusinessArea area)
        {
            this.Code = area.BusinessAreaCode;
            this.Name = area.BusinessAreaName;
        }

        public BusinessAreaEntity()
        {
        }

        // BAPI_EMPLOYEE_GETLIST - BUS_AREA
        public string Code {get; set;}

        // BAPI_EMPLOYEE_GETLIST - BUS_AREA_DES
        public string Name { get; set; }


    }
}
