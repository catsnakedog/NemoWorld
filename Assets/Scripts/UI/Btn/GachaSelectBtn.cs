using UnityEngine.EventSystems;

public class GachaSelectBtn : EventTriggerEX
{
    void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        if (name.Equals("Left"))
            GachaManager.page--;
        else if (name.Equals("Right"))
            GachaManager.page++;

        GachaManager.PageMove();
    }
}
