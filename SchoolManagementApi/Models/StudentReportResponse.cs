namespace managment_api.Models;

public class StudentReportResponse
{
    public List<ClassReport> Classes { get; set; } = new();
    public decimal? OverallAverageMark { get; set; }
}

public class ClassReport
{
    public int ClassId { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public decimal? ExamMark { get; set; }
    public decimal? AssignmentMark { get; set; }
    public decimal? TotalMark { get; set; }
}