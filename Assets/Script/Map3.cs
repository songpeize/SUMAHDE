using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map3 : MonoBehaviour
{
    private GameObject body;
    public string tag1;
    public float timer1;
    public float timer2;


    void Start()
    {
        body = GameObject.Find("portal");
        timer1 = 1.0f;
        timer2 = 6.0f;
    }

    private void Update()
    {
        body = GameObject.Find("portal");
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        float x = Random.Range(-16, 16);
        float y = Random.Range(-9, 9);
        if (timer1 < 0)
        {
            body.transform.position = new Vector3(x, y, 0);
            timer1 += 10;
        }
        if (timer2 < 0)
        {
            body.transform.position = new Vector3(100, 0, 0);
            timer2 += 10;
        }//StartCoroutine(waiter());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        body = GameObject.Find("portal");
        if (collision.tag == "Ball")
        {
            timer1 += 10000;
            body.transform.position = new Vector3(100, 0, 0);
        }
    }
}
