using UnityEngine.UI;
using UnityEngine;

public class UpdateCharEvents : MonoBehaviour
{
    public GameObject _char;
    public GameObject _actionButtons;

    public void SelectChar()
    {
        UpdateSelectedChar();
        UpdateActionButtons();
    }

    private void UpdateSelectedChar()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectCharMessage
        {
            Char = _char
        }, "OnSelectedChar");
    }

    private void UpdateActionButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectActionMessage
        {
            Action = _actionButtons
        }, "OnEnableActionButtons");
    }
}
