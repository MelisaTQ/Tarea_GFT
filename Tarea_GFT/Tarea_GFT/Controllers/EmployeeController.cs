using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tarea_GFT.Data;
using Tarea_GFT.Models;

namespace Tarea_GFT.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/<controller>
        public List<Employee> Get()
        {
            return EmployeeData.Listar();
        }

        // GET api/<controller>/5
        public Employee Get(int id)
        {
            return EmployeeData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Employee oEmpleado)
        {
            return EmployeeData.Registrar(oEmpleado);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Employee oEmpleado)
        {
            return EmployeeData.Modificar(oEmpleado);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return EmployeeData.Eliminar(id);
        }
    }
}