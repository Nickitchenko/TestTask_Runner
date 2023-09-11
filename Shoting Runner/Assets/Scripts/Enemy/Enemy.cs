using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public float price;
    public float health;

    public TMP_Text visualHealth;

    [SerializeField] private GameObject Platform;
    [SerializeField] private GameObject Person;

    [SerializeField] private List<Material> PersonMaterials;
    [SerializeField] private List<Material> StandMaterials;

    [SerializeField] private GameObject DieEffect;
    [SerializeField] private GameObject HitEffect;

    private void Start()
    {
        RefreshUIHealth();
        RandomColors();
    }

    private void RandomColors()
    {
        SkinnedMeshRenderer PersonRender = Person.GetComponent<SkinnedMeshRenderer>();
        PersonRender.material = PersonMaterials[Random.Range(0, PersonMaterials.Count)];

        Renderer PlatformRender = Platform.GetComponent<Renderer>();
        PlatformRender.material = StandMaterials[Random.Range(0, StandMaterials.Count)];
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

    private void DieTime()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().UpdateCoins(price);
        Destroy(gameObject);
    }

    private bool IsDie()
    {
        if (health <= 0) return true;
        else return false;
    }
}
