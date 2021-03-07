using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : Target
{
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void Tap(ref int score, ref int health) {
        score += 1;
    }

    public override void Drop(ref int score, ref int health) { 
        health -= 1;
    }
}
