using UnityEngine;

public class Stone : Target
{
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public override void Tap(ref int score, ref int health) {
        health -= 1;
    }

    public override void Drop(ref int score, ref int health) { }
}
