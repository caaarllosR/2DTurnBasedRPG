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

    public void SelectTarget()
    {
        UpdateSelectedTarget();
    }

    private void UpdateSelectedTarget()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectTargetMessage
        {
            Target = _char
        }, "OnSelectedTarget");
    }

    private void UpdateSelectedChar()
    {
        CharButtonStateManager.Instance.CharButton.Push(_charButton);
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
        BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectAction);
        CharButtonStateManager.Instance.ActionButton = _actionButtons;
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectActionMessage
        {
            Action = _actionButtons
        }, "OnEnableActionButtons");
    }
}
