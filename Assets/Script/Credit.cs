using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public Rigidbody2D _body;
    public float movement;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _body.velocity = new Vector2(movement, 0f);
    }
}
