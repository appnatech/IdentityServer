using System;

namespace Global.Mongo.Models
{
    public class UserDocument
    {
        public string SubjectId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
