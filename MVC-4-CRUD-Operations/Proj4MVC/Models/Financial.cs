namespace Proj4MVC.Models
{
    public class Financial
    {
        public int Id { get; set; }
        public ApplicationUser? AppUser { get; set; }
        public string? AppUserId { get; set; }
        public int AllowanceId { get; set; }
        public Allowance? Allowance { get; set; }
        public int DeductionId { get; set; }
        public Deduction? Deduction { get; set; }
        public decimal AllowanceAmount { get; set; }
        public decimal DeductionAmount { get; set; }

    }
}
