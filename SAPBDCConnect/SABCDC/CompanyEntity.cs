using SAPErpConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPBDCConnect.SABCDC
{
    public partial class CompanyEntity
    {

        public CompanyEntity(Company comp)
        {
            this.Company = comp.ID;
            this.Name = comp.Name;
        }

        public CompanyEntity()
        {
        }

        // BAPI_EMPLOYEE_GETLIST - PERSNR
        public string Company {get; set;}

        // BAPI_EMPLOYEE_GETLIST - PERSNR
        public string Name { get; set; }

    }
}
