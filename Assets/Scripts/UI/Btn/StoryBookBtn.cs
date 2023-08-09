using UnityEngine.EventSystems;

public class StoryBookBtn : EventTriggerEX
{
    protected void Start()
    {
        init();
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");
        MainController.main.UI.UIsetting(Define.UIlevel.Level1, Define.UItype.StoryBook);
    }
}
