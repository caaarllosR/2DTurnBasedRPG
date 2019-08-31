using UnityEngine;

public class PlayerInventoryEvents : MonoBehaviour {

    private int _currentGold;
    private int _receivedGold;

    public void AddGold(int amount)
    {
        _currentGold += amount;
        _receivedGold += amount;
        UpdateGoldUI();
        UpdateReceivedGoldUI();
    }
    public void RemoveGold(int amount)
    {
        _currentGold -= amount;
        UpdateGoldUI();
    }

    private void UpdateGoldUI()
    {
        MessageManagerEvents<BaseMessageEvents>.Instance.DynamicInvokeAll<BaseMessageEvents>(new UpdateGoldMessageEvents
        {
            GoldAmount = _currentGold
        });

        MessageManagerEvents<BaseMessageEvents>.Instance.DynamicInvokeAll<BaseMessageEvents>(new TestGoldMessageEvents
        {
            GoldAmount = _currentGold
        });
    }

    private void UpdateReceivedGoldUI()
    {
        MessageManagerEvents<BaseMessageEvents>.Instance.DynamicInvokeAll<BaseMessageEvents>(new ReceivedGoldMessageEvents
        {
            GoldReceivedAmount = _receivedGold
        });
    }
}
