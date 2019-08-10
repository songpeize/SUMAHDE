using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    player_left pl;
    player_right pr;
    AI_1 ai;
    int player;     // 0: left, 1: right, 2: AI

    float CD = 3;
    public float nextCast1;
    public float nextCast2;
    public float nextCast3;
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
                cl1.text = "T Teleport: " + Mathf.RoundToInt(nextCast1 - Time.time);
            }
            else
                cl1.text = "T Teleport: Ready";

            player_left();
        }
        if (player == 1)
        {
            GameObject CR1 = GameObject.Find("CR1");
            TextMesh cr1 = CR1.GetComponent<TextMesh>();
            if (Time.time < nextCast2)
            {
                cr1.text = ", Teleport: " + Mathf.RoundToInt(nextCast2 - Time.time);
            }
            else
                cr1.text = ", Teleport: Ready";

            player_right();
        }
        if (player == 2)
        {
            GameObject CR1 = GameObject.Find("CR1");
            TextMesh cr1 = CR1.GetComponent<TextMesh>();
            if (Time.time < nextCast2)
            {
                cr1.text = ", Teleport: " + Mathf.RoundToInt(nextCast2 - Time.time);
            }
            else
                cr1.text = ", Teleport: Ready";

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
                nextCast1 = Time.time + CD;
                GameObject ld = GameObject.Find("Ball");
                Rigidbody2D ball = ld.GetComponent<Rigidbody2D>();
                float x = ball.transform.position.x + ball.velocity.x * 0.2f;
                float y = ball.transform.position.y + ball.velocity.y * 0.2f;

                if (x < -18.1)
                {
                    x = -18;
                }
                if (x > 18.1)
                {
                    x = 18;
                }
                if (y < -10)
                {
                    y = -9.9f;
                }
                if (y > 10)
                {
                    y = 9.9f;
                }
                ball.transform.position = new Vector3(x, y, 0);
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
                nextCast2 = Time.time + CD;
                GameObject ld = GameObject.Find("Ball");
                Rigidbody2D ball = ld.GetComponent<Rigidbody2D>();
                float x = ball.transform.position.x + ball.velocity.x * 0.2f;
                float y = ball.transform.position.y + ball.velocity.y * 0.2f;

                if (x < -18.1)
                {
                    x = -18;
                }
                if (x > 18.1)
                {
                    x = 18;
                }
                if (y < -10)
                {
                    y = -9.9f;
                }
                if(y > 10)
                {
                    y = 9.9f;
                }
                ball.transform.position = new Vector3(x, y, 0);
            }
        }
    }

    void player_ai()
    {
        int dothis = Random.Range(0, 1000);
        if(dothis == 0)
        {
            if (ai.mana > 0 && Time.time > nextCast2 && ai.talking == 0)
            {
                ai.mana -= 1;
                nextCast3 = Time.time + CD;
                GameObject ld = GameObject.Find("Ball");
                Rigidbody2D ball = ld.GetComponent<Rigidbody2D>();
                float x = ball.transform.position.x + ball.velocity.x * 0.2f;
                float y = ball.transform.position.y + ball.velocity.y * 0.2f;

                if (x < -18.1)
                {
                    x = -18;
                }
                if (x > 18.1)
                {
                    x = 18;
                }
                if (y < -10)
                {
                    y = -9.9f;
                }
                if (y > 10)
                {
                    y = 9.9f;
                }
                ball.transform.position = new Vector3(x, y, 0);
            }
        }
    }

}
