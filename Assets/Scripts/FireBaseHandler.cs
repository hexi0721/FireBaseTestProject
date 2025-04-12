using UnityEngine;
using UnityEngine.UI;

public class FireBaseHandler : MonoBehaviour
{

    [Header("���U����")]
    [SerializeField] InputField email; 
    [SerializeField] InputField password;
    [SerializeField] InputField checkPassword;
    [SerializeField] InputField userName;
    [SerializeField] Button registerButton , �w�g�����U�b��;


    [Header("�n�J����")]

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

        �w�g�����U�b��.onClick.AddListener(() =>
        {
            RegisterPage.gameObject.SetActive(false);
            LoginPage.gameObject.SetActive(true);
        });

    }


}
