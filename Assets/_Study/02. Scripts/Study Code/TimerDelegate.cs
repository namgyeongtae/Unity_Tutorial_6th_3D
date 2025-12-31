using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimerDelegate : MonoBehaviour
{
    public delegate void TimerStart();
    public static event TimerStart onTimerStart; // 타이머 시작 델리게이트

    public delegate void TimerStop();
    public static event TimerStop onTimerStop; // 타이머 멈춤 델리게이트
    
    public delegate void TimerEnd();
    public static event TimerEnd onTimerEnd; // 타이머 종료 델리게이트

    public KeyCode keyCode = KeyCode.Space; // 타이머 멈추는 키

    public float timer = 5f;
    public bool isTimer = true;
    
    void Awake()
    {
        onTimerStart += StartEvent;
        onTimerStop += StopEvent;
        onTimerEnd += EndEvent;
    }
    
    void Start()
    {
        onTimerStart?.Invoke(); // 타이머 시작
        
        StartCoroutine(TimerRoutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
            OnTimerStop();
    }

    IEnumerator TimerRoutine()
    {
        while (isTimer)
        {
            Debug.Log($"현재 {timer}초 남았습니다.");
            yield return new WaitForSeconds(1f);
            timer--;

            if (timer <= 0f)
            {
                isTimer = false;
                onTimerEnd?.Invoke(); // 타이머 종료
            }
        }
    }

    public void OnTimerStop() // 델리게이트를 실행하는 트리거 함수
    {
        onTimerStop?.Invoke();
    }

    private void StartEvent()
    {
        Debug.Log("폭탄이 설치되었습니다.");
    }

    private void StopEvent()
    {
        StopAllCoroutines();
        Debug.Log("폭탄이 해체되었습니다.");
    }

    private void EndEvent()
    {
        Debug.Log("폭탄이 터졌습니다.");
    }
}