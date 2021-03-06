using House_API.Models;

namespace House_API.ViewModels
{
    public class PostHouseViewModel
    {
        public HousingType HousingType { get; set; }

        public FormAssignment FormAssignment { get; set; }

        public string? Address { get; set; }

        public string? ZipCode { get; set; }

        public string? City { get; set; }

        public int Price { get; set; }

        public int LivingArea { get; set; }

        public int? YardArea { get; set; }

        public int? GrossArea { get; set; }
        public string? Description { get; set; }

        public float RoomAmount { get; set; }

        public int ConstructionYear { get; set; }

        public DateTime VisitingDate { get; set; }

        public float? MonthlyFee { get; set; }
    }
}