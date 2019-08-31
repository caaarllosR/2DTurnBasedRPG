using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Text))]
public class UIReceivedGoldEvents : MonoBehaviour
{
    private Text _goldReceivedText;

    // Use this for initialization
    private void Awake()
    {
        _goldReceivedText = GetComponent<Text>();
    }

    private void Start()
    {
        MessageManagerEvents<BaseMessageEvents>.Instance.AddListener<BaseMessageEvents, ReceivedGoldMessageEvents>(OnReceivedGold);
        MessageManagerEvents<BaseMessageEvents>.Instance.AddListener<BaseMessageEvents, ReceivedGoldMessageEvents>(OnReceivedGold);
        MessageManagerEvents<BaseMessageEvents>.Instance.AddListener<BaseMessageEvents, ReceivedGoldMessageEvents>(OnReceivedGolds);
        MessageManagerEvents<BaseMessageEvents>.Instance.AddListener<BaseMessageEvents, ReceivedGoldMessageEvents>(OnReceivedGold);
        MessageManagerEvents<BaseMessageEvents>.Instance.AddListener<BaseMessageEvents, ReceivedGoldMessageEvents>(OnReceivedGold);
        MessageManagerEvents<BaseMessageEvents>.Instance.AddListener<BaseMessageEvents, TestGoldMessageEvents>(OnReceivedGoldss);
    }

    private void OnDestroy()
    {
        MessageManagerEvents<BaseMessageEvents>.Instance.RemoveListener<BaseMessageEvents, ReceivedGoldMessageEvents>(OnReceivedGold);
    }

    private void OnReceivedGold(ReceivedGoldMessageEvents message)
    {
        _goldReceivedText.text = message.GoldReceivedAmount.ToString();
    }

    private void OnReceivedGolds(ReceivedGoldMessageEvents message)
    {
        Debug.Log("2");
    }

    private void OnReceivedGoldss(TestGoldMessageEvents message)
    {
    }
}
