using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionSortManager
{
    private Stack<string> selectedActors;        // nome ou id do ator
    private string selectedTarget;       // nome ou id do alvo
    private string selectedTypeAction;  // nome ou id do alvo
    private string selectedAction;     // nome ou id do alvo

    public Stack<string> SelectedActors { get => selectedActors; set => selectedActors = value; }
    public string SelectedTarget { get => selectedTarget; set => selectedTarget = value; }
    public string SelectedTypeAction { get => selectedTypeAction; set => selectedTypeAction = value; }
    public string SelectedAction { get => selectedAction; set => selectedAction = value; }

    private class ActorAction
    {
        private string actor;         // nome ou id do ator
        private string typeAction;   // tipo da ação (magia, ação fisica e etc)
        private string action;      // a ação em si (bola de fogo)
        private string target;     // nome ou id dos alvos

        public string Actor { get => actor; set => actor = value; }
        public string Target { get => target; set => target = value; }
        public string Action { get => action; set => action = value; }
        public string TypeAction { get => typeAction; set => typeAction = value; }

        public ActorAction(string target, string actor, string typeAction, string action)
        {
            this.target = target;
            this.actor = actor;
            this.typeAction = typeAction;
            this.action = action;
        }
        private ActorAction() { }
    }

    private static Dictionary<string, List<ActorAction>> _actions;
    private static ActionSortManager _instance;

    public static ActionSortManager Instance
    {
        get { return _instance ?? (_instance = new ActionSortManager()); }
    }

    private ActionSortManager()
    {
        _actions = new Dictionary<string, List<ActorAction>>();
        selectedActors  = new Stack<string>();
    }

    public void Add()
    {
        string _selectedActor  = SelectedActors.Peek();
        ActorAction _actorAction = new ActorAction(SelectedTarget, _selectedActor, SelectedTypeAction, SelectedAction);
        List<ActorAction> actions = null;

        if (_actions.TryGetValue(SelectedTarget, out actions))
        {
            actions.Add(_actorAction);
        }
        else
        {
            actions = new List<ActorAction> { _actorAction };
            _actions.Add(SelectedTarget, actions);
        }
    }

    public void RemoveActor(string actor)
    {
        List<ActorAction> actions = null;
        string key;
        foreach(KeyValuePair<string, List<ActorAction>> actorAction in _actions)
        {
            actions = actorAction.Value;
            key    = actorAction.Key;
            foreach (ActorAction _actor in actions)
            {
                if(_actor.Actor.Equals(actor))
                {
                    if(actions.Count > 1)
                    {
                        if (_actions.TryGetValue(key, out actions))
                        {
                            actions.Remove(_actor);
                        }
                    }
                    else
                    {
                        _actions.Remove(key);
                    }
                    return;
                }
            }
        }
    }

    public void Get()
    {
        foreach (List<ActorAction> actions in _actions.Values)
        {
            foreach (ActorAction action in actions)
            {
                Debug.Log(action.Actor+" atacou: "+ action.Target+"!");
            }
        }
    }
}
