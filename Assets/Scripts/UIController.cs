using UnityEngine;
using UnityEngine.UIElements;

public class LoginUIController : MonoBehaviour
{
    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var emailField = root.Q<TextField>("ReginsterEmail");
        /* 
        var loginButton = root.Q<Button>("LoginButton");

        loginButton.clicked += () =>
        {
            Debug.Log("µn¤J Email: " + emailField.text);
        };
        */
    }
}