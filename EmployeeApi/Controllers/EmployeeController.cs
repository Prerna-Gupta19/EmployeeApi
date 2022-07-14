using EmployeeApi.Models;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("myCors")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private IRepo<int, Employee> _repo;
        public EmployeeController(IRepo<int, Employee> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Employee>>> Get()
        {
            var employees = await _repo.GetAll();
            if (employees == null)
                return NotFound();
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            //var employee = employees.FirstOrDefault(e => e.Id == id);
            //return employee;
            var employee = await _repo.Get(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee emp)
        {
            //employees.Add(emp);
            //return emp;
            var employee = await _repo.Add(emp);
            if (employee == null)
                return BadRequest();
            return Ok(employee);
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> Put(int id, Employee emp)
        {
            var employee = await _repo.Update(emp);
            if (employee == null)
                return BadRequest();
            return Ok(employee);
        }

        [HttpDelete]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = await _repo.Delete(id);
            if (employee == null)
                return BadRequest();
            return Ok(employee);
        }
    }
}
