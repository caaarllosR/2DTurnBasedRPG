﻿using System.Collections;
using UnityEngine;

[System.Serializable]
public class GameStateCtrl : MonoBehaviour
{
    private GameObject    gameController;
    private MonoBehaviour gameButtonsCtrl;
    void Start()
    {
        gameController  = GameObject.Find("GameController");
        gameButtonsCtrl = gameController.GetComponent<UpdateMainButtons>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //When a key is pressed down it see if it was the escape key if it was it will execute the code
            Application.Quit(); // Quits the game
        }


        if (BattleStateManager.Instance.GetState() == BattleStateManager.BattleStates.selectTarget)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameButtonsCtrl.Invoke("DisableTargetButtons", 0);
                gameButtonsCtrl.Invoke("EnableTcharButtons", 0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameButtonsCtrl.Invoke("DisableTargetButtons", 0);
                gameButtonsCtrl.Invoke("EnableEnemyButtons", 0);
            }
        }

        if (BattleStateManager.Instance.GetState() == BattleStateManager.BattleStates.battlePhase)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                CharButtonStateManager.Instance.ActiveAll();
                BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectChar);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(BattleStateManager.Instance.GetState());
        }
    }
}