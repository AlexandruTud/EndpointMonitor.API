namespace iTEC_Hackathon.DTOs.Statistics
{
    public class GetTotalNumberOfEndpointsByStateDTO
    {
        public int TotalStableEndpoints { get; set; }
        public int TotalUnstableEndpoints { get; set; }
        public int TotalDownEndpoints { get; set; }
    }
}
