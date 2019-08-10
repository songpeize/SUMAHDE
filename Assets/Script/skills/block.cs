using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    player_left pl;
    player_right pr;
    AI_1 ai;
    int player;     // 0: left, 1: right, 2: AI

    // Start is called before the first frame update
    void Start()
    {
        pl = GetComponent<player_left>();
        pr = GetComponent<player_right>();
        ai = GetComponent<AI_1>();
        if (pl != null)
        {
            player = 0;
        }
        if (pr != null)
        {
            player = 1;
        }
        if (ai != null)
        {
            player = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == 0)
        {
            GameObject CL1 = GameObject.Find("CL1");
            TextMesh cl1 = CL1.GetComponent<TextMesh>();
            cl1.text = "T Blocks: Ready";

            player_left();
        }
        if (player == 1)
        {
            GameObject CR1 = GameObject.Find("CR1");
            TextMesh cr1 = CR1.GetComponent<TextMesh>();
            cr1.text = ", Blocks: Ready";

            player_right();
        }
        if (player == 2)
        {
            GameObject CR1 = GameObject.Find("CR1");
            TextMesh cr1 = CR1.GetComponent<TextMesh>();
            cr1.text = ", Blocks: Ready";

            player_ai();
        }
    }

    void player_left()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(pl.mana > 0)
            {
                pl.mana -= 1;
                GameObject w1 = GameObject.Find("w1");
                GameObject w2 = GameObject.Find("w2");
                GameObject w3 = GameObject.Find("w3");
                if (w1.transform.position.x == -17 && w2.transform.position.x == -17)
                {
                    w3.transform.position = new Vector3(-17, -2, 0);
                    w3.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    StartCoroutine(waiter(w3));
                }
                else if (w1.transform.position.x == -17)
                {
                    w2.transform.position = new Vector3(-17, 2, 0);
                    w2.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    StartCoroutine(waiter(w2));
                }
                else
                {
                    w1.transform.position = new Vector3(-17, 0, 0);
                    w1.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    StartCoroutine(waiter(w1));
                }
            }
        }
    }

    void player_right()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            if(pr.mana > 0)
            {
                pr.mana -= 1;
                GameObject w4 = GameObject.Find("w4");
                GameObject w5 = GameObject.Find("w5");
                GameObject w6 = GameObject.Find("w6");
                if (w4.transform.position.x == 17 && w5.transform.position.x == 17)
                {
                    w6.transform.position = new Vector3(17, -2, 0);
                    w6.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    StartCoroutine(waiter(w6));
                }
                else if (w4.transform.position.x == 17)
                {
                    w5.transform.position = new Vector3(17, 2, 0);
                    w5.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    StartCoroutine(waiter(w5));
                }
                else
                {
                    w4.transform.position = new Vector3(17, 0, 0);
                    w4.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    StartCoroutine(waiter(w4));
                }
            }
        }
    }

    void player_ai()
    {
        int dothis = Random.Range(0, 500);
        if (dothis == 0)
        {
            if (ai.mana > 0 && ai.talking == 0)
            {
                ai.mana -= 1;
                GameObject w4 = GameObject.Find("w4");
                GameObject w5 = GameObject.Find("w5");
                GameObject w6 = GameObject.Find("w6");

                if (w4.transform.position.x == 17 && w5.transform.position.x == 17)
                {
                    w6.transform.position = new Vector3(17, -2, 0);
                    w6.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    StartCoroutine(waiter(w6));
                }
                else if (w4.transform.position.x == 17)
                {
                    w5.transform.position = new Vector3(17, 2, 0);
                    w5.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    StartCoroutine(waiter(w5));
                }
                else
                {
                    w4.transform.position = new Vector3(17, 0, 0);
                    w4.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    StartCoroutine(waiter(w4));
                }
            }
        }
    }

    IEnumerator waiter(GameObject w)
    {
        yield return new WaitForSeconds(2);
        w.transform.position = new Vector3(100, 100, 0);
    }
}
