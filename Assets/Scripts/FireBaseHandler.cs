using UnityEngine;
using UnityEngine.UI;

public class FireBaseHandler : MonoBehaviour
{

    [SerializeField] InputField email, password;

    [SerializeField] Button loginButton, registerButton;

    [SerializeField] FireBaseManager fireBaseManager;

    private void Start()
    {
        loginButton.onClick.AddListener(() =>
        {


            fireBaseManager.Login(email.text , password.text);



        });
        registerButton.onClick.AddListener(() =>
        {

            fireBaseManager.Register(email.text, password.text);
        });
    }


}
