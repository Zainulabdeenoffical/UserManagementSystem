using System.ComponentModel.DataAnnotations;

namespace UserManagementSystem.Models
{
    public class Adduserviewmodel
    {
        public Guid ID { get; set; }
        [Required]
        public String First_name { get; set; }
        public string Last_name { get; set; }
        public String Email { get; set; }

    }
}
