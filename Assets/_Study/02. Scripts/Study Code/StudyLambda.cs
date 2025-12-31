using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void MyDelegate();
    public MyDelegate myDelegate;

    public delegate void MyDelegate2(string s);
    public MyDelegate2 myDelegate2;

    public Button buttonUI;

    void Start()
    {
        #region Lambda

        myDelegate = () => Debug.Log("Hello Unity");
        myDelegate?.Invoke();

        // myDelegate += () =>
        // {
        //     Debug.Log("Hello Unity");
        //     Debug.Log("Hello C#");
        // };


        myDelegate2 = (s) => Debug.Log(s);
        myDelegate2("Hello C#");


        // myDelegate += delegate(string s)
        // {
        //     Debug.Log(s);
        // };
        //
        // myDelegate?.Invoke("Hello Unity");

        #endregion

        
        buttonUI.onClick.AddListener(ButtonEvent);
        
        buttonUI.onClick.AddListener(delegate
        {
            ButtonEvent();
            ButtonEvent2();
            ButtonEvent3();
        });

        buttonUI.onClick.AddListener(() => ButtonEvent());
    }

    public void ButtonEvent()
    {
        Debug.Log("버튼 눌림");
    }

    public void ButtonEvent2()
    {
        Debug.Log("2 버튼 눌림");
    }

    public void ButtonEvent3()
    {
        Debug.Log("3 버튼 눌림");
    }
}