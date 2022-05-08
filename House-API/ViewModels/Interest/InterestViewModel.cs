namespace House_API.ViewModels.Interest
{
    public class InterestViewModel
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? UserId { get; set; }
        public int HouseId { get; set; }
    }
}