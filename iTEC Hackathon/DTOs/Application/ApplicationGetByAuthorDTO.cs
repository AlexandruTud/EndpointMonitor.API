namespace iTEC_Hackathon.DTOs.Application
{
    public class ApplicationGetByAuthorDTO
    {
        public int IdApplication { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserEmail { get; set; }
        public string ApplicationState { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
