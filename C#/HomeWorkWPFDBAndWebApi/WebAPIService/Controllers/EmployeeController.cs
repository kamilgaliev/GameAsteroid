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
    public class EmployeeController : ApiController
    {
        public static DB db = new DB();
        List<Employee> empl = new List<Employee>();
        public IEnumerable<Employee> GetAllEmpl()
        {
            var allempl = db.EmplList();
            empl = (from DataRow dr in allempl.Rows
                    select new Employee()
                    {
                        Id=Convert.ToInt32(dr["ID"]),
                        Name = dr["NAME"].ToString(),
                        Age = Convert.ToInt32(dr["AGE"]),
                        IdDep = Convert.ToInt32(dr["IDDEP"]),
                        Dep = dr["DEP"].ToString()
                    }).ToList();
            return empl;
        }

    }
}
