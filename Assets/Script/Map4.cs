using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map4 : MonoBehaviour
{
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(10, 15);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject bh1 = GameObject.Find("BH1");
        GameObject bh2 = GameObject.Find("BH2");
        timer -= Time.deltaTime;
        float x = Random.Range(5, 12);
        if(timer < 0)
        {
            float x1 = Random.Range(-16, 16);
            float x2 = Random.Range(-16, 16);
            float y1 = Random.Range(-9, 9);
            float y2 = Random.Range(-9, 9);
            bh1.transform.position = new Vector3(x1, y1, 0);
            bh2.transform.position = new Vector3(x2, y2, 0);
            timer += Random.Range(15, 20);
        }
        else if(timer < x)
        {
            bh1.transform.position = new Vector3(100, 100, 0);
            bh2.transform.position = new Vector3(100, 100, 0);
        }

    }

}
