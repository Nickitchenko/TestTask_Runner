using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("FinalBoss") || other.gameObject.CompareTag("DeathSide"))
        {
            uiController.Loose();
        }
    }

    public void UpdateCoins(float amount)
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        coins += (int)amount;
        PlayerPrefs.SetInt("Coins", coins);
        uiController.UpdateCoins(coins);
    }

}
