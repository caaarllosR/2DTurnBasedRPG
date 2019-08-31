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

    public void UpdateSelectedChar()
    {
        MessageManager<ButtonCharMessageEvent>.Instance.DynamicInvoke<ButtonCharMessageEvent>(new SelectCharMessage
        {
            Char = _char
        }, "OnSelectedChar");
    }

    public void UpdateActionButtons()
    {
        MessageManager<ButtonCharMessageEvent>.Instance.DynamicInvoke<ButtonCharMessageEvent>(new SelectActionMessage
        {
            Action = _actionButtons
        }, "OnEnableActionButtons");
    }
}
