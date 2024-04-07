namespace iTEC_Hackathon.DTOs.Report
{
    public class ReportsUnsolvedGetByIdUserDTO
    {
        public int IdApplicationReport { get; set; }
        public string URL { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public string Mentions { get; set; }
    }
}
