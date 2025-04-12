using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Text MoneyAmount;
    private int money;

    
    float addMoneyTimer = 5f;
    private void Awake()
    {
        money = PlayerPrefs.GetInt("Money", 0);
    }

    private void Update()
    {
        MoneyAmount.text = "Money : " + money.ToString();

        addMoneyTimer -= Time.deltaTime;
        if(addMoneyTimer <= 0f)
        {
            money += 1;
            PlayerPrefs.SetInt("Money", money);
            addMoneyTimer = 5f;
        }

    }

}
