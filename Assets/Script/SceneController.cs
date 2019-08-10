using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private int leftready;
    private int rightready;
    private int mapready;
    public bool allowed;
    // private int P1character;
    // private int P2character;
    // Start is called before the first frame update
    void Start()
    {
        leftready = 0;
        rightready = 0;
        mapready = 0;
    }
    // Story Mode
    public void storystart()
    {
        SceneManager.LoadScene("storyselection");
        GlobalControl.Instance.level = 0;
    }

    public void storyselect()
    {
        SceneManager.LoadScene("storyselection");
    }

    public void storyselect0()
    {
        GlobalControl.Instance.leftPlayer = 0;
        SceneManager.LoadScene("story");
    }

    public void storyselect1()
    {
        GlobalControl.Instance.leftPlayer = 1;
        SceneManager.LoadScene("story");
    }

    public void storyselect2()
    {
        GlobalControl.Instance.leftPlayer = 2;
        SceneManager.LoadScene("story");
    }

    public void storyselect3()
    {
        GlobalControl.Instance.leftPlayer = 3;
        SceneManager.LoadScene("story");
    }
    // PVE Mode
    public void pveselect0()
    {
        leftready = 1;
        GlobalControl.Instance.leftPlayer = 0;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void pveselect1()
    {
        leftready = 1;
        GlobalControl.Instance.leftPlayer = 1;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void pveselect2()
    {
        leftready = 1;
        GlobalControl.Instance.leftPlayer = 2;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void pveselect3()
    {
        leftready = 1;
        GlobalControl.Instance.leftPlayer = 3;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void aiselect0()
    {
        rightready = 1;
        GlobalControl.Instance.rightPlayer = 0;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void aiselect1()
    {
        rightready = 1;
        GlobalControl.Instance.rightPlayer = 1;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void aiselect2()
    {
        rightready = 1;
        GlobalControl.Instance.rightPlayer = 2;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void aiselect3()
    {
        rightready = 1;
        GlobalControl.Instance.rightPlayer = 3;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }


    // PVP Mode
    public void pvpselect()
    {
        SceneManager.LoadScene("PVP");
    }

    public void p1select0(){
        leftready = 1;
        GlobalControl.Instance.leftPlayer = 0;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }
    }

    public void p1select1()
    {
        leftready = 1;
        GlobalControl.Instance.leftPlayer = 1;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }
    }

    public void p1select2()
    {
        leftready = 1;
        GlobalControl.Instance.leftPlayer = 2;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }
    }

    public void p1select3()
    {
        leftready = 1;
        GlobalControl.Instance.leftPlayer = 3;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }
    }

    public void p2select0()
    {
        rightready = 1;
        GlobalControl.Instance.rightPlayer = 0;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }

    }

    public void p2select1()
    {
        rightready = 1;
        GlobalControl.Instance.rightPlayer = 1;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }

    }

    public void p2select2()
    {
        rightready = 1;
        GlobalControl.Instance.rightPlayer = 2;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }
    }

    public void p2select3()
    {
        rightready = 1;
        GlobalControl.Instance.rightPlayer = 3;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }
    }

    public void pvpmap0()
    {
        mapready = 1;
        GlobalControl.Instance.map = 0;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }
    }

    public void pvpmap1()
    {
        mapready = 1;
        GlobalControl.Instance.map = 1;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }
    }

    public void pvpmap2()
    {
        mapready = 1;
        GlobalControl.Instance.map = 2;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }
    }

    public void pvpmap3()
    {
        mapready = 1;
        GlobalControl.Instance.map = 3;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVP");
        }
    }

    public void pvemap0()
    {
        mapready = 1;
        GlobalControl.Instance.map = 0;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void pvemap1()
    {
        mapready = 1;
        GlobalControl.Instance.map = 1;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void pvemap2()
    {
        mapready = 1;
        GlobalControl.Instance.map = 2;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void pvemap3()
    {
        mapready = 1;
        GlobalControl.Instance.map = 3;
        if (leftready == 1 && rightready == 1 && mapready == 1)
        {
            SceneManager.LoadScene("PVE");
        }
    }

    public void PVE()
    {
        SceneManager.LoadScene("pveselection");
    }

    public void PVP()
    {
        SceneManager.LoadScene("pvpSelection");
    }

    public void Title()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
