using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;
using Sound.Api.Models;

namespace Sound.Api.Services
{
    public class TokenService
    {

        public async Task<(DateTimeOffset Timestamp, string UserId, string Purpose, string SecurityStamp)> DecodeAsync(string token, IDataProtector protector, UserManager<User> manager)
        {
            // Convert the base64 string back to byte array
            var protectedBytes = Convert.FromBase64String(token);

            // Unprotect the bytes
            var unprotectedBytes = protector.Unprotect(protectedBytes);

            using (var ms = new MemoryStream(unprotectedBytes))
            using (var reader = ms.CreateReader())
            {
                // Read the original components
                var timestamp = reader.ReadDateTimeOffset();
                var userId = reader.ReadString();
                var purpose = reader.ReadString();
                var securityStamp = reader.ReadString();

                return (timestamp, userId, purpose, securityStamp);
            }
        }       

    }
}
