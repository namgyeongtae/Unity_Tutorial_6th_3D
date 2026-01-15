using UnityEngine;

public class Fruit : MonoBehaviour, ITriggerEvent
{
    public void InteractionEnter()
    {
        Debug.Log(gameObject.name + "을 획득했습니다.");
        Destroy(gameObject);
    }

    public void InteractionExit() { }
}