using System;
using System.Collections.Generic;
using System.Text;

namespace ChatOnline.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int FriendId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
