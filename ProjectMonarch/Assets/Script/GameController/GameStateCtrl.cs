using System.Collections;
using UnityEngine;

[System.Serializable]
public class GameStateCtrl : MonoBehaviour
{
    private GameObject    gameController;
    private MonoBehaviour gameButtonsCtrl;

    private BattleStateManager.BattleStates _battleState;

    private void backOption(BattleStateManager.BattleStates state)
    {
        Debug.Log(CharButtonStateManager.Instance.CharButton.Count);
        if (state.Equals(BattleStateManager.BattleStates.selectAction))
        {
            CharButtonStateManager.Instance.SetIsSelected(CharButtonStateManager.Instance.CharButton.Peek(), false);
            MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectActionMessage
            {
                Action = CharButtonStateManager.Instance.ActionButton
            }, "OnDisableActionButtons");
            MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectCharButtonMessage
            {
            }, "OnEnableCharButtons");
            CharButtonStateManager.Instance.CharButton.Pop();
            BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectChar);
        }

        if (state.Equals(BattleStateManager.BattleStates.selectTarget))
        {
            MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectTargetButtonMessage
            {
                TargetButtons = CharButtonStateManager.Instance.TargetButtons
            }, "OnDisableTargetButtons");

            MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectActionMessage
            {
                Action = CharButtonStateManager.Instance.ActionButton
            }, "OnEnableActionButtons");
            BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectAction);
        }

        if (state.Equals(BattleStateManager.BattleStates.selectChar))
        {
            if (CharButtonStateManager.Instance.CharButton.Count > 0)
            {
                MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectCharButtonMessage
                {
                }, "OnDisableCharButtons");
                MessageManager<BattleMessageEvent>.Instance.DynamicInvoke<BattleMessageEvent>(new SelectTargetButtonMessage
                {
                    TargetButtons = CharButtonStateManager.Instance.TargetButtons
                }, "OnEnableTargetButtons");

                BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectTarget);
            }
            else
            {
                BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.startTurn);
            }
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

        if (Input.GetKeyDown("q"))
        {
            //When a key is pressed down it see if it was the escape key if it was it will execute the code
            Application.Quit(); // Quits the game
        }

        if (_battleState == BattleStateManager.BattleStates.startTurn)
        {
            CharButtonStateManager.Instance.CharButton.Clear();
            BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.selectChar);
        }

        if (_battleState == BattleStateManager.BattleStates.selectTarget)
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

        if (_battleState == BattleStateManager.BattleStates.battlePhase)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                CharButtonStateManager.Instance.ActiveAll();
                BattleStateManager.Instance.SetState(BattleStateManager.BattleStates.startTurn);
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            backOption(_battleState);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(_battleState);
            if (_battleState == BattleStateManager.BattleStates.battlePhase)
            {
                ActionSortManager.Instance.Get();
            }
        }
    }
}