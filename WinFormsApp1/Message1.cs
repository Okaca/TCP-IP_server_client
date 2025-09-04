namespace WinFormsApp1
{
    internal class Message1
    {
        public int MessageId { get; } = 1; // Read-only with default value
        public required int UnitRefNumber { get; set; }
        public required string FirstName { get; set; }
        public required uint UnitNo { get; set; }
        public required string LastName { get; set; }
        public required object Rank { get; set; }
    }
}
