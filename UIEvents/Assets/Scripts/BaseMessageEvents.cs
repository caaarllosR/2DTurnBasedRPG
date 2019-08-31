
public class BaseMessageEvents
{

}


public class UpdateGoldMessageEvents : BaseMessageEvents
{
    public int GoldAmount { get; set; }
}

public class ReceivedGoldMessageEvents : BaseMessageEvents
{
    public int GoldReceivedAmount { get; set; }
}

public class TestGoldMessageEvents : BaseMessageEvents
{
    public int GoldAmount { get; set; }
}

public class TestGoldMessageEvents2 : BaseMessageEvents
{
    public int GoldReceivedAmount { get; set; }
}

