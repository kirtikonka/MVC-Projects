namespace Proj4MVC.Models
{
    public class BankDetails
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? IFSCNumber { get; set; }
        public string? Branch { get; set; }
    }
}
