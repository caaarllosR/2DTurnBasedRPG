using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGameState : MonoBehaviour
{
    public void UpdateBattleState()
    {
        BattleState.Instance.BackState();
        Debug.Log(BattleState.Instance.GetState());
    }
}
