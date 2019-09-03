using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class UpdateMainButtons : MonoBehaviour
{
    public GameObject _charY;
    public GameObject _charX;
    public GameObject _charA;
    public GameObject _charB;

    public GameObject _enemY;
    public GameObject _enemX;
    public GameObject _enemA;
    public GameObject _enemB;

    public GameObject[] _enemyButtons;

    private void Awake()
    {
        CharButtonStateManager.Instance.AddCharButton(_charY, false);
        CharButtonStateManager.Instance.AddCharButton(_charX, false);
        CharButtonStateManager.Instance.AddCharButton(_charA, false);
        CharButtonStateManager.Instance.AddCharButton(_charB, false);

        _enemyButtons = new GameObject[] { _enemY, _enemX, _enemA, _enemB };
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

    private void UpdateDisableEnemyButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectEnemyButtonMessage
        {
           EnemyButtons = _enemyButtons
        }, "OnDisableEnemyButtons");
    }

    private void UpdateEnableEnemyButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectEnemyButtonMessage
        {
           EnemyButtons = _enemyButtons
        }, "OnEnableEnemyButtons");
    }

    private void UpdateDisabledCharButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectCharButtonMessage
        {
        }, "OnDisableCharButtons");
    }

    private void UpdateEnabledCharButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectCharButtonMessage
        {
        }, "OnEnableCharButtons");
    }

}
