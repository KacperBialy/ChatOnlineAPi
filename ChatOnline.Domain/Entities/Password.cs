using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatOnline.Domain.Entities
{
    public class Password
    {
        public int Id { get; set; }
        public string HashPassword { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
