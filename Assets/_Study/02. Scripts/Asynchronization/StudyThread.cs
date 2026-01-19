using System.Threading;
using UnityEngine;

public class StudyThread : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Thread subThread = new Thread(SubThread);

        subThread.IsBackground = true;  // Unity Editor 종료 시 쓰레드 종료
        subThread.Start();

        subThread.Join(); // Thread가 완료될 때까지 대기 -> 동기

        Debug.Log("Main Thread 종료");
    }

    private void SubThread()
    {
        Debug.Log("Sub Thread 실행");
        Thread.Sleep(2000); // 2초 멈춤

        Debug.Log("Sub Thread 완료");
    }
}
