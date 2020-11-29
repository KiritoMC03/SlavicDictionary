using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ID;
    [SerializeField] private TextMeshProUGUI Translates;

    public void SetIdAndTranslates(Word word, string languageStyle, string wordStyle)
    {
        ID.text = "№ " + word.ID;

        if (Translates != null)
        {
            Translates.text = languageStyle + "Русский язык:" + wordStyle + word.Russian +
                languageStyle + "\nБеларуская мова:" + wordStyle + word.Belarusian +
                languageStyle + "\nУкраїньска мова:" + wordStyle + word.Ukrainian +
                languageStyle + "\nСловѣньскыи ѩӡык:" + wordStyle + word.OldSlavonic +
                languageStyle + "\nРоускъ ѩӡыкъ:" + wordStyle + word.OldRussian;
        }
    }
}
