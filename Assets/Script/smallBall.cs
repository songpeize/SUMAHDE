using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallBall : MonoBehaviour
{
    float speed;
    int who;
    public AudioSource audioSource;
    public AudioClip collisionSoundClip1;
    public AudioClip collisionSoundClip2;
    private Rigidbody2D _body;
    int z;

    // Start is called before the first frame update
    void Start()
    {
        speed = 25;
        if (GlobalControl.Instance.level == 4)
        {
            speed = 40;
        }
        _body = GetComponent<Rigidbody2D>();
        who = Random.Range(0, 2);
        if (who == 0)
            transform.position = new Vector3(-13, 0, 0);
        else
            transform.position = new Vector3(13, 0, 0);

        GameObject cball = GameObject.Find("Ball(Clone)");
        GameObject ball = GameObject.Find("Ball");
        if(cball != null && ball != null)
            cball.transform.position = ball.transform.position;

        z = 0;
    }


    // Update is called once per frame
    void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if(_body.velocity.x > 0)
        {
            sr.flipY = true;
        }
        else
        {
            sr.flipY = false;
        }

        if(speed > 18)
        {
            speed -= 0.1f;
            _body.velocity = new Vector2(_body.velocity.x / (speed + 0.1f) * speed, _body.velocity.y / (speed + 0.1f) * speed);
        }
        /*
        GameObject zoom1 = GameObject.Find("zoom1");
        GameObject zoom2 = GameObject.Find("zoom2");
        if ((_body.transform.position.x < zoom1.transform.position.x - 3 || _body.transform.position.x > zoom1.transform.position.x + 3 || _body.transform.position.y > zoom1.transform.position.y + 3 || _body.transform.position.y < zoom1.transform.position.y - 3)
            && (_body.transform.position.x < zoom2.transform.position.x - 3 || _body.transform.position.x > zoom2.transform.position.x + 3 || _body.transform.position.y > zoom2.transform.position.y + 3 || _body.transform.position.y < zoom2.transform.position.y - 3))
        {
            if (z == 1)
            {
                print("get here");
                _body.velocity = _body.velocity * 10;
                z = 0;
            }
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D clone;
        if (other.tag == "LeftDoor")
        {
            GameObject player_left = GameObject.Find("play1");
            player_left pl = player_left.GetComponent<player_left>();
            if(pl)
                pl.health -= 1;
            GameObject ball = GameObject.Find("Ball");
            Rigidbody2D body = ball.GetComponent<Rigidbody2D>();
            body.velocity = new Vector2(0, 0);
            who = Random.Range(0, 2);
            if (who == 0)
            {
                body.transform.position = new Vector3(13, 0, 0);
                GameObject cball = GameObject.Find("Ball(Clone)");
                if(cball != null)
                    Destroy(cball);
                GameObject portal = GameObject.Find("portal");
                Map3 m3 = portal.GetComponent<Map3>();
                if (m3 != null)
                {
                    Map3 p = portal.GetComponent<Map3>();
                    p.timer1 = 1.0f;
                }
            }
            else
            {
                body.transform.position = new Vector3(-13, 0, 0);
                GameObject cball = GameObject.Find("Ball(Clone)");
                if (cball != null)
                    Destroy(cball);
                GameObject portal = GameObject.Find("portal");
                Map3 m3 = portal.GetComponent<Map3>();
                if (m3 != null)
                {
                    Map3 p = portal.GetComponent<Map3>();
                    p.timer1 = 1.0f;
                }
            }
            resetplayer();
        }

        if (other.tag == "RightDoor")
        {
            GameObject player_right = GameObject.Find("play2");
            player_right pr = player_right.GetComponent<player_right>();
            AI_1 pa = player_right.GetComponent<AI_1>();
            if (pr)
                pr.health -= 1;
            if (pa)
                pa.health -= 1;
            GameObject ball = GameObject.Find("Ball");
            Rigidbody2D body = ball.GetComponent<Rigidbody2D>();
            body.velocity = new Vector2(0, 0);
            who = Random.Range(0, 2);
            if (who == 0)
            {
                body.transform.position = new Vector3(13, 0, 0);
                GameObject cball = GameObject.Find("Ball(Clone)");
                Destroy(cball);
                GameObject portal = GameObject.Find("portal");
                Map3 m3 = portal.GetComponent<Map3>();
                if (m3 != null)
                {
                    Map3 p = portal.GetComponent<Map3>();
                    p.timer1 = 1.0f;
                }
            }
            else
            {
                body.transform.position = new Vector3(-13, 0, 0);
                GameObject cball = GameObject.Find("Ball(Clone)");
                Destroy(cball);
                GameObject portal = GameObject.Find("portal");
                Map3 m3 = portal.GetComponent<Map3>();
                if (m3 != null)
                {
                    Map3 p = portal.GetComponent<Map3>();
                    p.timer1 = 1.0f;
                }
            }
            resetplayer();
        }

        // if the ball touches the boarder
        if (other.tag == "Left")
        {
            transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, 0);
            _body.velocity = new Vector2(_body.velocity.x * -1, _body.velocity.y);
        }
        if (other.tag == "Right")
        {
            transform.position = new Vector3(transform.position.x - 0.4f, transform.position.y, 0);
            _body.velocity = new Vector2(_body.velocity.x * -1, _body.velocity.y);
        }
        if (other.tag == "Top")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, 0);
            _body.velocity = new Vector2(_body.velocity.x, _body.velocity.y * -1);
        }
        if (other.tag == "Bottom")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, 0);
            _body.velocity = new Vector2(_body.velocity.x, _body.velocity.y * -1);
        }
        if (other.tag == "portal")
        {
            float y = Random.Range(-10, 10);
            clone = Instantiate(_body, _body.transform.position, _body.transform.rotation);
            clone.velocity = new Vector2(_body.velocity.x, _body.velocity.y + y);
        }
        if (other.tag == "bh2")
        {
            GameObject bh1 = GameObject.Find("BH1");
            if (_body.velocity.x > 0)
                transform.position = new Vector3(bh1.transform.position.x + 1.5f, bh1.transform.position.y, bh1.transform.position.z);
            else
                transform.position = new Vector3(bh1.transform.position.x - 1.5f, bh1.transform.position.y, bh1.transform.position.z);
        }
        if(other.tag == "bh1")
        {
            GameObject bh2 = GameObject.Find("BH2");
            if (_body.velocity.x > 0)
                transform.position = new Vector3(bh2.transform.position.x + 1.5f, bh2.transform.position.y, bh2.transform.position.z);
            else
                transform.position = new Vector3(bh2.transform.position.x - 1.5f, bh2.transform.position.y, bh2.transform.position.z);
        }
        if (other.tag == "zoom")
        {
            print(_body.velocity);
            _body.velocity /= 10;
            print(_body.velocity);
            z = 1;
        }

        // if the ball touches players
        player_left player_l = other.GetComponent<player_left>();
        if(player_l != null)
        {
            Rigidbody2D player_l_rb = player_l.GetComponent<Rigidbody2D>();
            touchPlayer(player_l_rb);
        }

        player_right player_r = other.GetComponent<player_right>();
        if (player_r != null)
        {
            Rigidbody2D player_r_rb = player_r.GetComponent<Rigidbody2D>();
            touchPlayer(player_r_rb);
        }

        AI_1 ai = other.GetComponent<AI_1>();
        if(ai != null)
        {
            touchPlayer(ai._body);
        }
    }

    void resetplayer()
    {
        GameObject player1 = GameObject.Find("play1");
        player_left pl = player1.GetComponent<player_left>();
        GameObject player2 = GameObject.Find("play2");
        player_right pr = player2.GetComponent<player_right>();

        if(pl != null)
            pl.reset_player_left();
        if(pr != null)
            pr.reset_player_right();

        AI_1 ai = player2.GetComponent<AI_1>();
        if (ai != null)
            ai.reset_AI();

        GameObject rd = GameObject.Find("RightDoor");
        rd.transform.position = new Vector3(18.3f, 0, 0);
        GameObject ld = GameObject.Find("LeftDoor");
        ld.transform.position = new Vector3(-18.3f, 0, 0);
        GameObject wall = GameObject.Find("wall");
        wall.transform.position = new Vector3(0, 15, 0);
    }

    void touchPlayer(Rigidbody2D rb)
    {
        if (transform.position.x < 0)
        {
            int deg = Random.Range(-65, 65);
            float rad = deg * Mathf.Deg2Rad;

            speed += 7;

            float Vx = speed * Mathf.Cos(rad);
            float Vy = speed * -Mathf.Sin(rad);

            _body.velocity = new Vector2(Vx, Vy);
        }
        if (transform.position.x > 0)
        {
            int deg = Random.Range(-65, 65);
            float rad = deg * Mathf.Deg2Rad;

            speed += 7;

            float Vx = speed * Mathf.Cos(rad);
            float Vy = speed * -Mathf.Sin(rad);

            _body.velocity = new Vector2(-Vx, Vy);
        }
    }
}
