namespace iTEC_Hackathon.DTOs.EndpointHistory
{
    public class EndpointHistoryGetByHoursDTO
    {
        //public int IdEndpoint { get; set; }
        public int IdUser { get; set; }
        public DateTime DateCreated { get; set; }
        public string Mentions { get; set; }
        public int Code { get; set; } //
    }
}