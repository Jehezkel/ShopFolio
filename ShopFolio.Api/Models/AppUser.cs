using Microsoft.AspNetCore.Identity;

namespace ShopFolio.Api.Models
{
    public class AppUser : IdentityUser
    {
        public int ID { get; set; }
    }
}