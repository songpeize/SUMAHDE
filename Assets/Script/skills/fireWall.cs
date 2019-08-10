using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireWall : MonoBehaviour
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
            GameObject CL2 = GameObject.Find("CL2");
            TextMesh cl2 = CL2.GetComponent<TextMesh>();
            if (Time.time < nextCast1)
            {
                cl2.text = "Y FireWall: " + Mathf.RoundToInt(nextCast1 - Time.time);
            }
            else
                cl2.text = "Y FireWall: Ready";

            player_left();
        }
        if (player == 1)
        {
            GameObject CR2 = GameObject.Find("CR2");
            TextMesh cr2 = CR2.GetComponent<TextMesh>();
            if (Time.time < nextCast2)
            {
                cr2.text = ". FireWall: " + Mathf.RoundToInt(nextCast2 - Time.time);
            }
            else
                cr2.text = ". FireWall: Ready";

            player_right();
        }
        if (player == 2)
        {
            GameObject CR2 = GameObject.Find("CR2");
            TextMesh cr2 = CR2.GetComponent<TextMesh>();
            if (Time.time < nextCast3)
            {
                cr2.text = ". FireWall: " + Mathf.RoundToInt(nextCast3 - Time.time);
            }
            else
                cr2.text = ". FireWall: Ready";

            player_ai();
        }
    }

    void player_left()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (pl.mana > 0 && Time.time > nextCast1)
            {
                GameObject fw = GameObject.Find("FireWall1");
                GameObject ball = GameObject.Find("Ball");
                Rigidbody2D ball_rb = ball.GetComponent<Rigidbody2D>();
                if(ball.transform.position.x > pl.transform.position.x && ball_rb.velocity.x < 0)
                {
                    nextCast1 = Time.time + CD;
                    pl.mana -= 1;
                    fw.transform.position = new Vector3(ball.transform.position.x - 2, ball.transform.position.y, ball.transform.position.z);
                    StartCoroutine(waiter(fw));
                }
            }
        }
    }

    void player_right()
    {
        if (Input.GetKeyDown(KeyCode.Period))
        {
            if (pr.mana > 0 && Time.time > nextCast2)
            {
                GameObject fw = GameObject.Find("FireWall2");
                GameObject ball = GameObject.Find("Ball");
                Rigidbody2D ball_rb = ball.GetComponent<Rigidbody2D>();
                if (ball.transform.position.x < pr.transform.position.x && ball_rb.velocity.x > 0)
                {
                    nextCast2 = Time.time + CD;
                    pr.mana -= 1;
                    fw.transform.position = new Vector3(ball.transform.position.x + 2, ball.transform.position.y, ball.transform.position.z);
                    StartCoroutine(waiter(fw));
                }
            }
        }
    }

    void player_ai()
    {
        int dothis = Random.Range(0, 1000);
        if (dothis == 0)
        {
            if (ai.mana > 0 && Time.time > nextCast3 && ai.talking == 0)
            {
                GameObject fw = GameObject.Find("FireWall2");
                GameObject ball = GameObject.Find("Ball");
                Rigidbody2D ball_rb = ball.GetComponent<Rigidbody2D>();
                if (ball.transform.position.x < ai.transform.position.x && ball_rb.velocity.x > 0)
                {
                    nextCast2 = Time.time + CD;
                    ai.mana -= 1;
                    fw.transform.position = new Vector3(ball.transform.position.x + 1, ball.transform.position.y, ball.transform.position.z);
                    StartCoroutine(waiter(fw));
                }
            }
        }
    }

    IEnumerator waiter(GameObject w)
    {
        yield return new WaitForSeconds(0.5f);
        w.transform.position = new Vector3(100, 100, 0);
    }
}
