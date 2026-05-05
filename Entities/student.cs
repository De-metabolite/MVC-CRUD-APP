using System.ComponentModel.DataAnnotations;

namespace CRUD_APP_MVC.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(255)]
        public string? Email {get; set;}
        [StringLength(25)]
        public string? Phone {  get; set; }
        [StringLength(255)]
        public string? Address {  get; set; }




    }
}
