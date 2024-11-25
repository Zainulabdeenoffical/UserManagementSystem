using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace UserManagementSystem.Models.Entites
{
    public class User
    {
        public Guid Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
    }
}
   