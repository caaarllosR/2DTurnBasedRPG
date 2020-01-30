using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class GameStateCtrl : MonoBehaviour
{
    private GameObject    gameController;
    private MonoBehaviour gameButtonsCtrl;

    private BattleStateManager.BattleStates _battleState;

    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }


    private void backOption(BattleStateManager.BattleStates state)
    {
        if (state.Equals(BattleStateManager.BattleStates.selectAction))
        {
            MainBattleButtonsManager.Instance.SetIsSelected(MainBattleButtonsManager.Instance.CharButtons.Peek(), false);
            MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectActionMessage
            {
                Action = MainBattleButtonsManager.Instance.ActionButton
            }, "OnDisableActionButtons");
            MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectCharButtonMessage
            {
            }, "OnEnableCharButtons");
            
            if(MainBattleButtonsManager.Instance.CharButtons.Count > 0)
            {
                MainBattleButtonsManager.Instance.CharButtons.Pop();
            }
            if (ActionSortManager.Instance.SelectedActors.Count > 1)
            {
                ActionSortManager.Instance.SelectedActors.Pop();
            }
            if (MainBattleButtonsManager.Instance.TargetButtons.Count > 1)
            {
                MainBattleButtonsManager.Instance.TargetButtons.Pop();
            }
        }

        if (state.Equals(BattleStateManager.BattleStates.selectTarget))
        {
            MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectTargetButtonMessage
            {
                TargetButtons = MainBattleButtonsManager.Instance.TargetButtons.Peek()
            }, "OnDisableTargetButtons");
            MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectActionMessage
            {
                Action = MainBattleButtonsManager.Instance.ActionButton
            }, "OnEnableActionButtons");
        }

        if (state.Equals(BattleStateManager.BattleStates.selectChar))
        {
            if (MainBattleButtonsManager.Instance.CharButtons.Count > 0)
            {
                MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>("OnDisableCharButtons");
                MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectTargetButtonMessage
                {
                    TargetButtons = MainBattleButtonsManager.Instance.TargetButtons.Peek()
                }, "OnEnableTargetButtons");
            }
            ActionSortManager.Instance.RemoveActor(ActionSortManager.Instance.SelectedActors.Peek());
        }
    }

    void Start()
    {
        gameController  = GameObject.Find("GameController");
        gameButtonsCtrl = gameController.GetComponent<UpdateMainButtons>();
    }

    // Update is called once per frame
    void Update()
    {
        _battleState = BattleStateManager.Instance.GetState();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //When a key is pressed down it see if it was the escape key if it was it will execute the code
            Application.Quit(); // Quits the game
        }

        if (_battleState == BattleStateManager.BattleStates.startTurn)
        {
            MainBattleButtonsManager.Instance.CharButtons.Clear();
            BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectChar);
        }

        if (_battleState == BattleStateManager.BattleStates.selectTarget)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                gameButtonsCtrl.Invoke("DisableTargetButtons", 0);
                if(MainBattleButtonsManager.Instance.TargetButtons.Count > 0)
                {
                    MainBattleButtonsManager.Instance.TargetButtons.Pop();
                }
                gameButtonsCtrl.Invoke("EnableTcharButtons", 0);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                gameButtonsCtrl.Invoke("DisableTargetButtons", 0);
                if (MainBattleButtonsManager.Instance.TargetButtons.Count > 0)
                {
                    MainBattleButtonsManager.Instance.TargetButtons.Pop();
                }
                gameButtonsCtrl.Invoke("EnableEnemyButtons", 0);
            }
        }

        if (_battleState == BattleStateManager.BattleStates.battlePhase)
        {
            ClearLog();
            ActionSortManager.Instance.Get();
            ActionSortManager.Instance.ClearAll();
            MainBattleButtonsManager.Instance.ActiveAll();
            BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.startTurn);

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log(MainBattleButtonsManager.Instance.CharButtons.Count);
                Debug.Log(BattleStateManager.Instance.GetState());
                backOption(_battleState);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ClearLog();
            ActionSortManager.Instance.Get();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(_battleState);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(MainBattleButtonsManager.Instance.TargetButtons.Count);
        }
    }
}