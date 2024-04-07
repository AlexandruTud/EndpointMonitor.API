namespace iTEC_Hackathon.DTOs.EndpointHistory
{
    public class EndpointHistoryInsertDTO
    {
        public int IdEndpoint { get; set; }
        public int IdUser { get; set; }
        public int Code { get; set;}
        public string Mentions { get; set; }
    }
}
