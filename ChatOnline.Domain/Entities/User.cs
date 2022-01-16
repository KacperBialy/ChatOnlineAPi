using ChatOnline.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatOnline.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
