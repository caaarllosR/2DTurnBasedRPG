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

public class SelectActionMessage : BattleMessageEvent
{
    public GameObject Action { get; set; }
}

public class SelectButtonMessage : BattleMessageEvent
{

}

public class SelectEnemyMessage : BattleMessageEvent
{
    public GameObject Enem { get; set; }
}