using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StoryDecider : MonoBehaviour
{
    private int level;
    public GameObject background;
    public GameObject ball;
    public AudioClip[] FuChuAudio;
    public Flowchart flowchart;

    void Start()
    {
        level = GlobalControl.Instance.level;
        Object[] sprites;
        sprites = Resources.LoadAll<Sprite>("balls");

        if (level == 1)
        {
            System.Type map4 = System.Type.GetType("Map4");
            GameObject BH1 = GameObject.Find("BH1");
            BH1.AddComponent(map4);

            SpriteRenderer sr = background.transform.GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("Space");

            SpriteRenderer bl = ball.transform.GetComponent<SpriteRenderer>();
            bl.sprite = (Sprite)sprites[1];


            this.GetComponent<AudioSource>().clip = FuChuAudio[0];
            this.GetComponent<AudioSource>().Play();

            flowchart.ExecuteBlock("3");
        }
        // wave
        if (level == 3)
        {
            System.Type map2 = System.Type.GetType("Map2");
            GameObject Wave1 = GameObject.Find("Wave1");
            Wave1.AddComponent(map2);

            SpriteRenderer sr = background.transform.GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("Denison");

            SpriteRenderer bl = ball.transform.GetComponent<SpriteRenderer>();
            bl.sprite = (Sprite)sprites[4];

            this.GetComponent<AudioSource>().clip = FuChuAudio[1];
            this.GetComponent<AudioSource>().Play();

            flowchart.ExecuteBlock("7");
        }
        // cave
        if (level == 0)
        {
            System.Type map1 = System.Type.GetType("Map1");
            GameObject wall = GameObject.Find("wall");
            wall.AddComponent(map1);

            SpriteRenderer sr = background.transform.GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("doodle2");

            SpriteRenderer bl = ball.transform.GetComponent<SpriteRenderer>();
            bl.sprite = Resources.Load<Sprite>("fire");

            this.GetComponent<AudioSource>().clip = FuChuAudio[2];
            this.GetComponent<AudioSource>().Play();

            flowchart.ExecuteBlock("1");
        }
        // olin
        if (level == 2)
        {
            System.Type map3 = System.Type.GetType("Map3");
            GameObject portal = GameObject.Find("portal");
            portal.AddComponent(map3);

            SpriteRenderer sr = background.transform.GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("factory");

            SpriteRenderer bl = ball.transform.GetComponent<SpriteRenderer>();
            bl.sprite = (Sprite)sprites[2];

            this.GetComponent<AudioSource>().clip = FuChuAudio[3];
            this.GetComponent<AudioSource>().Play();

            flowchart.ExecuteBlock("5");
        }

        if (level == 4)
        {

            SpriteRenderer sr = background.transform.GetComponent<SpriteRenderer>();
            sr.sprite = Resources.Load<Sprite>("universe");

            SpriteRenderer bl = ball.transform.GetComponent<SpriteRenderer>();
            bl.sprite = Resources.Load<Sprite>("fire");


            flowchart.ExecuteBlock("8");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
