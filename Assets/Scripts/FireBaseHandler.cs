using UnityEngine;
using UnityEngine.UI;

public class FireBaseHandler : MonoBehaviour
{

    [Header("���U����")]

    [Header("�n�J����")]
    [SerializeField] LoginUIController loginUIController;

    [Header("Other")]
    [SerializeField] FireBaseManager fireBaseManager;



    private void Start()
    {
        loginUIController.Setup(fireBaseManager);
    }


}
