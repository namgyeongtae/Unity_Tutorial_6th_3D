using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Farm
{
    public class IntroManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField idInput;
        [SerializeField] private TMP_InputField passwordInput;
        [SerializeField] private Button createButton;
        [SerializeField] private Button loginButton;

        void Start()
        {
            createButton.onClick.AddListener(() => 
            {

            });

            loginButton.onClick.AddListener(() => 
            { 
                // 로그인 기능
                DataManager.Instance.UserID = idInput.text;
                
                SceneManager.LoadScene(1);
            });
        }
    }
}

