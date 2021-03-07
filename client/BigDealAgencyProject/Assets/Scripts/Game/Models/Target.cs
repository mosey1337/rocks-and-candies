using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : MonoBehaviour
{
    
    public abstract void Tap(ref int score, ref int health);
    public abstract void Drop(ref int score, ref int health);
}
