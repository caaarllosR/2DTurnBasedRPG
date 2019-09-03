using UnityEngine.UI;
using UnityEngine;

public class UpdateButtons : MonoBehaviour
{
    private void Awake()
    {
    }

    private void Update()
    {
    }

    public void DisableCharButtons()
    {
        UpdateDisabledCharButtons();
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
