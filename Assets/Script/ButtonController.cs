using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image image;
    public Sprite sprite;
    public Sprite blank;
    public Text TextContent;
    public string charname;
    private bool allowed;
    public AudioSource audioSource;

    void Start()
    {
        HideText();
        allowed = true;
    }

    public void ShowText()
    {
        TextContent.text = charname;
    }

    public void HideText()
    {
        TextContent.text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowText();
        image.sprite = sprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (allowed == true)
        {
            HideText();
            image.sprite = blank;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ShowText();
        image.sprite = sprite;
        allowed = false;
    }
}
