using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evolve : MonoBehaviour
{
    player_left pl;
    player_right pr;
    AI_1 ai;
    int player;     // 0: left, 1: right, 2: AI

    float CD = 3;
    public float nextCast1 = 0;
    public float nextCast2 = 0;
    public float nextCast3 = 0;
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
            if (Time.time < nextCast1)
            {
                cl1.text = "T SpeedUp: " + Mathf.RoundToInt(nextCast1 - Time.time);
            }
            else
                cl1.text = "T SpeedUp: Ready";

            player_left();
        }

        if (player == 1)
        {
            GameObject CR1 = GameObject.Find("CR1");
            TextMesh cr1 = CR1.GetComponent<TextMesh>();
            if (Time.time < nextCast2)
            {
                cr1.text = ", SpeedUp: " + Mathf.RoundToInt(nextCast2 - Time.time);
            }
            else
                cr1.text = ", SpeedUp: Ready";

            player_right();
        }
        if (player == 2)
        {
            GameObject CR1 = GameObject.Find("CR1");
            TextMesh cr1 = CR1.GetComponent<TextMesh>();
            if (Time.time < nextCast3)
            {

                cr1.text = ", SpeedUp: " + Mathf.RoundToInt(nextCast3 - Time.time);
            }
            else
                cr1.text = ", SpeedUp: Ready";

            player_ai();
        }
    }

    void player_left()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (pl.mana > 0 && Time.time > nextCast1)
            {
                pl.mana -= 1;
                // Rigidbody2D rb = pl.GetComponent<Rigidbody2D>();
                pl.baseSpeed = pl.baseSpeed * 2;
                StartCoroutine(waiter_l(pl));
                nextCast1 = Time.time + CD;
            }
        }
    }

    void player_right()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            if (pr.mana > 0 && Time.time > nextCast2)
            {
                pr.mana -= 1;
                // Rigidbody2D rb = pr.GetComponent<Rigidbody2D>();
                pr.baseSpeed = pr.baseSpeed * 2;
                StartCoroutine(waiter_r(pr));
                nextCast2 = Time.time + CD;
            }
        }
    }

    void player_ai()
    {
        int dothis = Random.Range(0, 1000);
        if (dothis == 0)
        {
            if (ai.mana > 0 && Time.time > nextCast3)
            {
                ai.mana -= 1;
                ai.baseSpeed = ai.baseSpeed * 2;
                StartCoroutine(waiter_a(ai));
                nextCast3 = Time.time + CD;
            }
        }
    }

    IEnumerator waiter_l(player_left w)
    {
        yield return new WaitForSeconds(0.5f);
        w.baseSpeed = w.baseSpeed / 2;
    }

    IEnumerator waiter_r(player_right w)
    {
        yield return new WaitForSeconds(0.5f);
        w.baseSpeed = w.baseSpeed / 2;
    }

    IEnumerator waiter_a(AI_1 w)
    {
        yield return new WaitForSeconds(0.5f);
        w.baseSpeed = w.baseSpeed / 2;
    }
}