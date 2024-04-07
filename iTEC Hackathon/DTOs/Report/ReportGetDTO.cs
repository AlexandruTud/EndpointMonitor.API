namespace iTEC_Hackathon.DTOs.Report
{
    public class ReportGetDTO
    {

        public int IdApplicationReport { get; set; }
        public int IdEndpoint { get; set; }
        public int IdUser { get; set; }
        public int MarkedAsSolved { get; set; }
        public DateTime DateCreated { get; set; }
        public string Mentions { get; set; }
        //de la app
        public int IdUserAuthor { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime ApplicationDateCreated { get; set; }
        public string State { get; set; }
        // de la endpoint
        public string URL { get; set; }
        public string Type { get; set; }
        public DateTime EndpointDateCreated { get; set; }
    }
}
