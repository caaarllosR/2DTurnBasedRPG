using UnityEngine;

public class SelectCharEvent : MonoBehaviour
{
    private void Awake()
    {
    }

    private void Start()
    {
        MessageManager<ButtonCharMessageEvent>.Instance.AddListener<ButtonCharMessageEvent, SelectCharMessage>(OnSelectedChar);
        MessageManager<ButtonCharMessageEvent>.Instance.AddListener<ButtonCharMessageEvent, SelectButtonMessage>(OnDisableCharButtons);
        MessageManager<ButtonCharMessageEvent>.Instance.AddListener<ButtonCharMessageEvent, SelectButtonMessage>(OnEnableCharButtons);
        MessageManager<ButtonCharMessageEvent>.Instance.AddListener<ButtonCharMessageEvent, SelectActionMessage>(OnEnableActionButtons);
    }

    private void OnDestroy()
    {
    }

    private void OnSelectedChar(SelectCharMessage _selectChar)
    {
        GameObject _char = _selectChar.Char;
        Debug.Log(_char.name);
    }

    private void OnEnableCharButtons(SelectButtonMessage _selectButton)
    {
        GameObject[] _button = _selectButton.Button;

        foreach (GameObject obj in _button)
        {
            obj.SetActive(true);
        }
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

    private void OnDisableCharButtons(SelectButtonMessage _selectButton)
    {
        GameObject[] _button = _selectButton.Button;

        foreach (GameObject obj in _button)
        {
            obj.SetActive(false);
        }
    }
}
