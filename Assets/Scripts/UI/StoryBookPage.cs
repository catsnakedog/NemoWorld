using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoryBookPage : EventTriggerEX
{
    protected void Start()
    {
        init();

        GameObject image = GameObject.Find("DefaultImage");
        GameObject next = GameObject.Find("Next");
        StringBuilder sb = new StringBuilder("CutToon"+StoryBookPageBtn.page.ToString());
        
        if (StoryBookPageBtn.page != 1)
        {
            image.SetActive(false);
            next.SetActive(false);

            GetComponent<Image>().sprite = MainController.main.resource.sprite[sb.ToString()];
        }
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        Destroy(GameObject.FindWithTag("Level2").transform.GetChild(0).gameObject);
    }
}
