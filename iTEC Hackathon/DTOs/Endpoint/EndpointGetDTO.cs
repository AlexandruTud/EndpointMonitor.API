namespace iTEC_Hackathon.DTOs.Endpoint
{
    public class EndpointGetDTO
    {
        public int IdEndpoint { get; set; }
        public string URL { get; set; }
        public string EndpointState { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
