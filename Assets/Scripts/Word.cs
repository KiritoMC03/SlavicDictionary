using System;


[Serializable]
public class Word
{
    public int ID { get; set; }
    public string Russian { get; set; }
    public string Belarusian { get; set; }
    public string Ukrainian { get; set; }
    public string OldSlavonic { get; set; }
    public string OldRussian { get; set; }

    public Word() {}

    public Word(string russian = "-", string belarusian = "-", string ukrainian = "-", string oldSlavonic = "-", string oldRussian = "-")
    {
        if (!string.IsNullOrWhiteSpace(russian))
        {
            Russian = russian.ToLower();
        }
        if (!string.IsNullOrWhiteSpace(belarusian))
        {
            Belarusian = belarusian.ToLower();
        }
        if (!string.IsNullOrWhiteSpace(ukrainian))
        {
            Ukrainian = ukrainian.ToLower();
        }
        if (!string.IsNullOrWhiteSpace(oldSlavonic))
        {
            OldSlavonic = oldSlavonic.ToLower();
        }
        if (!string.IsNullOrWhiteSpace(oldRussian))
        {
            OldRussian = oldRussian.ToLower();
        }
    }

    public override string ToString()
    {
        return Russian;
    }
}
