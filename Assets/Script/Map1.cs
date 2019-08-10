using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1 : MonoBehaviour
{
    public Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        int a = 1;
        while (a == 1)
        {
            int wait_time = Random.Range(5, 10);
            int x = Random.Range(-13, 13);
            int y = Random.Range(-9, 9);
            yield return new WaitForSeconds(wait_time);
            body.transform.position = new Vector3(x, y, 0);
            body.transform.localRotation = Quaternion.Euler(0, 0, 0);
            yield return new WaitForSeconds(wait_time);
            body.transform.position = new Vector3(100, 100, 0);
        }
    }
}
