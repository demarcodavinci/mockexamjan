namespace mockexam.Models
{
    public class Rooms
    {
        public int RoomsId { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public double HourlyRate { get; set; }
        public string City { get; set; }
        public bool isAvailable { get; set; }
        public ICollection<Bookings>? Bookings { get; set; }
    }
}
