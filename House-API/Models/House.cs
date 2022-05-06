using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace House_API.Models
{
    public class House
    {
        public int HouseId { get; set; }
        public IdentityUser? User { get; set; }

        public string? UserId { get; set; }

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