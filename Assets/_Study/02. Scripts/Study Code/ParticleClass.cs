using UnityEngine;

public class ParticleClass : MonoBehaviour
{
    public TimerDelegate timer;
    
    public ParticleSystem ps;

    public void Play()
    {
        
    }
    
    void Awake()
    {
        timer.onTimerEnd += Explosion;
    }
    
    public void Explosion()
    {
        ps.Play();
    }
}