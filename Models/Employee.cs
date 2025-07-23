using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Employee 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
      
        public string Name { get; private set; }
        
        public double Salary {  get; private set; }
        public DateTime HiringDate {  get; private set; }

        public string? CreatedBy {  get; private set; }
        public DateTime? CreatedOn { get; private set; }

        public bool? IsDeleted { get; private set; }




    }
}
