using UnityEngine;

public class SelectCharEvent : MonoBehaviour
{
    private void Awake()
    {
    }

    private void Start()
    {
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectCharMessage>(OnSelectedChar);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectCharButtonMessage>(OnDisableCharButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectCharButtonMessage>(OnEnableCharButtons);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectActionMessage>(OnEnableActionButtons);
    }

    private void OnDestroy()
    {

    }

    private void OnSelectedChar(SelectCharMessage _selectChar)
    {
        GameObject _char = _selectChar.Char;
        Debug.Log(_char.name);
    }

    private void OnDisableCharButtons(SelectCharButtonMessage _selectButton)
    {

    }

    private void OnEnableCharButtons(SelectCharButtonMessage _selectButton)
    {

    }

    private void OnEnableActionButtons(SelectActionMessage _selectAction)
    {
        GameObject _action = _selectAction.Action;
        _action.SetActive(true);
        Debug.Log(_action.name);
    }

    private void OnDisableActionButtons(SelectActionMessage _selectAction)
    {
        GameObject _action = _selectAction.Action;
        _action.SetActive(false);
        Debug.Log(_action.name);
    }
}
