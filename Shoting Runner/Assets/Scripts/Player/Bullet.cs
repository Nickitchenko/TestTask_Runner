using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // Скорость пули

    public int damage;

    public bool isActive = false;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        damage = PlayerPrefs.GetInt("Damage", 1);
        transform.position = GameObject.FindWithTag("FirePoint").transform.position;
        //rb.velocity = transform.forward * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            //other.gameObject.GetComponent<Enemy>().TakingDamage(damage);
            //isActive = false;
            //transform.position = GameObject.FindWithTag("FirePoint").transform.position;
            //GameObject.FindWithTag("Gun").GetComponent<PlayerShooting>()._bulletPool.Return(this);

            other.gameObject.GetComponent<Enemy>().TakingDamage(damage);
            GameObject.FindWithTag("Gun").GetComponent<PlayerShooting>()._bulletPool.Return(this);
            transform.position = GameObject.FindWithTag("FirePoint").transform.position;
            isActive = false;

        }
        else
        {
            if(other.gameObject.CompareTag("FinalBoss"))
            {
                other.gameObject.GetComponent<FinalBoss>().TakingDamage(damage);
                GameObject.FindWithTag("Gun").GetComponent<PlayerShooting>()._bulletPool.Return(this);
                transform.position = GameObject.FindWithTag("FirePoint").transform.position;
                isActive = false;
            }
        }
    }
}
