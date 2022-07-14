using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public string Username { get; set; }
        [ForeignKey("Username")]
        public User User { get; set; }
        public override bool Equals(object obj)
        {
            var emp = (Employee)obj;
            return this.Id.Equals(emp.Id);
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
