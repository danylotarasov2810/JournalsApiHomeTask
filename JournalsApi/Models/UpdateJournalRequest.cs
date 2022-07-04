namespace JournalsApi.Models
{
    public class UpdateJournalRequest
    {
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public bool Attendance { get; set; }
    }
}
