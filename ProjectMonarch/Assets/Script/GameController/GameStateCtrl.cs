using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class GameStateCtrl : MonoBehaviour
{
    private ActionSortManager actionSortManager = new ActionSortManager();
    private enum BattleStates : short { StartBattle, StartTurn, SelectActor, SelectAction, SelectTarget, BattlePhase, EndTurn }
    private BattleStates _battleStates;

    private class CharAction
    {
        public CharAction(GameObject objTarget, GameObject objChar, GameObject objAction)
        {
            ObjTarget     = objTarget;
            ObjChar       = objChar;
            ObjAction     = objAction;
                          
            TargetName    = objTarget.name;
            CharName      = objChar.name;
            ActionName    = objAction.name;
        }

        public string TargetName { get; }
        public string CharName { get; }
        public string ActionName { get; }

        public GameObject ObjTarget { get; }
        public GameObject ObjChar  { get; }
        public GameObject ObjAction { get; }
        private CharAction() { }

    }

    private Stack<CharAction> selectedTargetActions;        // nome ou id do ator
    private List<string>      orderedTargets;        // nome ou id do ator

    private CharAction _charAction;

    public GameObject _objButtonCharY;
    public GameObject _objButtonCharX;
    public GameObject _objButtonCharA;
    public GameObject _objButtonCharB;

    private Button _buttonCharY;
    private Button _buttonCharX;
    private Button _buttonCharA;
    private Button _buttonCharB;


    public GameObject _objActionCharBtsY;
    public GameObject _objActionCharBtsX;
    public GameObject _objActionCharBtsA;
    public GameObject _objActionCharBtsB;

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


    private Dictionary<GameObject, bool> _objCharBtns;
    private Dictionary<GameObject, GameObject> _objCharActionBts;

    private int _countSelectedTgtActs;
    private bool _isActiveObjButton;
    private bool _isBackOption;

    private GameObject _clickedCharButton;
    private GameObject _clickedTargetButton;
    private GameObject _clickedActionButton;


    private GameObject[] _objCharBts;
    private GameObject[] _objActionBts;
    private GameObject[] _objTargetCharBts;
    private GameObject[] _objTargetEnemBts;


    private void Awake()
    {
        selectedTargetActions = new Stack<CharAction>();
        orderedTargets        = new List<string>(4);        // nome ou id do ator

        _isActiveObjButton = false;
        _isBackOption = false;
        _countSelectedTgtActs = 0;

        _battleStates = GameStateCtrl.BattleStates.StartTurn;

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


        _objCharBtns = new Dictionary<GameObject, bool>
        {
            {_objButtonCharY, false},
            {_objButtonCharX, false},
            {_objButtonCharA, false},
            {_objButtonCharB, false},

        };


    _objCharBts       = new GameObject[] {_objButtonCharY, _objButtonCharX, _objButtonCharA, _objButtonCharB};
    _objActionBts     = new GameObject[4];
    _objTargetCharBts = new GameObject[] {_objBtTargetCharY, _objBtTargetCharX , _objBtTargetCharA , _objBtTargetCharB};
    _objTargetEnemBts = new GameObject[] {_objBtTargetEnemY, _objBtTargetEnemX, _objBtTargetEnemA, _objBtTargetEnemB}; ;





    _objCharActionBts = new Dictionary<GameObject, GameObject> {{_objButtonCharY, _objActionCharBtsY}
                                                              , {_objButtonCharX, _objActionCharBtsX}
                                                              , {_objButtonCharA, _objActionCharBtsA}
                                                              , {_objButtonCharB, _objActionCharBtsB}};



    for (var i = 0; i < _objActionCharBtsY.transform.childCount; i++)
    {
        _objActionBts[i] = _objActionCharBtsY.transform.GetChild(i).gameObject;
    }

    _objActionBt11 = _objActionBts[0];
    _objActionBt12 = _objActionBts[1];
    _objActionBt13 = _objActionBts[2];
    _objActionBt14 = _objActionBts[3];

    _buttonAction11 = _objActionBt11.GetComponent<Button>();
    _buttonAction12 = _objActionBt12.GetComponent<Button>();
    _buttonAction13 = _objActionBt13.GetComponent<Button>();
    _buttonAction14 = _objActionBt14.GetComponent<Button>();



    for (var i = 0; i < _objActionCharBtsX.transform.childCount; i++)
    {
        _objActionBts[i] = _objActionCharBtsX.transform.GetChild(i).gameObject;
    }
    _objActionBt21 = _objActionBts[0];
    _objActionBt22 = _objActionBts[1];
    _objActionBt23 = _objActionBts[2];
    _objActionBt24 = _objActionBts[3];
    
    _buttonAction21 = _objActionBt21.GetComponent<Button>();
    _buttonAction22 = _objActionBt22.GetComponent<Button>();
    _buttonAction23 = _objActionBt23.GetComponent<Button>();
    _buttonAction24 = _objActionBt24.GetComponent<Button>();


    for (var i = 0; i < _objActionCharBtsA.transform.childCount; i++)
    {
        _objActionBts[i] = _objActionCharBtsA.transform.GetChild(i).gameObject;
    }
    _objActionBt31 = _objActionBts[0];
    _objActionBt32 = _objActionBts[1];
    _objActionBt33 = _objActionBts[2];
    _objActionBt34 = _objActionBts[3];

    _buttonAction31 = _objActionBt31.GetComponent<Button>();
    _buttonAction32 = _objActionBt32.GetComponent<Button>();
    _buttonAction33 = _objActionBt33.GetComponent<Button>();
    _buttonAction34 = _objActionBt34.GetComponent<Button>();



    for (var i = 0; i < _objActionCharBtsB.transform.childCount; i++)
    {
        _objActionBts[i] = _objActionCharBtsB.transform.GetChild(i).gameObject;
    }
    _objActionBt41 = _objActionBts[0];
    _objActionBt42 = _objActionBts[1];
    _objActionBt43 = _objActionBts[2];
    _objActionBt44 = _objActionBts[3];

    _buttonAction41 = _objActionBt41.GetComponent<Button>();
    _buttonAction42 = _objActionBt42.GetComponent<Button>();
    _buttonAction43 = _objActionBt43.GetComponent<Button>();
    _buttonAction44 = _objActionBt44.GetComponent<Button>();


    }


    public void ClearLog() //#Temporario
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
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
            if (_objCharBtns.TryGetValue(pressedObjButton, out var isSelectedbutton))
            {
                if (!isSelectedbutton)
                {
                    _objCharBtns[pressedObjButton] = true;
                }
            }
            return true;
        }
        return false;
    }


    private void DelectCharButton(GameObject pressedObjButton)
    {
        if (pressedObjButton != null)
        {
            if (_objCharBtns.TryGetValue(pressedObjButton, out var isSelectedButton))
            {
                if (isSelectedButton)
                {
                    _objCharBtns[pressedObjButton] = false;
                }
            }
        }
    }


    private void SetActionCharBt(GameObject charBtn)
    {
        if (_objCharActionBts.TryGetValue(charBtn, out var objCharActionBt))
        {
            for (var i = 0; i < objCharActionBt.transform.childCount; i++)
            {
                _objActionBts[i] = objCharActionBt.transform.GetChild(i).gameObject;
            }
        }
    }

    void OnEnable()
    {
        _buttonCharY?.onClick.AddListener(() => _clickedCharButton = _objButtonCharY);
        _buttonCharX?.onClick.AddListener(() => _clickedCharButton = _objButtonCharX);
        _buttonCharA?.onClick.AddListener(() => _clickedCharButton = _objButtonCharA);
        _buttonCharB?.onClick.AddListener(() => _clickedCharButton = _objButtonCharB);

        _btTargetCharY?.onClick.AddListener(() => _clickedTargetButton = _objBtTargetCharY);
        _btTargetCharX?.onClick.AddListener(() => _clickedTargetButton = _objBtTargetCharX);
        _btTargetCharA?.onClick.AddListener(() => _clickedTargetButton = _objBtTargetCharA);
        _btTargetCharB?.onClick.AddListener(() => _clickedTargetButton = _objBtTargetCharB);

        _btTargetEnemY?.onClick.AddListener(() => _clickedTargetButton = _objBtTargetEnemY);
        _btTargetEnemX?.onClick.AddListener(() => _clickedTargetButton = _objBtTargetEnemX);
        _btTargetEnemA?.onClick.AddListener(() => _clickedTargetButton = _objBtTargetEnemA);
        _btTargetEnemB?.onClick.AddListener(() => _clickedTargetButton = _objBtTargetEnemB);

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
        if (Input.GetKeyDown(KeyCode.Q)) //#Temporario
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
            if (_isBackOption)
            {
                _countSelectedTgtActs = selectedTargetActions.Count;

                if (_countSelectedTgtActs > 0)
                {
                    _battleStates = GameStateCtrl.BattleStates.SelectTarget;
                    DeactiveObjButtons(_objCharBts);
                    _isActiveObjButton   = false;

                    _clickedCharButton   = selectedTargetActions.Peek().ObjChar;
                    _clickedActionButton = selectedTargetActions.Peek().ObjAction;
                    _clickedTargetButton = selectedTargetActions.Peek().ObjTarget;
                    selectedTargetActions.Pop();
                    orderedTargets.RemoveAt(orderedTargets.Count-1);
                }
                _isBackOption = false;
            }
            else
            {
                if (!_isActiveObjButton)
                {
                    ActiveObjCharButtons(_objCharBtns);
                    _isActiveObjButton = true;
                    _clickedCharButton = null;

                }

                if (SelectCharButton(_clickedCharButton) && _isActiveObjButton)
                {
                    DeactiveObjButtons(_objCharBts);
                    _isActiveObjButton = false;
                    _battleStates = GameStateCtrl.BattleStates.SelectAction;
                }
            }
        }

        if (_battleStates.Equals(GameStateCtrl.BattleStates.SelectAction))
        {
            if (_isBackOption)
            {
                _battleStates = GameStateCtrl.BattleStates.SelectActor;
                DeactiveObjButtons(_objActionBts);
                DelectCharButton(_clickedCharButton);
                _isBackOption = false;
                _isActiveObjButton = false;
            }
            else
            {
                if (!_isActiveObjButton)
                {
                    SetActionCharBt(_clickedCharButton);
                    ActiveObjButtons(_objActionBts);
                    _isActiveObjButton = true;
                    _clickedActionButton = null;
                }

                if (_clickedActionButton != null && _isActiveObjButton)
                {
                    DeactiveObjButtons(_objActionBts);
                    _isActiveObjButton = false;
                    _battleStates = GameStateCtrl.BattleStates.SelectTarget;
                }
            }
        }

        if (_battleStates.Equals(GameStateCtrl.BattleStates.SelectTarget))
        {
            if (_isBackOption)
            {
                _battleStates = GameStateCtrl.BattleStates.SelectAction;
                DeactiveObjButtons(_objTargetCharBts);
                DeactiveObjButtons(_objTargetEnemBts);
                _isBackOption = false;
                _isActiveObjButton = false;
            }
            else
            {
                if (!_isActiveObjButton)
                {
                    ActiveObjButtons(_objTargetEnemBts);
                    _isActiveObjButton = true;
                    _clickedTargetButton = null;
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    ActiveObjButtons(_objTargetCharBts);
                    DeactiveObjButtons(_objTargetEnemBts);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    ActiveObjButtons(_objTargetEnemBts);
                    DeactiveObjButtons(_objTargetCharBts);
                }

                if (_clickedTargetButton != null && _isActiveObjButton)
                {
                    DeactiveObjButtons(_objTargetCharBts);
                    DeactiveObjButtons(_objTargetEnemBts);
                    _isActiveObjButton = false;

                    _battleStates = GameStateCtrl.BattleStates.BattlePhase;

                    _charAction = new CharAction(_clickedTargetButton,_clickedCharButton, _clickedActionButton);
                    selectedTargetActions.Push(_charAction);

                    orderedTargets.Add(_charAction.TargetName);
               
                    foreach (var charBtn in _objCharBtns)
                    {
                        if (!charBtn.Value)
                        {
                            _battleStates = GameStateCtrl.BattleStates.SelectActor;
                        }
                    }
                }
            }
        }

        if (_battleStates.Equals(GameStateCtrl.BattleStates.BattlePhase))
        {
            if (!_isActiveObjButton)
            {
                foreach (CharAction targetAction in selectedTargetActions)
                {
                    actionSortManager.AddAction(targetAction.TargetName,targetAction.CharName,targetAction.ActionName);
                }
                selectedTargetActions.Pop();
                _isActiveObjButton = true;

                ////#Pendente vai haver um passo aqui no meio onde o ActionSortManager vai com as chaves buscar as informações de ataque e etc

                foreach (string target in orderedTargets)
                {
                    Debug.Log(target);
                }

                foreach (string target in orderedTargets)
                {
                    actionSortManager.PrintActions(target); //#Temporario
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.B)) //#Temporario
            {
                Debug.Log(_battleStates);
                _isBackOption = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.T)) //#Temporario
        {

        }

        if (Input.GetKeyDown(KeyCode.S)) //#Temporario
        {
            Debug.Log(_battleStates);
        }

        if (Input.GetKeyDown(KeyCode.P)) //#Temporario
        {

        }
    }
}