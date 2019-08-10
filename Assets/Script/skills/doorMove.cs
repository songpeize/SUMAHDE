using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorMove : MonoBehaviour
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
                cl2.text = "Y Door Move: " + Mathf.RoundToInt(nextCast1 - Time.time);
            }
            else
                cl2.text = "Y Door Move: Ready";

            player_left();
        }
        if (player == 1)
        {
            GameObject CR2 = GameObject.Find("CR2");
            TextMesh cr2 = CR2.GetComponent<TextMesh>();
            if (Time.time < nextCast2)
            {
                cr2.text = ". Door Move: " + Mathf.RoundToInt(nextCast2 - Time.time);
            }
            else
                cr2.text = ". Door Move: Ready";

            player_right();
        }
        if (player == 2)
        {
            GameObject CR2 = GameObject.Find("CR2");
            TextMesh cr2 = CR2.GetComponent<TextMesh>();
            if (Time.time < nextCast3)
            {

                cr2.text = ". Door Move: " + Mathf.RoundToInt(nextCast3 - Time.time);
            }
            else
                cr2.text = ". Door Move: Ready";

            player_ai();
        }
    }

    void player_left()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if(pl.mana > 0 && Time.time > nextCast1)
            {
                nextCast1 = Time.time + CD;
                pl.mana -= 1;
                GameObject ld = GameObject.Find("LeftDoor");
                int where = Random.Range(-10, 11);
                ld.transform.position = new Vector3(-18.3f, where, 0);
            }
        }
    }

    void player_right()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            if(pr.mana > 0 && Time.time > nextCast2)
            {
                nextCast2 = Time.time + CD;
                pr.mana -= 1;
                GameObject ld = GameObject.Find("RightDoor");
                int where = Random.Range(-10, 11);
                ld.transform.position = new Vector3(18.3f, where, 0);
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
                nextCast3 = Time.time + CD;
                ai.mana -= 1;
                GameObject ld = GameObject.Find("RightDoor");
                int where = Random.Range(-10, 11);
                ld.transform.position = new Vector3(18.3f, where, 0);
            }
        }
    }
}
