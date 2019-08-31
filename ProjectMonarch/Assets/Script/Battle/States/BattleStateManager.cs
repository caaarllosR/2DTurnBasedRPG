using System;
using System.Linq;
using UnityEngine;


public class BattleState
{
    private static BattleState _instance;
    public enum BattleStates : short {startTurn, selectChar, selectAction, selectTarget, battlePhase, endTurn}
    private BattleStates States {get; set;}

    public static BattleState Instance
    {
        get { return _instance ?? (_instance = new BattleState()); }
    }

    private BattleState()
    {
        States = BattleStates.startTurn;
    }


    public BattleStates NextState()
    {
        States++;
        if (States > Enum.GetValues(typeof(BattleStates)).Cast<BattleStates>().Last())
        {
            States = Enum.GetValues(typeof(BattleStates)).Cast<BattleStates>().First();
        }
        return States;
    }

    public BattleStates BackState()
    {
        States--;
        if (States < Enum.GetValues(typeof(BattleStates)).Cast<BattleStates>().First())
        {
            States = Enum.GetValues(typeof(BattleStates)).Cast<BattleStates>().Last();
        }
        return States;
    }

    public BattleStates GetState()
    { 
        return States;
    }
}
