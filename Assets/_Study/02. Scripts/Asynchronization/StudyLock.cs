using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class StudyLock : MonoBehaviour
{
    private readonly object obj = new object();

    async void Start()
    {
        Debug.Log("Test 시작");

        Task t1 = Task.Run(() => SubThread("T1"));
        Task t2 = Task.Run(() => SubThread("T2"));

        await Task.WhenAll(t1, t2);

        Debug.Log("Main Thread 종료");
    }

    private void SubThread(string msg)
    {
        Debug.Log($"{msg} 스레드 시작");
        Thread.Sleep(500);

        Debug.Log($"{msg} 스레드 진행 중");
        Thread.Sleep(500);

        Debug.Log($"{msg} 스레드 종료");
    }
}
