using UnityEngine;
using UnityEngine.UI;

public class FireBaseHandler : MonoBehaviour
{

    [Header("註冊頁面")]
    [SerializeField] InputField email; 
    [SerializeField] InputField password;
    [SerializeField] InputField checkPassword;
    [SerializeField] InputField userName;
    [SerializeField] Button registerButton , 已經有註冊帳號;


    [Header("登入頁面")]

    //[SerializeField] Button loginButton, registerButton;


    [Header("Other")]
    [SerializeField] FireBaseManager fireBaseManager;

    [SerializeField] RectTransform RegisterPage , LoginPage;


    private void Start()
    {
        /*
        loginButton.onClick.AddListener(() =>
        {


            fireBaseManager.Login(email.text , password.text);



        });*/
        registerButton.onClick.AddListener(() =>
        {

            fireBaseManager.Register(email.text, password.text , checkPassword.text , userName.text);
        });

        已經有註冊帳號.onClick.AddListener(() =>
        {
            RegisterPage.gameObject.SetActive(false);
            LoginPage.gameObject.SetActive(true);
        });

    }


}
