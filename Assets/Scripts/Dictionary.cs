using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    private List<Word> words = new List<Word>();
    [SerializeField] private GameObject _wordCard;
    [SerializeField] private Transform _wordCardContainer;
    XmlSerializer serializer = new XmlSerializer(typeof(List<Word>));
    private string _languageStyle = "<#2a2a2a><u><b>";
    private string _wordStyle = "\n</u></b><#4f4f4f>";
    private int _thisWordId = 0;

    void Start()
    {
        var word = new Word("рука", "рука", "рука", "роука", "руце");
        var word2 = new Word("q", "w", "e", "r", "t");
        var word3 = new Word("a", "s", "d", "f", "g");
        var word4 = new Word("z", "x", "c", "v", "b");
        var word5 = new Word("y", "u", "i", "o", "p");
        AddWordToDictionary(word);
        AddWordToDictionary(word2);
        AddWordToDictionary(word3);
        AddWordToDictionary(word4);
        AddWordToDictionary(word5);

        CreateWordCard(_thisWordId);
    }

    public void Save(bool isGeneral)
    {
        using (var file = new StreamWriter("words.xml", true, Encoding.UTF8))
        {
            if (isGeneral)
            {
                PlayerPrefs.SetInt("WordCount", words.Count);
            }
            
            if(PlayerPrefs.GetInt("WordCount") >= words.Count)
            {
                serializer.Serialize(file, words);
            }
            file.Close();
        }
    }

    public void Load()
    {
        using (var file = new StreamReader("words.xml", Encoding.UTF8))
        {
            var newWords = serializer.Deserialize(file) as List<Word>;
            
            if(newWords != null)
            {
                foreach (var word in newWords)
                {
                    Debug.Log(word.ID + ": " + word);
                }
            }

            file.Close();
        }
    }

    public void AddWordToDictionary(Word word)
    {
        word.ID = words.Count;
        words.Add(word);
    }

    private void CreateWordCard(int id)
    {
        if (_wordCardContainer != null)
        {
            for (int i = 0; i < _wordCardContainer.transform.childCount; i++)
            {
                Destroy(_wordCardContainer.GetChild(i).gameObject);
            }

            var newWordCard = Instantiate(_wordCard, _wordCardContainer);
            newWordCard.GetComponent<WordCard>().SetIdAndTranslates(words[id], _languageStyle, _wordStyle);
        }
    }

    public void ShowNextWord()
    {
        if (_thisWordId == words.Count-1)
        {
            _thisWordId = 0;
            CreateWordCard(_thisWordId);
            return;
        }
        CreateWordCard(_thisWordId + 1);
        _thisWordId++;
        return;
    }
    public void ShowPreviousWord()
    {
        if (_thisWordId == 0)
        {
            _thisWordId = words.Count;
            CreateWordCard(_thisWordId);
            return;
        }
        CreateWordCard(_thisWordId - 1);
        _thisWordId--;
        return;
    }
}
