using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;

public class FireBaseManager : MonoBehaviour
{
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;

    private async void Awake()
    {
        var dependencyResult = await FirebaseApp.CheckAndFixDependenciesAsync();

        if (dependencyResult == DependencyStatus.Available)
        {
            
            auth = FirebaseAuth.DefaultInstance;
            Debug.Log("Firebase initialized!");
        }
        else
        {
            Debug.LogError("Firebase initialization failed");
        }
    }


    public async void Register(string email, string password , string checkPassword , string userName)
    {
        try
        {
            var userCredential = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
            Debug.Log("���U���\ �ϥΪ̡G" + userCredential.User.Email);
        }
        catch (FirebaseException e)
        {
            Debug.LogError("���U���ѡG" + e.Message);
        }
    }

    public async void Login(string email, string password)
    {
        try
        {
            var userCredential = await auth.SignInWithEmailAndPasswordAsync(email, password);
            Debug.Log("�n�J���\�I�ϥΪ̡G" + userCredential.User.Email);
        }
        catch (FirebaseException e)
        {
            Debug.LogError("�n�J���ѡG" + e.Message);
        }
    }

    public void GetCurrentUser()
    {
        var user = auth.CurrentUser;
        if (user != null)
        {
            Debug.Log("��e�n�J�ϥΪ̡G" + user.Email);
        }
        else
        {
            Debug.Log("�S���ϥΪ̵n�J");
        }
    }

    public void SignOut()
    {
        auth.SignOut();
        Debug.Log("�w�n�X");
    }
}