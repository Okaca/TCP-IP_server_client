namespace WinFormsApp1
{
    internal class Message2
    {
        public int MessageId { get; } = 2; // Read-only with default value
        public int UnitRefNumber { get; set; }
        public byte LocationValidity { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public int Altitude { get; set; }
    }
}
