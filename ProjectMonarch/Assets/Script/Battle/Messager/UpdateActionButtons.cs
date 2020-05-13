using UnityEngine.UI;
using UnityEngine;

public class UpdateActionButtons : MonoBehaviour
{
    public GameObject _action;


    public void SelectAction()
    {
        UpdateSelectedAction();
    }


    private void UpdateSelectedAction()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectActionMessage
        {
            Action = _action
        }, "OnSelectedAction");
    }


}
