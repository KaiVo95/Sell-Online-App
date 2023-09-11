using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiApp.Data.Models
{
    public partial class RefreshToken
    {
        public long RefreshTokenId { get; set; }
        public long UserId { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTimeOffset IssuedAt { get; set; }
        public DateTimeOffset ExpireAt { get; set; }

        public virtual User User { get; set; }
    }
}
