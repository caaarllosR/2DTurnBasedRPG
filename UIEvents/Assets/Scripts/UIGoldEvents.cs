using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class UIGoldEvents : MonoBehaviour {

    private Text _goldText;

    // Use this for initialization
    private void Awake()
    {
        _goldText = GetComponent<Text>();

    }

    private void Start()
    {
        MessageManagerEvents<BaseMessageEvents>.Instance.AddListener<BaseMessageEvents, UpdateGoldMessageEvents>(OnUpdateGold);
        MessageManagerEvents<BaseMessageEvents>.Instance.AddListener<BaseMessageEvents, UpdateGoldMessageEvents>(OnUpdateGold);
        MessageManagerEvents<BaseMessageEvents>.Instance.AddListener<BaseMessageEvents, UpdateGoldMessageEvents>(OnUpdateGold);
        MessageManagerEvents<BaseMessageEvents>.Instance.AddListener<BaseMessageEvents,TestGoldMessageEvents2>(OnUpdateGolds);

    }

    private void OnDestroy()
    {
        MessageManagerEvents<BaseMessageEvents>.Instance.RemoveListener<BaseMessageEvents,UpdateGoldMessageEvents>(OnUpdateGold);
    }

    private void OnUpdateGold(UpdateGoldMessageEvents message)
    {
        _goldText.text = message.GoldAmount.ToString();  
    }

    private void OnUpdateGolds(TestGoldMessageEvents2 message)
    {
    }
}
