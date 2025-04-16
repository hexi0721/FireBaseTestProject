using UnityEngine;
using UnityEngine.UIElements;

public class LoginUIController : MonoBehaviour
{

    VisualElement rootVisualElement;
    FireBaseManager fireBaseManager;
    public void Setup(FireBaseManager fireBaseManager)
    {
        this.fireBaseManager = fireBaseManager;
    }

    private void Awake()
    {
        rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
    }

    private void Start()
    {

        
        var loginEmailField = rootVisualElement.Q<TextField>("LoginEmail");
        var loginPasswordField = rootVisualElement.Q<TextField>("LoginPassword");


        
        var loginButton = rootVisualElement.Q<Button>("LoginButton");
        loginButton.RegisterCallback<ClickEvent>(e =>
        {
            
            string loginEmail = loginEmailField.value;
            string loginPassword = loginPasswordField.value;

            fireBaseManager.Login(loginEmail, loginPassword);
        });

        
    }




}