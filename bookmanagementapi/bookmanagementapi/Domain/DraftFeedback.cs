namespace BookManagement.Domain;

public class DraftFeedback
{
    public long Id { get; set; }
    public string Issuer { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    
    public virtual Book Book { get; set; } = default!;
}
