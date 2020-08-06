using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class ActionSortManager
{
    private Random gen = new Random(); //#Temporario

    private class ActorAction
    {
        public ActorAction(string target, string actor, string typeAction, string action)
        {
            Target = target;
            Actor = actor;
            TypeAction = typeAction;
            Action = action;
        }
        private ActorAction() { }

        public string Actor       { get; }
        public string Target      { get; }
        public string Action      { get; }
        public string TypeAction  { get; }
        public bool IsCombination { get; set; }

    }

    private readonly Dictionary<string, List<ActorAction>> _actions = new Dictionary<string, List<ActorAction>>();

    //private static Dictionary<string, List<ActorAction>> _actions;
    //private static ActionSortManager _instance;

    //public static ActionSortManager Instance
    //{
    //    get { return _instance ?? (_instance = new ActionSortManager()); }
    //}

    //private ActionSortManager()
    //{
    //    _actions = new Dictionary<string, List<ActorAction>>();
    //}

    public void AddAction(string selectedTarget, string selectedActor, string selectedAction)
    {
        string selectedTypeAction = null;////#Temporario Vai virar parametro depois, eu iria pegar o tipo da ação na própria ação, as não é o ideal, iria acoplar muito, eu não devo saber o tipo da ação aqui nem em GameStateCtrl                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         própria ação
        ActorAction actorAction   = new ActorAction(selectedTarget, selectedActor, selectedTypeAction,selectedAction);
        List<ActorAction> actions  = null;

        actorAction.IsCombination = gen.Next(100) <= 80 ? true : false; //#Temporario

        if (_actions.TryGetValue(selectedTarget, out actions))
        {
            actions.Add(actorAction);
        }
        else
        {
            actions = new List<ActorAction> { actorAction };
            _actions.Add(selectedTarget, actions);
        }
        Debug.Log(actorAction.Actor + " " + actorAction.Action + " " + actorAction.Target + " " + actorAction.IsCombination);
    }

    public void RemoveActor(string actor)
    {
        List<ActorAction> actions = null;
        string key;
        foreach (KeyValuePair<string, List<ActorAction>> actorAction in _actions)
        {
            actions = actorAction.Value;
            key = actorAction.Key;
            foreach (ActorAction _actor in actions)
            {
                if (_actor.Actor.Equals(actor))
                {
                    if (actions.Count > 1)
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


    public void ClearAll()
    {
        _actions.Clear();
    }

    private void RemoveFalseCombination(string selectedTarget) //#Temporario pensando se vai ser realmente temporario, caso não seja verificar possibilidade de refatorar
    {
        int i = 0;

        List<ActorAction> actions = null;
        if (_actions.TryGetValue(selectedTarget, out actions))
        {
            foreach (var action in actions)
            {
                if (action.IsCombination)
                {
                    i++;
                }
            }

            if (i < 2)
            {
                foreach (var action in actions)
                {
                    action.IsCombination = false;
                }
            }
        }
    }


    public void PrintActions(string selectedTarget) //#Alterar vai ser alterado para metodo que busca dados de itens ataques e aplica na ficha em memoria chars e inimigos
    {
        List<ActorAction> actions = null;
        int j = 0;

        RemoveFalseCombination(selectedTarget); //#Temporario pensando, ler no metodo

        if (_actions.TryGetValue(selectedTarget, out actions))
        {
            ActorAction actorAction = actions.Last();
            j = actions.Count;

            if (actorAction.IsCombination)
            {
                for (int i = 0; i < j; i++)
                {
                    actorAction = actions.Last();
                    if (actorAction.IsCombination)
                    {
                        Debug.Log(actorAction.Actor + " deu alvo em : " + actorAction.Target + " com a ação: " + actorAction.Action + ". É uma combinação!");
                        RemoveActor(actorAction.Actor);
                        j--;
                        i--;
                    }
                }
            }
            else
            {
                Debug.Log(actorAction.Actor + " deu alvo em : " + actorAction.Target + " com a ação: " + actorAction.Action +  ". Não é uma combinação!");
                RemoveActor(actorAction.Actor);
            }
        }
    }
}
