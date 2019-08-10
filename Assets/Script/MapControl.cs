using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    int map;
    public GameObject background;
    public GameObject ball;
    public AudioClip[] FuChuAudio;

    // Start is called before the first frame update
    void Start()
    {
        map = GlobalControl.Instance.map;
        Object[] sprites;
        sprites = Resources.LoadAll<Sprite>("balls");
        // space
        if (map == 0)
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
        }
        // wave
        if(map == 1)
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
        }
        // cave
        if(map == 2)
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
        }
        // olin
        if(map == 3)
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
