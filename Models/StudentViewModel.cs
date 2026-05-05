using System.ComponentModel.DataAnnotations;
    
namespace CRUD_APP_MVC.Models
{
    public class StudentViewModel
    {
        public int Id {get; set;}
        [Required]
        public string? Name {get; set;}
        [EmailAddress]
        public string? Email { get; set;} 
        public string? Phone {get; set; }
        public string? Address { get; set;}

    }
}
