using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_right : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    public float baseSpeed;
    public float characterSpeed = 400f;
    private int character;
    public int mana;
    public Slider ManaStrip;
    public int health;
    public Slider HPStrip;
    public Text TextContent;
    public Text Button;
    /* character:
     * 0 - Desmond
     * 1 - Zack
     * 2 - Noah
     */

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ManaStrip.value = ManaStrip.maxValue = mana;
        HPStrip.value = HPStrip.maxValue = health;

        character = GlobalControl.Instance.rightPlayer;
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
        if(character == 2)
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

        baseSpeed = characterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = baseSpeed;
        move();
        checkHealth();
        checkMana();
    }

    // Code for basic character movement
    void move()
    {
        float deltaX = Input.GetAxis("P2Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("P2Vertical") * speed * Time.deltaTime;
        Vector2 velocity = new Vector2(deltaX, deltaY);
        rb.velocity = velocity;
    }

    public void reset_player_right()
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

    public void changeSpeed(float New)
    {
        baseSpeed = New;
    }

    void checkHealth()
    {
        HPStrip.value = health;
        if (health == 0)
        {
            Time.timeScale = 0;
            TextContent.text = "P1 WINS";
            Button.text = "Return to Title Screen";
        }
    }

    void checkMana()
    {
        ManaStrip.value = mana;
    }
}
