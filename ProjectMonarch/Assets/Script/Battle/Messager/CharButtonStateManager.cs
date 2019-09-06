using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


public class CharButtonStateManager
{
    private class CharButtonState
    {
        private GameObject charButton;
        private bool isSelectedButton;

        public GameObject CharButton { get => charButton; set => charButton = value; }
        public bool IsSelectedButton { get => isSelectedButton; set => isSelectedButton = value; }
    }

    private static CharButtonStateManager _instance;
    private Dictionary<string, CharButtonState> _dictionary;

    public static CharButtonStateManager Instance
    {
        get { return _instance ?? (_instance = new CharButtonStateManager()); }
    }

    private CharButtonStateManager()
    {
        _dictionary = new Dictionary<string, CharButtonState>();
    }

    public void Add(GameObject charButton, bool isSelectedButton)
    {
        CharButtonState _charButtonState = new CharButtonState();
        _charButtonState.CharButton = charButton;
        _charButtonState.IsSelectedButton = isSelectedButton;
        _dictionary.Add(charButton.ToString(), _charButtonState);
    }

    public void SetIsSelected(GameObject charButton, bool isSelectedButton)
    {
        CharButtonState _charButtonState = null;
        string key = charButton.ToString();
        if (_dictionary.TryGetValue(key, out _charButtonState))
        {
            _charButtonState.IsSelectedButton = isSelectedButton;
        }
    }

    public void ActiveAllNotSelect()
    {
        foreach (KeyValuePair<string, CharButtonState> entry in _dictionary)
        {
            if (!entry.Value.IsSelectedButton)
            {
                entry.Value.CharButton.SetActive(true);
            }
        }
    }

    public void DeactiveAll()
    {
        foreach (KeyValuePair<string, CharButtonState> entry in _dictionary)
        {
            entry.Value.CharButton.SetActive(false);
        }
    }

    public void ActiveAll()
    {
        foreach (KeyValuePair<string, CharButtonState> entry in _dictionary)
        {
            entry.Value.IsSelectedButton = false;
            entry.Value.CharButton.SetActive(true);
        }
    }

    public void DeselectAll()
    {
        foreach (KeyValuePair<string, CharButtonState> entry in _dictionary)
        {
            entry.Value.IsSelectedButton = false;
        }
    }

    public bool IsDeselectAll()
    {
        bool allSelected = true;
        foreach (KeyValuePair<string, CharButtonState> entry in _dictionary)
        {
            if(!entry.Value.IsSelectedButton)
            {
                allSelected = false;
            }
        }
        return allSelected;
    }
}

