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
                Debug.Log("�ϥΪ̵n�X�G" + user.UserId);
            }

            user = auth.CurrentUser;

            if (signIn)
            {
                Debug.Log("�ϥΪ̵n�J�G" + user.UserId);
            }
        }


    }

    public async void Register(string email, string password, string checkPassword, string userName)
    {
        if (password != checkPassword)
        {
            Debug.Log("���U����! �K�X���@�P�C");
            return;
        }

        try
        {
            var userCredential = await auth.CreateUserWithEmailAndPasswordAsync(email, password);
            user = userCredential.User;
            Debug.Log("���U���\ �ϥΪ̡G" + userCredential.User.Email);

            UserProfile userProfile = new UserProfile
            {
                DisplayName = userName,
            };

            try
            {
                await user.UpdateUserProfileAsync(userProfile);

                Debug.Log("�ϥΪ̦W�٤w��s�G" + user.DisplayName);
            }
            catch (FirebaseException e)
            {
                await user.DeleteAsync();

                string errorMessage = "�ϥΪ̦W�٧�s����! ";
                Debug.Log(errorMessage + e.Message);


            }



            
            
        }
        catch (FirebaseException e)
        {
            AuthError authError = (AuthError)e.ErrorCode;

            string errorMessage = "���U����! ";
            switch (authError)
            {
                case AuthError.InvalidEmail:
                    errorMessage += "���U����! �L�Ī��q�l�l��a�}�C";
                    break;
                case AuthError.EmailAlreadyInUse:
                    errorMessage += "���U����! �q�l�l��a�}�w�Q�ϥΡC";
                    break;
                case AuthError.MissingEmail:
                    errorMessage += "���U����! �д��ѥ��T���q�l�l��a�}�C";
                    break;
                case AuthError.MissingPassword:
                    errorMessage += "���U����! �д��ѱK�X�C";
                    break;
                default:
                    errorMessage += "���U����! " + e.Message;
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
            Debug.Log("�n�J���\�I�ϥΪ̡G" + user.UserId);
        }
        catch (FirebaseException e)
        {

            AuthError authError = (AuthError)e.ErrorCode;

            string errorMessage = "�n�J����! ";

            switch (authError)
            {
                case AuthError.InvalidEmail:
                    errorMessage += "�L�Ī��q�l�l��a�}�C";
                    break;
                case AuthError.WrongPassword:
                    errorMessage += "�K�X���~�C";
                    break;
                case AuthError.MissingEmail:
                    errorMessage += "�д��ѥ��T���q�l�l��a�}�C";
                    break;
                case AuthError.MissingPassword:
                    errorMessage += "�д��ѱK�X�C";
                    break;
                case AuthError.TooManyRequests:
                    errorMessage += "�ШD�L�h�A�еy��A�աC";
                    break;
                case AuthError.NetworkRequestFailed:
                    errorMessage += "�����ШD���ѡA���ˬd�z�������s���C";
                    break;
                default:
                    errorMessage += e.Message;
                    break;
            }

            Debug.Log(errorMessage);
        }
    }

}