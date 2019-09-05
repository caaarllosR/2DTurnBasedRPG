using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class UpdateMainButtons : MonoBehaviour
{
    public GameObject _buttonCharY;
    public GameObject _buttonCharX;
    public GameObject _buttonCharB;
    public GameObject _buttonCharA;

    public GameObject _targetEnemY;
    public GameObject _targetEnemX;
    public GameObject _targetEnemB;
    public GameObject _targetEnemA;

    public GameObject _targetCharY;
    public GameObject _targetCharX;
    public GameObject _targetCharB;
    public GameObject _targetCharA;

    public GameObject[] _targetEnemyButtons;
    public GameObject[] _targetCharButtons;

    private void Awake()
    {
        CharButtonStateManager.Instance.AddCharButton(_buttonCharY, false);
        CharButtonStateManager.Instance.AddCharButton(_buttonCharX, false);
        CharButtonStateManager.Instance.AddCharButton(_buttonCharA, false);
        CharButtonStateManager.Instance.AddCharButton(_buttonCharB, false);

        _targetEnemyButtons = new GameObject[] { _targetEnemY, _targetEnemX, _targetEnemA, _targetEnemB };
        _targetCharButtons  = new GameObject[] { _targetCharY, _targetCharX, _targetCharA, _targetCharB };
    }

    private void Update()
    {
    }

    public void DisableCharButtons()
    {
        UpdateDisabledCharButtons();
    }

    public void EnableCharButtons()
    {
        UpdateEnabledCharButtons();
    }

    public void EnableEnemyButtons()
    {
        UpdateEnableEnemyButtons();
    }

    public void DisableEnemyButtons()
    {
        UpdateDisableEnemyButtons();
    }

    public void EnableTcharButtons()
    {
        UpdateEnableTCharButtons();
    }

    public void DisableTcharButtons()
    {
        UpdateDisableTCharButtons();
    }

    private void UpdateEnableEnemyButtons()
    {
        BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectTarget);
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectTargetButtonMessage
        {
           TargetButtons = _targetEnemyButtons
        }, "OnEnableEnemyButtons");
    }

    private void UpdateDisableEnemyButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectTargetButtonMessage
        {
           TargetButtons = _targetEnemyButtons
        }, "OnDisableEnemyButtons");
    }

    private void UpdateEnableTCharButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectTargetButtonMessage
        {
            TargetButtons = _targetCharButtons
        }, "OnEnableTCharButtons");
    }

    private void UpdateDisableTCharButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectTargetButtonMessage
        {
            TargetButtons = _targetCharButtons
        }, "OnDisableTCharButtons");
    }

    private void UpdateEnabledCharButtons()
    {
        BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectChar);
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectCharButtonMessage
        {
        }, "OnEnableCharButtons");
    }

    private void UpdateDisabledCharButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectCharButtonMessage
        {
        }, "OnDisableCharButtons");
    }
}
