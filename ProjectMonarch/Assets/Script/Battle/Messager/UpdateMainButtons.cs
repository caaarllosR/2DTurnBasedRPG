using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class UpdateMainButtons : MonoBehaviour
{
    public GameObject _charY;
    public GameObject _charX;
    public GameObject _charA;
    public GameObject _charB;


    private void Awake()
    {
        CharButtonStateManager.Instance.AddCharButton(_charY, false);
        CharButtonStateManager.Instance.AddCharButton(_charX, false);
        CharButtonStateManager.Instance.AddCharButton(_charA, false);
        CharButtonStateManager.Instance.AddCharButton(_charB, false);
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

    public void UpdateDisabledCharButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectButtonMessage
        {
        }, "OnDisableButtons");
    }

    public void UpdateEnabledCharButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectButtonMessage
        {

        }, "OnEnableButtons");
    }

}
