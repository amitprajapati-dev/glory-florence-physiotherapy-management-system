namespace SampleProject.Models;

public class PatientDocument
{
    public long Id { get; set; }

    public long PatientId { get; set; }

    public int? DocumentTypeId { get; set; }

    public string FileName { get; set; }

    public string StorageKey { get; set; }

    public long FileSize { get; set; }

    public string ContentType { get; set; }

    public long UploadedBy { get; set; }

    public DateTime UploadedAt { get; set; }
}