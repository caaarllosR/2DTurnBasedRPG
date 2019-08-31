using UnityEngine.UI;
using UnityEngine;

public class UpdateButtons : MonoBehaviour
{
    public GameObject _buttonsY;
    public GameObject _buttonsX;
    public GameObject _buttonsA;
    public GameObject _buttonsB;

    private GameObject[] _buttons;

    private void Awake()
    {
        _buttons = new GameObject[] { _buttonsY, _buttonsX, _buttonsA, _buttonsB};
    }

    private void Update()
    {
    }

    public void DisableCharButtons()
    {
        UpdateDisabledCharButtons();
    }


    public void UpdateDisabledCharButtons()
    {    
        MessageManager<ButtonCharMessageEvent>.Instance.DynamicInvoke<ButtonCharMessageEvent>(new SelectButtonMessage
        {
            Button = _buttons
        }, "OnDisableCharButtons");
    }

    public void UpdateEnabledCharButtons()
    {
        MessageManager<ButtonCharMessageEvent>.Instance.DynamicInvoke<ButtonCharMessageEvent>(new SelectButtonMessage
        {
            Button = _buttons
        }, "OnEnableCharButtons");
    }
}
