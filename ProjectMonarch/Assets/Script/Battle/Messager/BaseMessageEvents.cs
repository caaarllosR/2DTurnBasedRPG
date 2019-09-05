using System.Collections.Generic;
using UnityEngine;

public class BattleMessageEvent
{
    
}


public class SelectCharMessage : BattleMessageEvent
{
    public GameObject Char { get; set; }
    public GameObject CharButton { get; set; }
}

public class SelectEnemyMessage : BattleMessageEvent
{
    public GameObject Enemy { get; set; }
}

public class SelectTargetButtonMessage : BattleMessageEvent
{
    public GameObject[] TargetButtons { get; set; }
}

public class SelectActionMessage : BattleMessageEvent
{
    public GameObject Action { get; set; }
}

public class SelectCharButtonMessage : BattleMessageEvent
{

}
