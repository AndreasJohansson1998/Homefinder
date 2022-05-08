using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace House_API.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
        public int HouseId { get; set; }
        [ForeignKey("HouseId")]
        public House? House { get; set; }
    }
}