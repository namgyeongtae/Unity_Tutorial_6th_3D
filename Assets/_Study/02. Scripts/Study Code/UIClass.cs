using UnityEngine;

public class UIClass : MonoBehaviour
{
    public TimerDelegate timer;
    
    public GameObject startUI;
    public GameObject stopUI;
    public GameObject endUI;

    void Awake()
    {
        timer.onTimerStart += StartUI;
        timer.onTimerStop += StopUI;
        timer.onTimerEnd += EndUI;
    }
    
    public void StartUI()
    {
        
    }
    
    public void StopUI()
    {
        
    }
    
    public void EndUI()
    {
        
    }
}