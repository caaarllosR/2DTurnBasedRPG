using UnityEngine.UI;
using UnityEngine;

public class UpdateActorsButtons : MonoBehaviour
{
    public GameObject _actor;
    public GameObject _target;


    public void SelectActor()
    {
        UpdateSelectedActor();
    }

    public void SelectTarget()
    {
        UpdateSelectedTarget();
    }

    private void UpdateSelectedActor()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectActorMessage
        {
            Actor = _actor
        }, "OnSelectedActor");
    }


    private void UpdateSelectedTarget()
    {
        MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectTargetMessage
        {
            Target = _target
        }, "OnSelectedTarget");
    }



}
