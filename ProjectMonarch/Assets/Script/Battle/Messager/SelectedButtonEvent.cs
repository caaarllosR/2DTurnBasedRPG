using System.Collections.Generic;
using UnityEngine;

public class SelectedButtonEvent : MonoBehaviour
{
    private void Awake()
    {
    }

    private void Start()
    {
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectCharMessage>(OnSelectedChar);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectButtonMessage>(OnDisableButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectButtonMessage>(OnEnableButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectActionMessage>(OnEnableActionButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectActionMessage>(OnDisableActionButtons);
    }

    private void OnDestroy()
    {
    }

    private void OnSelectedChar(SelectCharMessage _selectChar)
    {
        GameObject _char = _selectChar.Char;
        CharButtonStateManager.Instance.SetSelectedChar(_selectChar.CharButton, true);
    }

    private void OnEnableButtons(SelectButtonMessage _selectButton)
    {
        CharButtonStateManager.Instance.ActiveDeselectedCharButtons();
    }

    private void OnEnableActionButtons(SelectActionMessage _selectAction)
    {
        GameObject _action = _selectAction.Action;
        _action.SetActive(true);
        Debug.Log(_action.name);
    }

    private void OnDisableActionButtons(SelectActionMessage _selectAction)
    {
        GameObject _action = _selectAction.Action;
        _action.SetActive(false);
    }

    private void OnDisableButtons(SelectButtonMessage _selectButton)
    {
        CharButtonStateManager.Instance.DeactiveCharButtons();
    }
}
