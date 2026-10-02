namespace NtdLesson13.Areas.Admins.Models
{
    public class NtdAdminUser
    {
        public int NtdId { get; set; }
        public string NtdUsername { get; set; } = string.Empty;
        public string NtdFullName { get; set; } = "Nguyễn Tùng Dương";
        public string NtdRole { get; set; } = "Administrator";
    }
}
