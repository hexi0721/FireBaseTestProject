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
            Debug.Log("註冊成功 使用者：" + userCredential.User.Email);
        }
        catch (FirebaseException e)
        {
            Debug.LogError("註冊失敗：" + e.Message);
        }
    }

    public async void Login(string email, string password)
    {
        try
        {
            var userCredential = await auth.SignInWithEmailAndPasswordAsync(email, password);
            Debug.Log("登入成功！使用者：" + userCredential.User.Email);
        }
        catch (FirebaseException e)
        {
            Debug.LogError("登入失敗：" + e.Message);
        }
    }

    public void GetCurrentUser()
    {
        var user = auth.CurrentUser;
        if (user != null)
        {
            Debug.Log("當前登入使用者：" + user.Email);
        }
        else
        {
            Debug.Log("沒有使用者登入");
        }
    }

    public void SignOut()
    {
        auth.SignOut();
        Debug.Log("已登出");
    }
}