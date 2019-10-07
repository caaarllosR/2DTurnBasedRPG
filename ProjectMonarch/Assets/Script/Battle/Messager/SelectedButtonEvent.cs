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
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectTargetMessage>(OnSelectedTarget);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent>(OnDisableCharButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectCharButtonMessage>(OnEnableCharButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectTargetButtonMessage>(OnEnableTargetButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectTargetButtonMessage>(OnDisableTargetButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectActionMessage>(OnEnableActionButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectActionMessage>(OnDisableActionButtons);
    }

    private void OnDestroy()
    {
    }

    private void OnSelectedChar(SelectCharMessage _selectChar)
    {
        GameObject _char = _selectChar.Char;
        ActionSortManager.Instance.SelectedActors.Push(_char.name);
        MainBattleButtonsManager.Instance.SetIsSelected(_selectChar.CharButton, true);
    }

    private void OnSelectedTarget(SelectTargetMessage _selectTarget)
    {
        GameObject _target = _selectTarget.Target;
        ActionSortManager.Instance.SelectedTarget = _target.name;
        ActionSortManager.Instance.Add();
    }

    private void OnDisableTargetButtons(SelectTargetButtonMessage _selectTChar)
    {
        foreach (GameObject tCharButton in _selectTChar.TargetButtons)
        {
            tCharButton.SetActive(false);
        }
    }

    private void OnEnableTargetButtons(SelectTargetButtonMessage _selectTarget)
    {
        GameObject[] selectChar = _selectTarget.TargetButtons;
        BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectTarget);
        foreach (GameObject tCharButton in selectChar)
        {
            tCharButton.SetActive(true);
        }
    }

    private void OnEnableActionButtons(SelectActionMessage _selectAction)
    {
        BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectAction);
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
        BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectChar);
        MainBattleButtonsManager.Instance.ActiveAllNotSelect();
    }

    private void OnDisableCharButtons()
    {
        MainBattleButtonsManager.Instance.DeactiveAll();
    }
}
