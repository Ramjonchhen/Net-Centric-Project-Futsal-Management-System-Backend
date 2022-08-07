

using System.ComponentModel.DataAnnotations;

namespace Net_Centric_Project__Futsal_Management_System__Backend.Models
{
    public class Admin
        {
            public int AdminId { get; set; }
            public string Name { get; set; }
            public string  Email { get; set; }
            public byte[] PasswordSalt { get; set; }

            public byte[] PasswordHash { get; set; }

            public List<Futsal> Futsals { get; set; }
    }
}