using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Proj4MVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? Nationality { get; set; }
        public MartialStatus MartialStatus { get; set; }
        public string? PictureProfile {  get; set; }
        public string? Designation {  get; set; }
        public DateTime DateOfJoining { get; set; }
        public Status Satus {  get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
namespace Proj4MVC.Models
{
    public enum Gender
    {
        male=0, female=1, others=2
    }
}
namespace Proj4MVC.Models
{
    public enum MartialStatus
    {
        single=0, married=1
    }
}
namespace Proj4MVC.Models
{
    public enum Status
    {
        Active = 0, PartialActive = 1, NotActive=2
    }
}
