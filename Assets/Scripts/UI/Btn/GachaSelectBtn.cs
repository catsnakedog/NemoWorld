
using UnityEngine.EventSystems;

public class GachaSelectBtn : EventTriggerEX
{
    void Start()
    {
        init();

        GachaManager.PageMove += SetPage;
    }

    protected override void OnPointerDown(PointerEventData data)
    {
        MainController.main.sound.Play("buttonSFX");

        if (name.Equals("Left"))
            GachaManager.page--;
        else if (name.Equals("Right"))
            GachaManager.page++;

        GachaManager.PageMove(gameObject.name);
    }

    public void SetPage(string name)
    {
        if (GachaManager.page == 1 && gameObject.name.Equals("Left"))
        {
            gameObject.SetActive(false);
            return;
        }
        else if (GachaManager.page == 3 && gameObject.name.Equals("Right"))
        {
            gameObject.SetActive(false);
            return;
        }
        else
            gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GachaManager.PageMove -= SetPage;
    }
}
