using System.ComponentModel.DataAnnotations;

namespace UserManagementSystem.Models
{
    public class Adduserviewmodel
    {
        public Guid ID { get; set; }
        [Required]
        public String Frist_name { get; set; }
        public string last_name { get; set; }
        public String Email { get; set; }

    }
}
