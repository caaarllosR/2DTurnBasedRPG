using UnityEngine;

public class Command1 : ICommand
{
    public void Execute()
    {
        Debug.Log("Command1");
    }
}

public class Command2 : ICommand
{
    public void Execute()
    {
        Debug.Log("Command2");
    }
}

public class Command3 : ICommand
{
    public void Execute()
    {
        Debug.Log("Command3");
    }
}

public class Command4 : ICommand
{
    public void Execute()
    {
        Debug.Log("Command4");
    }
}
