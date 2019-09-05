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
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectCharButtonMessage>(OnDisableCharButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectCharButtonMessage>(OnEnableCharButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectTargetButtonMessage>(OnEnableEnemyButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectTargetButtonMessage>(OnDisableEnemyButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectTargetButtonMessage>(OnEnableTCharButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectTargetButtonMessage>(OnDisableTCharButtons);
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

    private void OnSelectedEnemy(SelectEnemyMessage _selectEnemy)
    {
        GameObject _enem = _selectEnemy.Enemy;
    }


    private void OnDisableEnemyButtons(SelectTargetButtonMessage _selectEnemy)
    {
        foreach (GameObject enemyButton in _selectEnemy.TargetButtons)
        {
            enemyButton.SetActive(false);
        }
    }

    private void OnEnableEnemyButtons(SelectTargetButtonMessage _selectEnemy)
    {
        foreach (GameObject enemyButton in _selectEnemy.TargetButtons)
        {
            enemyButton.SetActive(true);
        }
    }

    private void OnDisableTCharButtons(SelectTargetButtonMessage _selectTChar)
    {
        foreach (GameObject tCharButton in _selectTChar.TargetButtons)
        {
            tCharButton.SetActive(false);
        }
    }

    private void OnEnableTCharButtons(SelectTargetButtonMessage _selectTChar)
    {
        foreach (GameObject tCharButton in _selectTChar.TargetButtons)
        {
            tCharButton.SetActive(true);
        }
    }

    private void OnEnableActionButtons(SelectActionMessage _selectAction)
    {
        GameObject _action = _selectAction.Action;
        _action.SetActive(true);
    }

    private void OnDisableActionButtons(SelectActionMessage _selectAction)
    {
        GameObject _action = _selectAction.Action;
        _action.SetActive(false);
    }

    private void OnEnableCharButtons(SelectCharButtonMessage _selectButton)
    {
        CharButtonStateManager.Instance.ActiveDeselectedCharButtons();
    }

    private void OnDisableCharButtons(SelectCharButtonMessage _selectButton)
    {
        CharButtonStateManager.Instance.DeactiveCharButtons();
    }
}
