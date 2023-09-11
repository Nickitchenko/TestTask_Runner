using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject LooseUI;
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private GameObject UpgradeUI;
    [SerializeField] private GameObject GameUI;
    [SerializeField] private TMP_Text lvlText;
    [SerializeField] private TMP_Text coinsText;

    private void Start()
    {
        Time.timeScale = 0f;

        WinUI.SetActive(false);
        LooseUI.SetActive(false);
        MenuUI.SetActive(true);
        UpgradeUI.SetActive(false);
        GameUI.SetActive(false);

        float c = PlayerPrefs.GetInt("Coins", 0);
        UpdateCoins(c);

        lvlText.text = "CURRENT LVL " + PlayerPrefs.GetInt("Level", 1).ToString();

    }

    public void Play()
    {
        WinUI.SetActive(false);
        LooseUI.SetActive(false);
        MenuUI.SetActive(false);
        UpgradeUI.SetActive(false);
        GameUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void UpdateCoins(float coins)//
    {
        coinsText.text = "COINS " + coins.ToString();
    }

    public void BackToMenu()
    {
        WinUI.SetActive(false);
        LooseUI.SetActive(false);
        MenuUI.SetActive(true);
        UpgradeUI.SetActive(false);
        GameUI.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Win()//
    {
        int currentLvl = PlayerPrefs.GetInt("Level", 1);
        currentLvl++;
        PlayerPrefs.SetInt("Level", currentLvl);

        Time.timeScale = 0f;
        WinUI.SetActive(true);
        LooseUI.SetActive(false);
        MenuUI.SetActive(false);
        UpgradeUI.SetActive(false);
        GameUI.SetActive(false);
    }

    public void Loose()//
    {
        Time.timeScale = 0f;
        WinUI.SetActive(false);
        LooseUI.SetActive(true);
        MenuUI.SetActive(false);
        UpgradeUI.SetActive(false);
        GameUI.SetActive(false);
    }

    public void OpenUpgradeUI()
    {
        Time.timeScale = 0f;
        MenuUI.SetActive(false);
        UpgradeUI.SetActive(true);
    }

    public void CloseUpgradeUI()
    {
        Time.timeScale = 0f;
        MenuUI.SetActive(true);
        UpgradeUI.SetActive(false);
    }    

}
