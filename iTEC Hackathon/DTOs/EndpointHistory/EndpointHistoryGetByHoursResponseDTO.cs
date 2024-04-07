namespace iTEC_Hackathon.DTOs.EndpointHistory
{
    public class EndpointHistoryGetByHoursResponseDTO
    {
        public string State { get; set; }
        public List<EndpointHistoryGetByHoursDTO> Data { get; set; }
    }
}
