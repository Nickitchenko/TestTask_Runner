using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    [SerializeField] private TMP_Text DamageText;
    [SerializeField] private TMP_Text RateText;

    int damage, rate, damageCost, rateCost;

    [SerializeField] private TMP_Text DamageUpgradeCost;
    [SerializeField] private TMP_Text RateUpgradeCost;

    private void Start()
    {
        RefreshInfo();
    }

    private void RefreshInfo()
    {
        damage = PlayerPrefs.GetInt("Damage", 1);
        rate = PlayerPrefs.GetInt("Rate", 2);

        DamageText.text = damage.ToString();
        RateText.text = rate.ToString();

        damageCost = PlayerPrefs.GetInt("DamageCost", 5);
        rateCost = PlayerPrefs.GetInt("RateCost", 10);

        DamageUpgradeCost.text = "COST " + damageCost.ToString();
        RateUpgradeCost.text = "COST " + rateCost.ToString();
    }

    public void UpgradeDamage()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        if (coins>=damageCost)
        {
            coins -= damageCost;
            PlayerPrefs.SetInt("Coins", coins);
            uiController.UpdateCoins(coins);

            damage++;
            PlayerPrefs.SetInt("Damage", damage);
            damageCost += 5;
            PlayerPrefs.SetInt("DamageCost", damageCost);
            RefreshInfo();
        }
    }

    public void UpgradeRate()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        if (coins >= rateCost)
        {
            coins -= rateCost;
            PlayerPrefs.SetInt("Coins", coins);
            uiController.UpdateCoins(coins);

            rate++;
            PlayerPrefs.SetInt("Rate", rate);
            rateCost += 5;
            PlayerPrefs.SetInt("RateCost", rateCost);
            RefreshInfo();
        }
    }

}
