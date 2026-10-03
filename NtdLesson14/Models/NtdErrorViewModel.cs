namespace NtdLesson14.Models;

public class NtdErrorViewModel
{
    public string? NtdRequestId { get; set; }
    public bool NtdShowRequestId => !string.IsNullOrEmpty(NtdRequestId);
}
