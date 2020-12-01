using System;


[Serializable]
public class Word
{
    public int ID { get; set; }
    public string Rusian { get; set; }
    public string Belarusian { get; set; }
    public string Ukrainian { get; set; }
    public string OldSlavonic { get; set; }
    public string OldRusian { get; set; }

    public Word() {}

    public Word(string rusian = "-", string belarusian = "-", string ukrainian = "-", string oldSlavonic = "-", string oldRusian = "-")
    {
        if (!string.IsNullOrWhiteSpace(rusian))
        {
            Rusian = rusian.ToLower();
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
        if (!string.IsNullOrWhiteSpace(oldRusian))
        {
            OldRusian = oldRusian.ToLower();
        }
    }

    public override string ToString()
    {
        return Rusian;
    }
}
