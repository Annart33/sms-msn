using System;

namespace API.DTO
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Number { get; set; }
    }
}