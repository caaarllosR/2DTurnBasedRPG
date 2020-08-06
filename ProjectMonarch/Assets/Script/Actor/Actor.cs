using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Actor", menuName = "Actor")]
public class Actor : ScriptableObject
{
    public Sprite _sprite;
    public Animator _animator;

}
