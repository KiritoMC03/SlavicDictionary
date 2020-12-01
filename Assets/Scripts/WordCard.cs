using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ID;
    [SerializeField] private TextMeshProUGUI Translates;

    private string _languageStyle = "<#2a2a2a><u><b>";
    private string _languageStyleEnd = "</color></u></b>";
    private string _wordStyle = "<#4f4f4f>";
    private string _wordStyleEnd = "</color>";

    public void SetIdAndTranslates(Word word)
    {
        ID.text = "№ " + word.ID;

        if (Translates != null)
        {
            Translates.text = GenerateText(word);
        }
    }

    private string GenerateText(Word word)
    {
        const string _rusianStyle = /*"<font=\"Rusian SDF\">"*/ "<font=\"FlowExt SDF\">";
        const string _belarusianStyle = /*"<font=\"Belarusian SDF\">"*/ "<font=\"FlowExt SDF\">";
        const string _ukrainianStyle = /*"<font=\"Ukrainian SDF\">"*/ "<font=\"FlowExt SDF\">";
        const string _oldSlavonicStyle = "<font=\"OldSlavonic SDF\">";
        const string _oldRusianStyle = "<font=\"OldSlavonic SDF\">";

        string text = _rusianStyle + CreateTitle("Русский язык:") + CreateWord(word.Rusian) +
                _belarusianStyle + CreateTitle("\nБеларуская мова:") + CreateWord(word.Belarusian) +
                _ukrainianStyle + CreateTitle("\nУкраїньска мова:") + CreateWord(word.Ukrainian) + 
                _oldSlavonicStyle + CreateTitle("\nСловѣньскыи ѩӡык:") + CreateWord(word.OldSlavonic)+
                _oldRusianStyle + CreateTitle("\nРоускъ ѩӡыкъ:") + CreateWord(word.OldRusian);

        return text;
    }

    private string CreateTitle(string content)
    {
        return _languageStyle + content + _languageStyleEnd + "\n";
    }
    private string CreateWord(string content)
    {
        return _wordStyle + content + _wordStyleEnd + "\n";
    }
}
