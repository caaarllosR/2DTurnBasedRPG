using UnityEngine;


public class InputHandler
{
    private static InputHandler _instance;

    public static InputHandler Instance
    {
        get { return _instance ?? (_instance = new InputHandler()); }
    }

    private InputHandler()
    {

    }

    private ICommand CommandX_ = new Command1();
    private ICommand CommandY_ = new Command2();
    private ICommand CommandA_ = new Command3();
    private ICommand CommandB_ = new Command4();

    private bool button_X;
    private bool button_Y;
    private bool button_A;
    private bool button_B;

    private bool Enter;

    private void HandlerInput()
    {
        button_X = Input.GetKeyDown("a");
        button_Y = Input.GetKeyDown("s");
        button_A = Input.GetKeyDown("d");
        button_B = Input.GetKeyDown("w");
    }

    private ICommand HandlerCommand()
    {
        if (button_X)
        {
            return CommandX_;
        }
        if (button_Y)
        {
            return CommandY_;
        }
        if (button_A)
        {
            return CommandA_;
        }
        if (button_B)
        {
            return CommandB_;
        }
        return null;
    }

    public void ExecuteCommand()
    {
        HandlerInput();
        if (Input.anyKeyDown)
        {
            HandlerCommand()?.Execute();
        }
    }
}
