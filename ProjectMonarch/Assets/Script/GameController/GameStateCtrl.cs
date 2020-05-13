using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class GameStateCtrl : MonoBehaviour
{
    public enum BattleStates : short { StartBattle, StartTurn, SelectActor, SelectAction, SelectTarget, BattlePhase, EndTurn }

    private BattleStates _battleStates;

    public GameObject _objButtonCharY;
    public GameObject _objButtonCharX;
    public GameObject _objButtonCharA;
    public GameObject _objButtonCharB;

    private Button _buttonCharY;
    private Button _buttonCharX;
    private Button _buttonCharA;
    private Button _buttonCharB;


    public GameObject _objActionCharBtY;
    public GameObject _objActionCharBtX;
    public GameObject _objActionCharBtA;
    public GameObject _objActionCharBtB;

    private GameObject _objActionBt11;
    private GameObject _objActionBt12;
    private GameObject _objActionBt13;
    private GameObject _objActionBt14;

    private Button _buttonAction11;
    private Button _buttonAction12;
    private Button _buttonAction13;
    private Button _buttonAction14;

    private GameObject _objActionBt21;
    private GameObject _objActionBt22;
    private GameObject _objActionBt23;
    private GameObject _objActionBt24;

    private Button _buttonAction21;
    private Button _buttonAction22;
    private Button _buttonAction23;
    private Button _buttonAction24;

    private GameObject _objActionBt31;
    private GameObject _objActionBt32;
    private GameObject _objActionBt33;
    private GameObject _objActionBt34;

    private Button _buttonAction31;
    private Button _buttonAction32;
    private Button _buttonAction33;
    private Button _buttonAction34;

    private GameObject _objActionBt41;
    private GameObject _objActionBt42;
    private GameObject _objActionBt43;
    private GameObject _objActionBt44;

    private Button _buttonAction41;
    private Button _buttonAction42;
    private Button _buttonAction43;
    private Button _buttonAction44;


    public GameObject _objBtTargetEnemY;
    public GameObject _objBtTargetEnemX;
    public GameObject _objBtTargetEnemA;
    public GameObject _objBtTargetEnemB;

    private Button _btTargetEnemY;
    private Button _btTargetEnemX;
    private Button _btTargetEnemA;
    private Button _btTargetEnemB;


    public GameObject _objBtTargetCharY;
    public GameObject _objBtTargetCharX;
    public GameObject _objBtTargetCharA;
    public GameObject _objBtTargetCharB;

    private Button _btTargetCharY;
    private Button _btTargetCharX;
    private Button _btTargetCharA;
    private Button _btTargetCharB;


    //private Dictionary<string, Dictionary<Button, GameObject>> _objButtons;
    private Dictionary<GameObject, bool> _isSelectedCharBtns;
    private Dictionary<GameObject, GameObject> _objCharActionBts;

    private bool _isActiveObjButton;
    private GameObject _clickedCharButton;
    private GameObject _clickedActionButton;
    //private Button _pressedButton;


    private GameObject[] _objCharBts;
    private GameObject[] _objAcionBts;
    private GameObject[] _objTargetCharBts;
    private GameObject[] _objTargetEnemBts;


    private void Awake()
    {
        _isActiveObjButton = false;
        _battleStates = GameStateCtrl.BattleStates.StartTurn;
        //_objPhaseButtons = new Dictionary<Button, GameObject>();

        _buttonCharY = _objButtonCharY.GetComponent<Button>();
        _buttonCharX = _objButtonCharX.GetComponent<Button>();
        _buttonCharA = _objButtonCharA.GetComponent<Button>();
        _buttonCharB = _objButtonCharB.GetComponent<Button>();

        _btTargetEnemY = _objBtTargetEnemY.GetComponent<Button>();
        _btTargetEnemX = _objBtTargetEnemX.GetComponent<Button>();
        _btTargetEnemA = _objBtTargetEnemA.GetComponent<Button>();
        _btTargetEnemB = _objBtTargetEnemB.GetComponent<Button>();

        _btTargetCharY = _objBtTargetCharY.GetComponent<Button>();
        _btTargetCharX = _objBtTargetCharX.GetComponent<Button>();
        _btTargetCharA = _objBtTargetCharA.GetComponent<Button>();
        _btTargetCharB = _objBtTargetCharB.GetComponent<Button>();


        _isSelectedCharBtns = new Dictionary<GameObject, bool>
        {
            {_objButtonCharY, false},
            {_objButtonCharX, false},
            {_objButtonCharA, false},
            {_objButtonCharB, false},

        };


    _objCharBts       = new GameObject[] {_objButtonCharY, _objButtonCharX, _objButtonCharA, _objButtonCharB};
    _objAcionBts      = new GameObject[4];
    _objTargetCharBts = new GameObject[] {_objBtTargetCharY, _objBtTargetCharX , _objBtTargetCharA , _objBtTargetCharB};
    _objTargetEnemBts = new GameObject[] {_objBtTargetEnemY, _objBtTargetEnemX, _objBtTargetEnemA, _objBtTargetEnemB}; ;





    _objCharActionBts = new Dictionary<GameObject, GameObject> {{_objButtonCharY, _objActionCharBtY}
                                                              , {_objButtonCharX, _objActionCharBtX}
                                                              , {_objButtonCharA, _objActionCharBtA}
                                                              , {_objButtonCharB, _objActionCharBtB}};



        for (var i = 0; i < _objActionCharBtY.transform.childCount; i++)
        {
            _objAcionBts[i] = _objActionCharBtY.transform.GetChild(i).gameObject;
        }
            _objActionBt11 = _objAcionBts[0];
            _objActionBt12 = _objAcionBts[1];
            _objActionBt13 = _objAcionBts[2];
            _objActionBt14 = _objAcionBts[3];

            _buttonAction11 = _objActionBt11.GetComponent<Button>();
            _buttonAction12 = _objActionBt12.GetComponent<Button>();
            _buttonAction13 = _objActionBt13.GetComponent<Button>();
            _buttonAction14 = _objActionBt14.GetComponent<Button>();



            for (var i = 0; i < _objActionCharBtX.transform.childCount; i++)
            {
                _objAcionBts[i] = _objActionCharBtX.transform.GetChild(i).gameObject;
            }
            _objActionBt21 = _objAcionBts[0];
            _objActionBt22 = _objAcionBts[1];
            _objActionBt23 = _objAcionBts[2];
            _objActionBt24 = _objAcionBts[3];
        
            _buttonAction21 = _objActionBt21.GetComponent<Button>();
            _buttonAction22 = _objActionBt22.GetComponent<Button>();
            _buttonAction23 = _objActionBt23.GetComponent<Button>();
            _buttonAction24 = _objActionBt24.GetComponent<Button>();


            for (var i = 0; i < _objActionCharBtA.transform.childCount; i++)
            {
                _objAcionBts[i] = _objActionCharBtA.transform.GetChild(i).gameObject;
            }
            _objActionBt31 = _objAcionBts[0];
            _objActionBt32 = _objAcionBts[1];
            _objActionBt33 = _objAcionBts[2];
            _objActionBt34 = _objAcionBts[3];

            _buttonAction31 = _objActionBt31.GetComponent<Button>();
            _buttonAction32 = _objActionBt32.GetComponent<Button>();
            _buttonAction33 = _objActionBt33.GetComponent<Button>();
            _buttonAction34 = _objActionBt34.GetComponent<Button>();



            for (var i = 0; i < _objActionCharBtB.transform.childCount; i++)
            {
                _objAcionBts[i] = _objActionCharBtB.transform.GetChild(i).gameObject;
            }
            _objActionBt41 = _objAcionBts[0];
            _objActionBt42 = _objAcionBts[1];
            _objActionBt43 = _objAcionBts[2];
            _objActionBt44 = _objAcionBts[3];

            _buttonAction41 = _objActionBt41.GetComponent<Button>();
            _buttonAction42 = _objActionBt42.GetComponent<Button>();
            _buttonAction43 = _objActionBt43.GetComponent<Button>();
            _buttonAction44 = _objActionBt44.GetComponent<Button>();


        //_objButtons = new Dictionary<string, Dictionary<Button, GameObject>>
        //{
        //    {"char", new Dictionary<Button, GameObject>(){
        //                 {_buttonCharY, _objButtonCharY},
        //                 {_buttonCharX, _objButtonCharX},
        //                 {_buttonCharA, _objButtonCharA},
        //                 {_buttonCharB, _objButtonCharB}}},

        //    //{"action", new Dictionary<Button, GameObject>(){
        //    //             {_buttonAction1,_objActionBt1},
        //    //             {_buttonAction2,_objActionBt2},
        //    //             {_buttonAction3,_objActionBt3},
        //    //             {_buttonAction4,_objActionBt4}}},

        //    {"tEenem", new Dictionary<Button, GameObject>(){
        //                 {_btTargetEnemY,_objBtTargetEnemY},
        //                 {_btTargetEnemX,_objBtTargetEnemX},
        //                 {_btTargetEnemA,_objBtTargetEnemA},
        //                 {_btTargetEnemB,_objBtTargetEnemB}}},

        //    {"tChar", new Dictionary<Button, GameObject>(){
        //              {_btTargetCharY,_objBtTargetCharY},
        //              {_btTargetCharX,_objBtTargetCharX},
        //              {_btTargetCharA,_objBtTargetCharA},
        //              {_btTargetCharB,_objBtTargetCharB}}}
        //};

    }


    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }


    private void BackOption(GameStateCtrl.BattleStates state)
    {
        if (state.Equals(GameStateCtrl.BattleStates.SelectAction))
        {
            if (ActionSortManager.Instance.SelectedActors.Count > 1)
            {
                ActionSortManager.Instance.SelectedActors.Pop();
            }
        }

        if (state.Equals(GameStateCtrl.BattleStates.SelectTarget))
        {

        }

        if (state.Equals(GameStateCtrl.BattleStates.SelectActor))
        {
            ActionSortManager.Instance.RemoveActor(ActionSortManager.Instance.SelectedActors.Peek());
        }
    }

    private void ActiveObjButtons(GameObject[] objBtns)
    {
        foreach (var objBtn in objBtns)
        {
            objBtn.SetActive(true);
        }
    }


    private void ActiveObjCharButtons(Dictionary<GameObject, bool> isSelectedCharBtns)
    {
        foreach (var charBtn in isSelectedCharBtns)
        {
            if (!charBtn.Value)
            {
                charBtn.Key.SetActive(true);
            }
        }
    }


    private void DeactiveObjButtons(GameObject[] objBtns)
    {
        foreach (var objBtn in objBtns)
        {
            objBtn.SetActive(false);
        }
    }


    private bool SelectCharButton(GameObject pressedObjButton)
    {
        if (pressedObjButton != null)
        {
            if (_isSelectedCharBtns.TryGetValue(pressedObjButton, out var isSelectedbutton))
            {
                if (!isSelectedbutton)
                {
                    _isSelectedCharBtns[pressedObjButton] = true;
                }
            }
            return true;
        }
        return false;
    }



    //private Dictionary<Button, GameObject> GetPhaseObjBtns(string codTypeBtn)
    //{
    //    if (_objButtons.TryGetValue(codTypeBtn, out var objPhaseButtons))
    //    {
    //        return objPhaseButtons;
    //    }
    //    return null;
    //}


    //private void GetPressCharButtonTeste(Dictionary<Button, GameObject> objButtons, Button buttonPressed)
    //{
    //    if (buttonPressed != null)
    //    {
    //        if (objButtons.TryGetValue(buttonPressed, out var objButton))
    //        {
    //            buttonPressed.onClick.AddListener(() => _clickedCharButton = objButton);
    //        }
    //    }
    //}



    private void SetActionCharBt(GameObject charBtn)
    {
        if (_objCharActionBts.TryGetValue(charBtn, out var objCharActionBt))
        {
            for (var i = 0; i < objCharActionBt.transform.childCount; i++)
            {
                _objAcionBts[i] = objCharActionBt.transform.GetChild(i).gameObject;
            }
            //_objActionBt1 = _objAcionBts[0];
            //_objActionBt2 = _objAcionBts[1];
            //_objActionBt3 = _objAcionBts[2];
            //_objActionBt4 = _objAcionBts[3];

            //_buttonAction1 = _objActionBt1.GetComponent<Button>();
            //_buttonAction2 = _objActionBt2.GetComponent<Button>();
            //_buttonAction3 = _objActionBt3.GetComponent<Button>();
            //_buttonAction4 = _objActionBt4.GetComponent<Button>();
        }
    }

    void OnEnable()
    {
        _buttonCharY?.onClick.AddListener(() => _clickedCharButton = _objButtonCharY);
        _buttonCharX?.onClick.AddListener(() => _clickedCharButton = _objButtonCharX);
        _buttonCharA?.onClick.AddListener(() => _clickedCharButton = _objButtonCharA);
        _buttonCharB?.onClick.AddListener(() => _clickedCharButton = _objButtonCharB);


        _buttonAction11?.onClick.AddListener(() => _clickedActionButton = _objActionBt11);
        _buttonAction12?.onClick.AddListener(() => _clickedActionButton = _objActionBt12);
        _buttonAction13?.onClick.AddListener(() => _clickedActionButton = _objActionBt13);
        _buttonAction14?.onClick.AddListener(() => _clickedActionButton = _objActionBt14);

        _buttonAction21?.onClick.AddListener(() => _clickedActionButton = _objActionBt21);
        _buttonAction22?.onClick.AddListener(() => _clickedActionButton = _objActionBt22);
        _buttonAction23?.onClick.AddListener(() => _clickedActionButton = _objActionBt23);
        _buttonAction24?.onClick.AddListener(() => _clickedActionButton = _objActionBt24);

        _buttonAction31?.onClick.AddListener(() => _clickedActionButton = _objActionBt31);
        _buttonAction32?.onClick.AddListener(() => _clickedActionButton = _objActionBt32);
        _buttonAction33?.onClick.AddListener(() => _clickedActionButton = _objActionBt33);
        _buttonAction34?.onClick.AddListener(() => _clickedActionButton = _objActionBt34);

        _buttonAction41?.onClick.AddListener(() => _clickedActionButton = _objActionBt41);
        _buttonAction42?.onClick.AddListener(() => _clickedActionButton = _objActionBt42);
        _buttonAction43?.onClick.AddListener(() => _clickedActionButton = _objActionBt43);
        _buttonAction44?.onClick.AddListener(() => _clickedActionButton = _objActionBt44);
    }


    void OnDisable()
    {
        _buttonCharY.onClick.RemoveAllListeners();
        _buttonCharX.onClick.RemoveAllListeners();
        _buttonCharA.onClick.RemoveAllListeners();
        _buttonCharB.onClick.RemoveAllListeners();


        _buttonAction11?.onClick.RemoveAllListeners();
        _buttonAction12?.onClick.RemoveAllListeners();
        _buttonAction13?.onClick.RemoveAllListeners();
        _buttonAction14?.onClick.RemoveAllListeners();

        _buttonAction21?.onClick.RemoveAllListeners();
        _buttonAction22?.onClick.RemoveAllListeners();
        _buttonAction23?.onClick.RemoveAllListeners();
        _buttonAction24?.onClick.RemoveAllListeners();

        _buttonAction31?.onClick.RemoveAllListeners();
        _buttonAction32?.onClick.RemoveAllListeners();
        _buttonAction33?.onClick.RemoveAllListeners();
        _buttonAction34?.onClick.RemoveAllListeners();

        _buttonAction41?.onClick.RemoveAllListeners();
        _buttonAction42?.onClick.RemoveAllListeners();
        _buttonAction43?.onClick.RemoveAllListeners();
        _buttonAction44?.onClick.RemoveAllListeners();
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (EventSystem.current.currentSelectedGameObject != null && !teste)
        //{
        //    _pressedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        //    Debug.Log("entrei up: " + _pressedButton?.GetType().Name);
        //    teste = true;
        //}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //When a key is pressed down it see if it was the escape key if it was it will execute the code
            Application.Quit(); // Quits the game
        }

        if (_battleStates.Equals(GameStateCtrl.BattleStates.StartTurn))
        {
            _battleStates = GameStateCtrl.BattleStates.SelectActor;
        }

        if (_battleStates.Equals(GameStateCtrl.BattleStates.SelectActor))
        {
            if (!_isActiveObjButton)
            {
                ActiveObjCharButtons(_isSelectedCharBtns);
                _isActiveObjButton = true;
            }

            if (SelectCharButton(_clickedCharButton) && _isActiveObjButton)
            {
                DeactiveObjButtons(_objCharBts);
                _isActiveObjButton = false;
                _battleStates = GameStateCtrl.BattleStates.SelectAction;
            }
        }

        if (_battleStates.Equals(GameStateCtrl.BattleStates.SelectAction))
        {
            if (!_isActiveObjButton)
            {
                SetActionCharBt(_clickedCharButton);
                ActiveObjButtons(_objAcionBts);
                _clickedCharButton = null;
                _isActiveObjButton = true;
                Debug.Log(_clickedActionButton?.name);
            }

            if (_clickedActionButton != null && _isActiveObjButton)
            {
                DeactiveObjButtons(_objAcionBts);
                _isActiveObjButton = false;
                _battleStates = GameStateCtrl.BattleStates.SelectTarget;
            }
        }

        if (_battleStates.Equals(GameStateCtrl.BattleStates.SelectTarget))
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

            }

            //_battleStates = GameStateCtrl.BattleStates.SelectActor;
        }

        if (_battleStates.Equals(GameStateCtrl.BattleStates.BattlePhase))
        {
            ClearLog();
            ActionSortManager.Instance.Get();
            ActionSortManager.Instance.ClearAll();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log(_battleStates);
                BackOption(_battleStates);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            ClearLog();
            ActionSortManager.Instance.Get();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(_battleStates);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {

        }
    }
}