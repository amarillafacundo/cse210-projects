public class Reference
{
    private string book;
    private int chapter;
    private int verseStart;
    private int? verseEnd; // Nullable for single verse

    public Reference(string book, int chapter, int verseStart, int? verseEnd = null)
    {
        this.book = book;
        this.chapter = chapter;
        this.verseStart = verseStart;
        this.verseEnd = verseEnd;
    }

    public string GetDisplayText()
    {
        return verseEnd == null ? $"{book} {chapter}:{verseStart}"
                                : $"{book} {chapter}:{verseStart}-{verseEnd}";
    }
}
