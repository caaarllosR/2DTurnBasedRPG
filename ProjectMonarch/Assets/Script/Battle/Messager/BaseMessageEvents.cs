using System.Collections.Generic;
using UnityEngine;

public class BattleMessageEvent
{
    
}


public class SelectActorMessage : BattleMessageEvent
{
    public GameObject Actor { get; set; }
    public GameObject ActorButton { get; set; }
}

public class SelectTargetMessage : BattleMessageEvent
{
    public GameObject Target { get; set; }
    public GameObject TargetButton { get; set; }
}

public class SelectActionMessage : BattleMessageEvent
{
    public GameObject Action { get; set; }
    public GameObject ActionButton { get; set; }
}


public class SelectButtonsMessage : BattleMessageEvent
{
    public GameObject[] Buttons { get; set; }
}

public class SelectBattleStateMessage : BattleMessageEvent
{

}