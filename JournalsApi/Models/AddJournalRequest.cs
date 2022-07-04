namespace JournalsApi.Models
{
    public class AddJournalRequest
    {
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public bool Attendance { get; set; }
    }
}
