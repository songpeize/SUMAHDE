using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeShrink : MonoBehaviour
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
        if(ai != null)
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
                cl1.text = "T Size Shrink: " + Mathf.RoundToInt(nextCast1 - Time.time);
            }
            else
                cl1.text = "T Size Shrink: Ready";

            player_left();
        }
        if (player == 1)
        {
            GameObject CR1 = GameObject.Find("CR1");
            TextMesh cr1 = CR1.GetComponent<TextMesh>();
            if (Time.time < nextCast2)
            {
                cr1.text = ", Size Shrink: " + Mathf.RoundToInt(nextCast2 - Time.time);
            }
            else
                cr1.text = ", Size Shrink: Ready";

            player_right();
        }
        if (player == 2)
        {
            GameObject CR1 = GameObject.Find("CR1");
            TextMesh cr1 = CR1.GetComponent<TextMesh>();
            if (Time.time < nextCast3)
            {

                cr1.text = ", Size Shrink: " + Mathf.RoundToInt(nextCast3 - Time.time);
            }
            else
                cr1.text = ", Size Shrink: Ready";

            player_ai();
        }
    }

    void player_left()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(pl.mana > 0 && Time.time > nextCast1)
            {
                nextCast1 = Time.time + CD;
                pl.mana -= 1;
                GameObject oppo = GameObject.Find("play2");
                player_right pr = oppo.GetComponent<player_right>();
                AI_1 ai1 = oppo.GetComponent<AI_1>();
                float size = Random.Range(5, 8);
                if (pr != null)
                    pr.transform.localScale = new Vector2(0.2f * size * 0.1f, 0.2f * size * 0.1f);
                if (ai1 != null)
                    ai1.transform.localScale = new Vector2(0.2f * size * 0.1f, 0.2f * size * 0.1f);
            }
        }
    }

    void player_right()
    {
        if (Input.GetKeyDown(KeyCode.Period))
        {
            if(pr.mana > 0 && Time.time > nextCast2)
            {
                nextCast2 = Time.time + CD;
                pr.mana -= 1;
                GameObject oppo = GameObject.Find("play1");
                player_left pl = oppo.GetComponent<player_left>();
                AI_1 ai1 = oppo.GetComponent<AI_1>();
                float size = Random.Range(5, 8);
                if (pl != null)
                    pl.transform.localScale = new Vector2(0.2f * size * 0.1f, 0.2f * size * 0.1f);
                if (ai1 != null)
                    ai1.transform.localScale = new Vector2(size, 2.6f * size);
            }
        }
    }

    void player_ai()
    {
        int dothis = Random.Range(0, 1000);
        if(dothis == 0)
        {
            if(ai.mana > 0 && Time.time > nextCast3 && ai.talking == 0)
            {
                nextCast3 = Time.time + CD;
                ai.mana -= 1;
                GameObject oppo = GameObject.Find("play1");
                player_left pl = oppo.GetComponent<player_left>();
                AI_1 ai1 = oppo.GetComponent<AI_1>();
                float size = Random.Range(5, 8);
                if (pl != null)
                    pl.transform.localScale = new Vector2(0.2f * size * 0.1f, 0.2f * size * 0.1f);
                if (ai1 != null)
                    ai1.transform.localScale = new Vector2(size, 2.6f * size);
            }
        }
    }
}
