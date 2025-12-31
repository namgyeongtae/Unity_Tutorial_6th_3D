using UnityEngine;

public class SoundClass : MonoBehaviour
{
    public TimerDelegate timer;

    void Awake()
    {
        timer.onTimerStart += StartSound;
        timer.onTimerStop += StopSound;
        timer.onTimerEnd += BombSound;
    }

    public void StartSound()
    {
        
    }
    
    public void StopSound()
    {
        
    }
    
    public void BombSound()
    {
        
    }
}