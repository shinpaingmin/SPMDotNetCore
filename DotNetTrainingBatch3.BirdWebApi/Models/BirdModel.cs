namespace DotNetTrainingBatch3.BirdWebApi.Models
{
    // DataModel for receiving from api
    public class BirdDataModel
    {
        public int Id { get; set; }
        public string BirdMyanmarName { get; set; }
        public string BirdEnglishName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }

    // ViewModel for client
    public class BirdViewModel
    {
        public int BirdId { get; set; }

        public string BirdName { get; set; }

        public string Desp { get; set; }

        public string PhotoUrl { get; set; }
    }
}
