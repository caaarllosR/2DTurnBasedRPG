using UnityEngine.UI;
using UnityEngine;

public class UpdateCharButtons : MonoBehaviour
{
    public GameObject _char;
    public GameObject _charButton;
    public GameObject _actionButtons;

    public void SelectChar()
    {
        UpdateSelectedChar();
        UpdateActionButtons();
    }

    public void SelectAction()
    {
        UpdateDisaleActionButtons();
    }
    private void UpdateSelectedChar()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectCharMessage
        {
            Char = _char,
            CharButton = _charButton
        }, "OnSelectedChar");
    }

    private void UpdateDisaleActionButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectActionMessage
        {
            Action = _actionButtons
        }, "OnDisableActionButtons");
    }

    private void UpdateActionButtons()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectActionMessage
        {
            Action = _actionButtons
        }, "OnEnableActionButtons");
    }
}
