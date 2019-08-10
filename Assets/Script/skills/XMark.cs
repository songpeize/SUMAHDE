using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMark : MonoBehaviour
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

    void Update()
    {
        if (player == 0)
        {
            GameObject CL2 = GameObject.Find("CL2");
            TextMesh cl2 = CL2.GetComponent<TextMesh>();
            if (Time.time < nextCast1)
            {
                cl2.text = "Y X Mark: " + Mathf.RoundToInt(nextCast1 - Time.time);
            }
            else
                cl2.text = "Y X Mark: Ready";

            player_left();
        }
        if (player == 1)
        {
            GameObject CR2 = GameObject.Find("CR2");
            TextMesh cr2 = CR2.GetComponent<TextMesh>();
            if (Time.time < nextCast2)
            {
                cr2.text = ". X Mark: " + Mathf.RoundToInt(nextCast2 - Time.time);
            }
            else
                cr2.text = ". X Mark: Ready";

            player_right();
        }
        if (player == 2)
        {
            GameObject CR2 = GameObject.Find("CR2");
            TextMesh cr2 = CR2.GetComponent<TextMesh>();
            if (Time.time < nextCast3)
            {
                cr2.text = ". X Mark: " + Mathf.RoundToInt(nextCast3 - Time.time);
            }
            else
                cr2.text = ". X Mark: Ready";

            player_ai();
        }
    }

    // Update is called once per frame
    void player_left()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (pl.mana > 0 && Time.time > nextCast1)
            {
                GameObject x1 = GameObject.Find("XMark1");
                if (x1.transform.position.x == 100 && x1.transform.position.y == 100)
                {
                    x1.transform.position = pl.transform.position;
                }
                else
                {
                    nextCast1 = Time.time + CD;
                    pl.mana -= 1;
                    pl.transform.position = x1.transform.position;
                    x1.transform.position = new Vector3(100, 100, 0);
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
                GameObject x2 = GameObject.Find("XMark2");
                if (x2.transform.position.x == 100 && x2.transform.position.y == 100)
                {
                    x2.transform.position = pr.transform.position;
                }
                else
                {
                    nextCast2 = Time.time + CD;
                    pr.mana -= 1;
                    pr.transform.position = x2.transform.position;
                    x2.transform.position = new Vector3(100, 100, 0);
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
                ai.mana -= 1;
                GameObject oppo = GameObject.Find("play1");
                //player_left pl = oppo.GetComponent<player_left>();
                AI_1 ai1 = oppo.GetComponent<AI_1>();
                float size = Random.Range(5, 8);
                GameObject x3;
                
                if (GlobalControl.Instance.level == 3)
                {
                    x3 = GameObject.Find("XMark4");
                }
                else
                {
                    x3 = GameObject.Find("XMark3");
                }
      
                if (x3.transform.position.x == 100 && x3.transform.position.y == 100)
                {
                    x3.transform.position = ai.transform.position;
                }
                else
                {
                    nextCast3 = Time.time + CD;
                    ai.mana -= 1;
                    ai.transform.position = x3.transform.position;
                    x3.transform.position = new Vector3(100, 100, 0);
                }
            }
        }
    }
}
