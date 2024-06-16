using Microsoft.AspNetCore.Identity;
using Sound.Common.Models;

namespace Sound.Api.Models
{
    public class User : IdentityUser
    {
        public DateOnly BirthDate { get; set; }
        public AudioFile[] Favorite { get; set; }
        public AudioCollection[] CustomCollections { get; set; }
    }
}
