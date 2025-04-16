using UnityEngine;
using UnityEngine.UI;

public class FireBaseHandler : MonoBehaviour
{

    [Header("µù¥U­¶­±")]

    [Header("µn¤J­¶­±")]
    [SerializeField] LoginUIController loginUIController;

    [Header("Other")]
    [SerializeField] FireBaseManager fireBaseManager;



    private void Start()
    {
        loginUIController.Setup(fireBaseManager);
    }


}
