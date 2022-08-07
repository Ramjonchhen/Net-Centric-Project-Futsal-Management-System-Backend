namespace Net_Centric_Project__Futsal_Management_System__Backend.DTOs
{
    public class AddFutsalDTO
    {
        public string FutsalName { get; set; }
        public string FutsalLocation { get; set; }
        public string FutsalDescription { get; set; }

        public TimeOnly FutsalStartTime { get; set; }

        public TimeOnly FutsalEndTime { get; set; }

        public int BasePrice { get; set; }
        public int AdminId { get; set; }
    }
}
