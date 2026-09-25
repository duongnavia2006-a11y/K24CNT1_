using System.ComponentModel.DataAnnotations;

namespace NtdLesson10EFDbFirst.Models;

public partial class NtdMember
{
    public int NtdMemberId { get; set; }

    [Required]
    public string NtdUserName { get; set; } = null!;

    [Required]
    public string NtdPassword { get; set; } = null!;

    [Required]
    public string NtdFullName { get; set; } = null!;

    [Required, EmailAddress]
    public string NtdEmail { get; set; } = null!;

    public string? NtdPhone { get; set; }

    public bool NtdStatus { get; set; }
}
