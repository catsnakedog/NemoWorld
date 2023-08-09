using UnityEngine;
using UnityEngine.EventSystems;

public class StoryBookPageBtn : EventTriggerEX
{
    [SerializeField] private int num;
    [SerializeField] private bool check;

    public static int page;
    
    protected void Start()
    {
        init();

        if(num == 1)
        {
            check = true;
        }
        else if (DataManager.Single.Data.inGameData.storyClearList.Contains("stage" + (num - 1).ToString()))
        {
            transform.GetChild(1).gameObject.SetActive(false);
            check = true;
        }
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        if (check)
        {
            MainController.main.UI.UIsetting(Define.UIlevel.Level2, Define.UItype.StoryBookPage);
            page = num;
        }
    }
}
