using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Employee
    {
        public Employee()
        {

        }
        public Employee(string name, int age, double salary, string? createdBy)
        {

            Name = name;
            Age = age;
            Salary = salary;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
        public double Salary { get; private set; }


        public string? CreatedBy { get; private set; }
        public DateTime? CreatedOn { get; private set; }

        public bool? IsDeleted { get; private set; }

        public void Edit(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }


        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
