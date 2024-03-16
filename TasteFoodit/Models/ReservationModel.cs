namespace TasteFoodit.Models
{
    public class ReservationModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ReservationDate { get; set; }
        public string Time { get; set; }
        public byte GuestCount { get; set; }
        public bool ReservationStatus { get; set; }
    }
}