using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class AI_1 : MonoBehaviour
{
    public float speed = 290.0f;
    public float baseSpeed = 290.0f;
    public Rigidbody2D _body;
    public int mana;
    public Slider ManaStrip;
    public int health;
    public Slider HPStrip;
    public int character;
    public Text TextContent;
    public Text Button;
    public Text Button2;
    public Flowchart flowchart;
    private int level;
    public int talking;

    // Start is called before the first frame update
    void Start()
    {
        level = GlobalControl.Instance.level;
        ManaStrip.value = ManaStrip.maxValue = mana;
        HPStrip.value = HPStrip.maxValue = health;
        _body = GetComponent<Rigidbody2D>();
        mana = 5;
        health = 5;
        if (level == -1)
        {
            character = GlobalControl.Instance.rightPlayer;
        } 
        if (level == 0)
        {
            character = 0;
        }
        if (level == 1)
        {
            character = 2;
        }
        if (level == 2)
        {
            character = 3;
        }
        if (level == 3)
        {
            character = 4;
            health = 100;
            mana = 1000000000;
            baseSpeed = 800f;
            ManaStrip.value = ManaStrip.maxValue = mana;
            HPStrip.value = HPStrip.maxValue = health;
            
        }
        if (level == 4)
        {
            character = 4;
            health = 5;
            mana = 1000000000;
            
            ManaStrip.value = ManaStrip.maxValue = mana;
            HPStrip.value = HPStrip.maxValue = health;

        }

        if (character == 0)
        {
            System.Type skill1 = System.Type.GetType("sizeShrink");
            gameObject.AddComponent(skill1);
            System.Type skill2 = System.Type.GetType("doorMove");
            gameObject.AddComponent(skill2);

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("Desmond");
        }
        if (character == 1)
        {
            System.Type skill3 = System.Type.GetType("freeze");
            gameObject.AddComponent(skill3);
            System.Type skill4 = System.Type.GetType("block");
            gameObject.AddComponent(skill4);

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("Zack");
            sr.flipX = true;
        }
        if (character == 2)
        {
            System.Type skill5 = System.Type.GetType("teleport");
            gameObject.AddComponent(skill5);
            System.Type skill6 = System.Type.GetType("XMark");
            gameObject.AddComponent(skill6);

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            Object[] sprites;
            sprites = Resources.LoadAll<Sprite>("Every");
            sr.sprite = (Sprite)sprites[1];
        }
        if (character == 3)
        {
            System.Type skill7 = System.Type.GetType("evolve");
            gameObject.AddComponent(skill7);
            System.Type skill8 = System.Type.GetType("fireWall");
            gameObject.AddComponent(skill8);

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            Object[] sprites;
            sprites = Resources.LoadAll<Sprite>("Every");
            sr.sprite = (Sprite)sprites[0];
            sr.flipX = true;
        }
        if (character == 4)
        {
            System.Type skill1 = System.Type.GetType("sizeShrink");
            gameObject.AddComponent(skill1);
            System.Type skill2 = System.Type.GetType("doorMove");
            gameObject.AddComponent(skill2);

            System.Type skill3 = System.Type.GetType("freeze");
            gameObject.AddComponent(skill3);
            System.Type skill4 = System.Type.GetType("block");
            gameObject.AddComponent(skill4);


            System.Type skill5 = System.Type.GetType("teleport");
            gameObject.AddComponent(skill5);
            System.Type skill6 = System.Type.GetType("XMark");
            gameObject.AddComponent(skill6);


            System.Type skill7 = System.Type.GetType("evolve");
            gameObject.AddComponent(skill7);
            System.Type skill8 = System.Type.GetType("fireWall");
            gameObject.AddComponent(skill8);

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("Desmond");

        }
    }

    // Update is called once per frame
    void Update()
    {
      if (flowchart.HasExecutingBlocks())
      {
        speed = 0;
        talking = 1;
      }
      else
      {
        speed = baseSpeed;
        talking = 0;
      }
        //if (!flowchart.HasExecutingBlocks())
        //{
            checkHealth();
            checkMana();
            GameObject ball = GameObject.Find("Ball");
            Rigidbody2D ball_body = ball.GetComponent<Rigidbody2D>();
            float diff = 0.2f;

            // ball is static
            if (ball_body.velocity.x == 0)
            {
                // need to be launched
                if (ball.transform.position.x > 0)
                {
                    float deltax = speed * Time.deltaTime;
                    Vector2 movement = new Vector2(-deltax, 0);
                    _body.velocity = movement;
                }
                else
                {
                    _body.velocity = new Vector2(0, 0);
                }
            }
            // ball is higher than AI
            else if (ball.transform.position.y > transform.position.y + diff)
            {
                float deltaY = speed * Time.deltaTime;
                float deltaX = 0;
                if(speed != 0)
                  deltaX = ball_body.velocity.x * 0.2f;

                if (transform.position.x > 14.5f && ball_body.velocity.x > 0)
                    _body.velocity = new Vector2(0, deltaY);
                else
                    _body.velocity = new Vector2(deltaX * 0.2f, deltaY);
            }
            // ball is lower than AI
            else if (ball.transform.position.y < transform.position.y - diff)
            {
              float deltaX = 0;
              if(speed != 0)
                deltaX = ball_body.velocity.x * 0.2f;
              float deltaY = speed * Time.deltaTime;
              if (transform.position.x > 14.5f && ball_body.velocity.x > 0)
                  _body.velocity = new Vector2(0, -deltaY);
              else
                  _body.velocity = new Vector2(deltaX * 0.2f, -deltaY);
            }
            else
            {
                _body.velocity = new Vector2(0, 0);
            }
       // }
    }

    public void reset_AI()
    {
        transform.position = new Vector3(15, 0, 0);
        transform.localScale = new Vector2(0.2f, 0.2f);
        mana = (int)ManaStrip.maxValue;

        sizeShrink ss = GetComponent<sizeShrink>();
        if (ss != null)
        {
            ss.nextCast1 = 0;
            ss.nextCast2 = 0;
            ss.nextCast3 = 0;
        }
        doorMove dm = GetComponent<doorMove>();
        if (dm != null)
        {
            dm.nextCast1 = 0;
            dm.nextCast2 = 0;
            dm.nextCast3 = 0;
        }
        freeze f = GetComponent<freeze>();
        if (f != null)
        {
            f.nextCast1 = 0;
            f.nextCast2 = 0;
            f.nextCast3 = 0;
        }
        XMark x = GetComponent<XMark>();
        if (x != null)
        {
            x.nextCast1 = 0;
            x.nextCast2 = 0;
            x.nextCast3 = 0;
        }
        evolve e = GetComponent<evolve>();
        if (e != null)
        {
            e.nextCast1 = 0;
            e.nextCast2 = 0;
            e.nextCast3 = 0;
        }
        teleport t = GetComponent<teleport>();
        if (t != null)
        {
            t.nextCast1 = 0;
            t.nextCast2 = 0;
            t.nextCast3 = 0;
        }
        fireWall fw = GetComponent<fireWall>();
        if (fw != null)
        {
            fw.nextCast1 = 0;
            fw.nextCast2 = 0;
            fw.nextCast3 = 0;
        }
    }

    void checkHealth()
    {
        HPStrip.value = health;
        if (health == 0)
        {  
            TextContent.text = "You Win!";
            
            if (level == -1)
            {
                Button.text = "Rematch";
                Time.timeScale = 0;
            }
            else if (level == 0)
            {
                Button.text = "Move On";
                Button.color = Color.grey;
                TextContent.color = Color.grey;
                flowchart.ExecuteBlock("2");
                GlobalControl.Instance.level = 1;
            }
            else if (level == 1)
            {
                Button.text = "Move On";
                flowchart.ExecuteBlock("4");
                GlobalControl.Instance.level = 2;
            }
            else if (level == 2)
            {
                Button.text = "Move On";
                flowchart.ExecuteBlock("6");
                GlobalControl.Instance.level = 3;
            }
            else if (level == 3)
            {
                Button.text = "Move On";
                flowchart.ExecuteBlock("4");
                GlobalControl.Instance.level = 2;
            }
            else if (level == 4)
            {
                Button2.text = "Move On";
                flowchart.ExecuteBlock("12");
                GlobalControl.Instance.level = -1;
            }
        }
    }

    void checkMana()
    {
        ManaStrip.value = mana;
    }
}
