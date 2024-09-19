using Microsoft.AspNetCore.Mvc;

namespace Proj6EcommMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        [Remote(action:"CheckExisitingEmailId",controller:"Auth")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }

    }
}
