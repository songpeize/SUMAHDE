using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;

public class StroyController : MonoBehaviour
{
    private int level;
    public Button[] buttonList;
    public Image[] imageList;
    public Image map;
    public Text mapName;
    public Sprite[] spriteList;
    public Sprite blank;
    public Flowchart flowchart;

    void Start()
    {
        level = GlobalControl.Instance.level;
        if (level == 0)
        {
            buttonList[0].enabled = false;
            buttonList[2].enabled = false;
            buttonList[3].enabled = false;

            imageList[0].sprite = blank;
            imageList[2].sprite = blank;
            imageList[3].sprite = blank;

            flowchart.ExecuteBlock("2");
        }

        else if (level == 1)
        {
            buttonList[2].enabled = false;
            buttonList[3].enabled = false;

            imageList[2].sprite = blank;
            imageList[3].sprite = blank;

            flowchart.ExecuteBlock("2");
        }

        else if (level == 2)
        {
            buttonList[3].enabled = false;

            imageList[3].sprite = blank;

            flowchart.ExecuteBlock("2");
        }

        else if (level == 3)
        {
            buttonList[0].enabled = false;

            imageList[0].sprite = blank;

            flowchart.ExecuteBlock("2");
        }

        else if (level == 4)
        {
            buttonList[0].enabled = false;
            buttonList[1].enabled = false;
            buttonList[2].enabled = false;
            buttonList[3].enabled = false;

            imageList[0].sprite = blank;
            imageList[1].sprite = blank;
            imageList[2].sprite = blank;
            imageList[3].sprite = blank;

            flowchart.ExecuteBlock("1");
        }

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
