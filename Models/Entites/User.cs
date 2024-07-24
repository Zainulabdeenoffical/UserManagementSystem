using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace UserManagementSystem.Models.Entites
{
    public class User
    {
        public Guid Id { get; set; }
        public string Frist_name { get; set; }
        public string last_name { get; set; }
        public string Email { get; set; }
    }
}
   