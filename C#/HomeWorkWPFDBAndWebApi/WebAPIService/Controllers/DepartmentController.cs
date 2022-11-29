using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIService.Models;

namespace WebAPIService.Controllers
{
    public class DepartmentController : ApiController
    {
        public static DB db = new DB();
        List<Department> dep = new List<Department>();

        public IEnumerable<Department> GetAllDep()
        {
            var alldep = db.DepList();
           dep = (from DataRow dr in alldep.Rows
                    select new Department()
                    {
                        Id = Convert.ToInt32(dr["ID"]),
                        Name = dr["NAME"].ToString()
                        
                    }).ToList();
            return dep;
        }
    }
}
