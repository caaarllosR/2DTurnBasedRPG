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
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectEnemyButtonMessage>(OnEnableEnemyButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectEnemyButtonMessage>(OnDisableEnemyButtons);
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

    private void OnDisableEnemyButtons(SelectEnemyButtonMessage _selectEnemy)
    {
        foreach (GameObject enemyButton in _selectEnemy.EnemyButtons)
        {
            enemyButton.SetActive(false);
        }
    }

    private void OnEnableEnemyButtons(SelectEnemyButtonMessage _selectEnemy)
    {
        foreach (GameObject enemyButton in _selectEnemy.EnemyButtons)
        {
            enemyButton.SetActive(true);
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
