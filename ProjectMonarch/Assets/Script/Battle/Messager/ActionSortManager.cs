using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionSortManager
{
    private string actor;  //nome ou id do ator
    private string target; //nome ou id do alvo

    public string Actor { get => actor; set => actor = value; }
    public string Target { get => target; set => target = value; }

    private class ActorAction
    {
        private string actor;  //nome ou id do ator
        // tipo da ação (magia, ação fisica e etc)
        // a ação em si (bola de fogo)
        private string target; //nome ou id dos alvos

        public string Actor { get => actor; set => actor = value; }
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
    }

    public void Add()
    {
        ActorAction _actorAction = new ActorAction(target, actor);
        List<ActorAction> actors = null;

        if (actions.TryGetValue(target, out actors))
        {
            actors.Add(_actorAction);
        }
        else
        {
            actors = new List<ActorAction> { _actorAction };
            actions.Add(target, actors);
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
