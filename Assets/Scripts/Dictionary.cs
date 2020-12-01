using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour
{
    private List<Word> words = new List<Word>();
    [SerializeField] private GameObject _wordCard;
    [SerializeField] private Transform _wordCardContainer;
    [SerializeField] private Transform _findWordsContainer;
    [SerializeField] private Transform _scrollContent;
    [SerializeField] private GameObject _findWord;
    [SerializeField] private Text _input;
    [SerializeField] private GameObject _generalCanvas;
    [SerializeField] private GameObject _scrollCanvas;
    XmlSerializer serializer = new XmlSerializer(typeof(List<Word>));
    internal int _thisWordId = 0;

    void Start()
    {
        /*
        using (StreamReader sr = new StreamReader(@"Assets\WordsCollection\rus1.txt", Encoding.UTF8))
        {
            var i = 0;
            while (!sr.EndOfStream)
            {
                Debug.Log(++i);
                var tempWord = new Word(sr.ReadLine());
                AddWordToDictionary(tempWord);
            }
            Debug.Log(words.Count);
        }
        using (StreamReader sr = new StreamReader(@"Assets\WordsCollection\bel1.txt", Encoding.UTF8))
        {
            for (int i = 0; i < words.Count; i++)
            {
                var tempWord = new Word(belarusian: sr.ReadLine());
                words[i].Belarusian = tempWord.Belarusian;
            }
        }
        using (StreamReader sr = new StreamReader(@"Assets\WordsCollection\ukr1.txt", Encoding.UTF8))
        {
            for (int i = 0; i < words.Count; i++)
            {
                var tempWord = new Word(ukrainian: sr.ReadLine());
                words[i].Ukrainian = tempWord.Ukrainian;
            }
        }
        using (StreamReader sr = new StreamReader(@"Assets\WordsCollection\oldSlav1.txt", Encoding.UTF8))
        {
            for (int i = 0; i < words.Count; i++)
            {
                var tempWord = new Word(oldSlavonic: sr.ReadLine());
                words[i].OldSlavonic = tempWord.OldSlavonic;
            }
        }
        Save(true);
        */

        EnableGeneralCanvas(true);

        Load();
        Debug.Log(words.Count);
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
            
            if(newWords != null && words != null)
            {
                words = newWords;
            }

            file.Close();
        }
    }

    public void AddWordToDictionary(Word word)
    {
        word.ID = words.Count;
        words.Add(word);
    }

    internal void CreateWordCard(int id)
    {
        if (_wordCardContainer != null)
        {
            ClearContainer(_wordCardContainer);

            var newWordCard = Instantiate(_wordCard, _wordCardContainer);
            newWordCard.GetComponent<WordCard>().SetIdAndTranslates(words[id]);
            _thisWordId = id;
        }
    }

    private void ClearContainer(Transform container)
    {
        if (container != null)
        {
            for (int i = 0; i < container.childCount; i++)
            {
                Destroy(container.GetChild(i).gameObject);
                Debug.Log("CLEAR!");
            }
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

    public void FindInputWord()
    {
        EnableScrollCanvas(true);

        string subString = _input.text;

        foreach (var word in words)
        {
            var subStringPosition = word.Rusian.IndexOf(subString);
            if(subStringPosition != -1)
            {
                var _newFindWord = Instantiate(_findWord, _scrollContent);
                _newFindWord.GetComponent<FindWord>().ConstructFindText(word);
                continue;
            }
        }
    }

    internal void EnableGeneralCanvas(bool value, bool service = true)
    {
        _generalCanvas.SetActive(value);

        if (service)
        {
            ClearContainer(_findWordsContainer);
            EnableScrollCanvas(!value, false);
        }
    }
    internal void EnableScrollCanvas(bool value, bool service = true)
    {
        _scrollCanvas.SetActive(value);

        if (service)
        {
            ClearContainer(_wordCardContainer);
            EnableGeneralCanvas(!value, false);
        }
    }
}
