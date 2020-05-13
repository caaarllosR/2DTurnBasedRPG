using System.Collections.Generic;
using UnityEngine;

public class SelectedButtonEvent : MonoBehaviour
{
    private void Awake()
    {
    }

    private void Start()
    {
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectActorMessage>(OnSelectedActor);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectActionMessage>(OnSelectedAction);
        MessageManager<BattleMessageEvent>.Instance.AddListener<BattleMessageEvent, SelectTargetMessage>(OnSelectedTarget);
    }

    private void OnDestroy()
    {
    }

    private void OnSelectedActor(SelectActorMessage _selectActor)
    {
        GameObject _actor = _selectActor.Actor;
        ActionSortManager.Instance.SelectedActors.Push(_actor.name);
    }

    private void OnSelectedAction(SelectActionMessage _selectAction)
    {
        GameObject _action = _selectAction.Action;
    }

    private void OnSelectedTarget(SelectTargetMessage _selectTarget)
    {
        GameObject _target = _selectTarget.Target;
        ActionSortManager.Instance.AddTarget(_target.name);
    }


}
