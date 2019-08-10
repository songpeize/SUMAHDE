using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class player_left : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    public float baseSpeed;
    public float characterSpeed = 500f;
    private int character;
    public int mana;
    public Slider ManaStrip;
    public int health;
    public Slider HPStrip;
    public Text TextContent;
    public Flowchart flowchart;
    public Text Button;
    public Text Button2;
    private int skin;
    private int level;

    // Start is called before the first frame update
    void Start()
    {
        level = GlobalControl.Instance.level;
        if (level == 3)
        {
            mana = 0;
            characterSpeed = 100f;
            health = 3;
        }
        else if (level == 4)
        {
            health = 1;
            characterSpeed = 800f;
        }
        
        skin = 0;
        rb = GetComponent<Rigidbody2D>();
               
        Button.text = "";

        character = GlobalControl.Instance.leftPlayer;
        if(character == 0)
        {
            System.Type skill1 = System.Type.GetType("sizeShrink");
            gameObject.AddComponent(skill1);
            System.Type skill2 = System.Type.GetType("doorMove");
            gameObject.AddComponent(skill2);

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("Desmond");
            sr.flipX = true;
        }
        if(character == 1)
        {
            System.Type skill3 = System.Type.GetType("freeze");
            gameObject.AddComponent(skill3);
            System.Type skill4 = System.Type.GetType("block");
            gameObject.AddComponent(skill4);

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("Zack");
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
            sr.flipX = true;
        }
        if(character == 3)
        {
            System.Type skill7 = System.Type.GetType("evolve");
            gameObject.AddComponent(skill7);
            System.Type skill8 = System.Type.GetType("fireWall");
            gameObject.AddComponent(skill8);

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            Object[] sprites;
            sprites = Resources.LoadAll<Sprite>("Every");
            sr.sprite = (Sprite)sprites[0];
        }

        if (level == 3)
        {
            mana = 0;
            characterSpeed = 100f;
            health = 1;
        }
        else if (level == 4)
        {
            health = 1;
            characterSpeed = 800f;
        }
        baseSpeed = characterSpeed;
        ManaStrip.value = ManaStrip.maxValue = mana;
        HPStrip.value = HPStrip.maxValue = health;
    }

    public void characterswitch()
    {
        if (character == 1)
        {
            System.Type skill3 = System.Type.GetType("freeze");
            gameObject.AddComponent(skill3);
            System.Type skill4 = System.Type.GetType("block");
            gameObject.AddComponent(skill4);

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("Zack");
        }
        if (character == 2)
        {
            System.Type skill5 = System.Type.GetType("teleport");
            gameObject.AddComponent(skill5);
            System.Type skill6 = System.Type.GetType("XMark");
            gameObject.AddComponent(skill6);

            mana = 10;
            ManaStrip.value = ManaStrip.maxValue = mana;

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            Object[] sprites;
            sprites = Resources.LoadAll<Sprite>("Every");
            sr.sprite = (Sprite)sprites[1];
            sr.flipX = true;
        }
        if (character == 3)
        {
            System.Type skill7 = System.Type.GetType("evolve");
            gameObject.AddComponent(skill7);
            System.Type skill8 = System.Type.GetType("fireWall");
            gameObject.AddComponent(skill8);

            mana = 15;
            ManaStrip.value = ManaStrip.maxValue = mana;

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            Object[] sprites;
            sprites = Resources.LoadAll<Sprite>("Every");
            sr.sprite = (Sprite)sprites[0];
            sr.flipX = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (flowchart.HasExecutingBlocks())
        {
            speed = 0f;
        }
        else
        {
            speed = baseSpeed;
        }
        move();
        checkHealth();
        checkMana();
    }

    // Code for basic character movement
    void move()
    {
        float deltaX = Input.GetAxis("P1Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("P1Vertical") * speed * Time.deltaTime;
        Vector2 velocity = new Vector2(deltaX, deltaY);
        rb.velocity = velocity;
    }

    public void reset_player_left()
    {
        transform.position = new Vector3(-15, 0, 0);
        transform.localScale = new Vector2(0.2f, 0.2f);
        mana = (int)ManaStrip.maxValue;

        sizeShrink ss = GetComponent<sizeShrink>();
        if(ss != null)
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

    public void changeSpeed(float New)
    {
        baseSpeed = New;
    }

    void checkHealth()
    {
        HPStrip.value = health;
        if (health == 0){
            
            if (level == -1)
            {
                Time.timeScale = 0;
                TextContent.text = "P2 WINS";
                Button.text = "Return to Title Screen";
            }
            else if (level == 3)
            {
                TextContent.text = "Game Over";
                Button.text = "Give Up";
                Button2.text = "Never Give Up";
                TextContent.color = Color.black;
                Button.color = Color.black;
                Button2.color = Color.black;

                flowchart.ExecuteBlock("defeat");

                GlobalControl.Instance.level = 4;
            }
            else if (level == 4)
            {
                health = 1;
                if (skin == 0)
                {
                    character = 2;
                    characterswitch();
                    flowchart.ExecuteBlock("9");
                    skin = 1;
                }
                else if (skin == 1)
                {
                    character = 3;
                    characterswitch();
                    flowchart.ExecuteBlock("10");
                    skin = 2;

                }
                else if (skin == 2)
                {
                    character = 1;
                    characterswitch();
                    flowchart.ExecuteBlock("11");
                    skin = 0;
                }

            }
            else if( level == 0)
            {
                Time.timeScale = 0;          
                TextContent.text = "Game Over";
                Button.text = "Return to Title Screen";
                Button2.text = "Retry";
                TextContent.color = Color.grey;
                Button.color = Color.grey;
                Button2.color = Color.grey;
            }
            
        }
    }

    void checkMana()
    {
        ManaStrip.value = mana;
    }
}
