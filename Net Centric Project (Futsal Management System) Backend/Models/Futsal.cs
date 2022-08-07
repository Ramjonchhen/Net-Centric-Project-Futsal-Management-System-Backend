using System.ComponentModel.DataAnnotations.Schema;

namespace Net_Centric_Project__Futsal_Management_System__Backend.Models
{
    public class Futsal
    {
        public int FutsalId { get; set; }
        public string FutsalName { get; set; }
        public string FutsalLocation { get; set; }
        public string FutsalDescription { get; set; }
        public TimeOnly FutsalStartTime { get; set; }
        public TimeOnly FutsalEndTime { get; set; }

        public int BasePrice { get; set; }

        public Admin admin;
        public int AdminId { get; set; }


    }
}
