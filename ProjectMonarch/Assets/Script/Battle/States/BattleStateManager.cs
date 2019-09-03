using System;
using System.Linq;
using UnityEngine;


public class BattleStateManager
{
    private static BattleStateManager _instance;
    public enum BattleStates : short {startTurn, selectChar, selectAction, selectTarget, battlePhase, endTurn}
    private BattleStates States {get; set;}

    public static BattleStateManager Instance
    {
        get { return _instance ?? (_instance = new BattleStateManager()); }
    }

    private BattleStateManager()
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
