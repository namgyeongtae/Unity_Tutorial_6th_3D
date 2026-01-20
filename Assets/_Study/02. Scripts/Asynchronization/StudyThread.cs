using System.Threading;
using UnityEngine;

public class StudyThread : MonoBehaviour
{
    private AClass a;
    private BClass b;

    void Awake()
    {
        a = gameObject.AddComponent<AClass>();
        b = gameObject.AddComponent<BClass>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Thread t = new Thread(SubThread);
        t.IsBackground = true;

        t.Start();

        t.Join();
        Debug.Log("Main Thread 종료");
    }

    private void SubThread()
    {
        Debug.Log("Sub Thread 시작");
        Thread.Sleep(2000);

        Debug.Log("Sub Thread 완료");
    }
}
