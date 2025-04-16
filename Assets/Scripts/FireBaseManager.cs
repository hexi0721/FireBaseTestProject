using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using System;

public class FireBaseManager : MonoBehaviour
{
    [SerializeField] private DependencyStatus dependencyStatus;
    private FirebaseAuth auth;
    private FirebaseUser user;

    private async void Awake()
    {
        var dependencyResult = await FirebaseApp.CheckAndFixDependenciesAsync();

        if (dependencyResult == dependencyStatus)
        {

            InitializeFirebase();


        }
        else
        {
            Debug.LogError("Firebase initialization failed");
        }
    }

    private void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        Debug.Log("Firebase initialized!");

        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this , EventArgs.Empty);
    }

    private void AuthStateChanged(object sender, EventArgs e)
    {
        if (auth.CurrentUser != user)
        {
            bool signIn = auth.CurrentUser != user && auth.CurrentUser != null;

            if (!signIn && user != null)
            {
                Debug.Log("使用者登出：" + user.UserId);
            }

            user = auth.CurrentUser;

            if (signIn)
            {
                Debug.Log("使用者登入：" + user.UserId);
            }
        }


    }

    public async void Register(string email, string password, string checkPassword, string userName)
    {
        if (password != checkPassword)
        {
            Debug.Log("註冊失敗! 密碼不一致。");
            return;
        }

        try
        {
            var userCredential = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
            user = userCredential.User;
            Debug.Log("註冊成功 使用者：" + userCredential.User.Email);

            UserProfile userProfile = new UserProfile
            {
                DisplayName = userName,
            };

            try
            {
                await user.UpdateUserProfileAsync(userProfile);

                Debug.Log("使用者名稱已更新：" + user.DisplayName);
            }
            catch (FirebaseException e)
            {
                await user.DeleteAsync();

                string errorMessage = "使用者名稱更新失敗! ";
                Debug.Log(errorMessage + e.Message);


            }



            
            
        }
        catch (FirebaseException e)
        {
            AuthError authError = (AuthError)e.ErrorCode;

            string errorMessage = "註冊失敗! ";
            switch (authError)
            {
                case AuthError.InvalidEmail:
                    errorMessage += "註冊失敗! 無效的電子郵件地址。";
                    break;
                case AuthError.EmailAlreadyInUse:
                    errorMessage += "註冊失敗! 電子郵件地址已被使用。";
                    break;
                case AuthError.MissingEmail:
                    errorMessage += "註冊失敗! 請提供正確的電子郵件地址。";
                    break;
                case AuthError.MissingPassword:
                    errorMessage += "註冊失敗! 請提供密碼。";
                    break;
                default:
                    errorMessage += "註冊失敗! " + e.Message;
                    break;
            }

            Debug.Log(errorMessage);
        }
    }


    public async void Login(string email, string password)
    {

        try
        {
            var userCredential = await auth.SignInWithEmailAndPasswordAsync(email, password);
            user = userCredential.User;
            Debug.Log("登入成功！使用者：" + user.UserId);
        }
        catch (FirebaseException e)
        {

            AuthError authError = (AuthError)e.ErrorCode;

            string errorMessage = "登入失敗! ";

            switch (authError)
            {
                case AuthError.InvalidEmail:
                    errorMessage += "無效的電子郵件地址。";
                    break;
                case AuthError.WrongPassword:
                    errorMessage += "密碼錯誤。";
                    break;
                case AuthError.MissingEmail:
                    errorMessage += "請提供正確的電子郵件地址。";
                    break;
                case AuthError.MissingPassword:
                    errorMessage += "請提供密碼。";
                    break;
                case AuthError.TooManyRequests:
                    errorMessage += "請求過多，請稍後再試。";
                    break;
                case AuthError.NetworkRequestFailed:
                    errorMessage += "網路請求失敗，請檢查您的網路連接。";
                    break;
                default:
                    errorMessage += e.Message;
                    break;
            }

            Debug.Log(errorMessage);
        }
    }

}