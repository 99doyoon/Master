using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] private PlayerMoney playerMoney;
    [SerializeField] private TMP_Text goldText;

    private void Start()
    {
        UpdateGoldUI();

        playerMoney.OnGoldChanged += UpdateGoldUI;
    }

    private void UpdateGoldUI()
    {
        goldText.text = "Gold : " + playerMoney.NowGold.ToString();
    }
}
