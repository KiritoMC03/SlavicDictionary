using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindWord : MonoBehaviour
{
    [SerializeField] private Text _text;
    private Word _word;
    private GameObject _dictionaryHandler;

    private void Start()
    {
        _dictionaryHandler = GameObject.FindGameObjectWithTag("DictionaryHandler");
    }

    public void ConstructFindText(Word word)
    {
        if(word != null)
        {
            _word = word;
            _text.text = _word.Rusian;
        }
    }

    public void ShowThisWordCard()
    {
        _dictionaryHandler = GameObject.FindGameObjectWithTag("DictionaryHandler");

        if (_dictionaryHandler != null && _word != null)
        {
            _dictionaryHandler.GetComponent<Dictionary>().CreateWordCard(_word.ID);
            _dictionaryHandler.GetComponent<Dictionary>().EnableGeneralCanvas(true);
        }
    }
}
