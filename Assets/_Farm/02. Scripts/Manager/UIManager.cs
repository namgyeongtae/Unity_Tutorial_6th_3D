using UnityEngine;

public class UIManager : SingletonCore<UIManager>
{
    [SerializeField] private GameObject[] popUps;
    [SerializeField] private GameObject inventoryUI;

    public void InventoryOnOff()
    {
        bool isActive = inventoryUI.activeSelf;
        inventoryUI.SetActive(!isActive);
    }

    public void AllPopupClose()
    {
        foreach (var popup in popUps)
        {
            popup.SetActive(false);
        }
    }
}
