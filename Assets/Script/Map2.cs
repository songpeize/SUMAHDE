using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2 : MonoBehaviour
{
    private float timer = 5.0f;
    private Rigidbody2D t1;
    private Rigidbody2D t2;
    private bool reset;

    // Start is called before the first frame update
    void Start()
    {
        reset = false;
        t1 = GetComponent<Rigidbody2D>();
        timer = Random.Range(10, 15);
        GameObject Wave2 = GameObject.Find("Wave2");
        t2 = Wave2.GetComponent<Rigidbody2D>();
    }

    // Update is called once per fram
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.2f && timer > 0)
        {
            t1.transform.position = new Vector3(-1, 0, 0);
            t1.transform.localRotation = Quaternion.Euler(0, 0, 0);
            t2.transform.position = new Vector3(1, 0, 0);
            t2.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (timer < 0)
        {
            t1.velocity = new Vector3(-13, 0, 0);
            t2.velocity = new Vector3(13, 0, 0);
            reset = true;

        }
        if (t1.position[0] < -16 && reset == true)
        {
            t1.velocity = new Vector3(0, 0, 0);
            t2.velocity = new Vector3(0, 0, 0);
            timer = Random.Range(10, 15);
            t1.transform.position = new Vector3(-25, 0, 0);
            t2.transform.position = new Vector3(25, 0, 0);
            reset = false;
        }
    }
}