using System;
using System.Linq;
using UnityEngine;


public class BattleStateManager
{
    private static BattleStateManager _instance;
    public enum BattleStates : short { startBattle, startTurn, selectChar, selectAction, selectTarget, battlePhase, endTurn}
    private BattleStates States {get; set;}

    public static BattleStateManager Instance
    {
        get { return _instance ?? (_instance = new BattleStateManager()); }
    }

    private BattleStateManager()
    {
        States = BattleStates.startBattle;
    }

    public void SetState(BattleStates battleState)
    {
        States = battleState;
    }

    public BattleStates GetState()
    { 
        return States;
    }
}
