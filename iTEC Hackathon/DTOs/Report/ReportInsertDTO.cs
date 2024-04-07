namespace iTEC_Hackathon.DTOs.Report
{
    public class ReportInsertDTO
    {
        public int IdApplication { get; set; }
        public int IdEndpoint { get; set; }
        public int IdUser { get; set; }
        public string Mentions { get; set; }
    }
}
