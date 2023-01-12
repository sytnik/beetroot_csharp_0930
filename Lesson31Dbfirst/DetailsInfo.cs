namespace Lesson31Dbfirst;

public class DetailsInfo
{
    public int InfoId { get; set; }

    public string Data { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}