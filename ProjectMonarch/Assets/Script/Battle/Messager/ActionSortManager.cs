using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionSortManager
{
    private Stack<string> selectedActors;  //nome ou id do ator
    private string        selectedTarget; //nome ou id do alvo

    public Stack<string> SelectedActors  { get => selectedActors;  set => selectedActors  = value; }
    public string        SelectedTarget  { get => selectedTarget;  set => selectedTarget  = value; }

    private class ActorAction
    {
        private string actor;  //nome ou id do ator
        // tipo da ação (magia, ação fisica e etc)
        // a ação em si (bola de fogo)
        private string target; //nome ou id dos alvos

        public string Actor  { get => actor;  set => actor  = value; }
        public string Target { get => target; set => target = value; }
        private ActorAction() { }

        public ActorAction(string target, string actor)
        {
            this.target = target;
            this.actor  = actor;
        }
    }

    private static Dictionary<string, List<ActorAction>> actions;
    private static ActionSortManager _instance;

    public static ActionSortManager Instance
    {
        get { return _instance ?? (_instance = new ActionSortManager()); }
    }

    private ActionSortManager()
    {
        actions = new Dictionary<string, List<ActorAction>>();
        selectedActors  = new Stack<string>();
    }

    public void Add()
    {
        string _selectedActor  = SelectedActors.Peek();
        ActorAction _actorAction = new ActorAction(SelectedTarget, _selectedActor);
        List<ActorAction> actors = null;

        if (actions.TryGetValue(SelectedTarget, out actors))
        {
            actors.Add(_actorAction);
        }
        else
        {
            actors = new List<ActorAction> { _actorAction };
            actions.Add(SelectedTarget, actors);
        }
    }

    public void RemoveActor(string actor)
    {
        List<ActorAction> actors = null;
        string key;
        foreach(KeyValuePair<string, List<ActorAction>> _actions in actions)
        {
            actors = _actions.Value;
            key    = _actions.Key;
            foreach (ActorAction _actor in actors)
            {
                if(_actor.Actor.Equals(actor))
                {
                    if(actors.Count > 1)
                    {
                        if (actions.TryGetValue(key, out actors))
                        {
                            actors.Remove(_actor);
                        }
                    }
                    else
                    {
                        actions.Remove(key);
                    }
                    return;
                }
            }
        }
    }

    public void Get()
    {
        foreach (List<ActorAction> actors in actions.Values)
        {
            foreach (ActorAction actor in actors)
            {
                Debug.Log(actor.Actor+" atacou: "+actor.Target+"!");
            }
        }
    }
}
