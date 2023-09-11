using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalBoss : MonoBehaviour
{
    public float price;
    public float health;

    public bool isFight = false;
    public GameObject target;
    public float speed;

    [SerializeField] private UIController uiController;

    public TMP_Text visualHealth;

    [SerializeField] private GameObject DieEffect;
    [SerializeField] private GameObject HitEffect;

    private void Start()
    {
        SetStartCharacters();
        RefreshUIHealth();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 newTarget = new Vector3(target.transform.position.x, target.transform.position.y + 2, target.transform.position.z);
            // Вычисляем направление к цели
            Vector3 direction = (newTarget - transform.position).normalized;

            // Вычисляем новую позицию с учетом скорости и времени
            Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

            // Перемещаем объект к новой позиции
            transform.position = newPosition;
        }
    }

    private void SetStartCharacters()
    {
        float lvl = PlayerPrefs.GetInt("Level", 1);
        health = lvl * 20;
        price = health / 2;
    }

    public void RefreshUIHealth()
    {
        visualHealth.text = health.ToString();
    }

    public void TakingDamage(int damage)
    {
        health -= damage;
        if (IsDie())
        {
            //+price
            DieEffect.SetActive(true);
            Invoke("DieTime", 0.5f);

        }
        else
        {
            HitEffect.SetActive(true);
            Invoke("ResetHitEffect", 0.2f);
            RefreshUIHealth();
        }
    }

    private void ResetHitEffect()
    {
        HitEffect.SetActive(false);
    }

    private void DieTime() //конец раунда
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().UpdateCoins(price);
        uiController.Win();
        Destroy(gameObject);
    }

    private bool IsDie()
    {
        if (health <= 0) return true;
        else return false;
    }
}
