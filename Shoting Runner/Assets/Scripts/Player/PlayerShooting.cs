using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    private const int BulletPrefabCount = 10;
    [SerializeField] private GameObject FirePos;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float fireRate; //cd of shooting
    private float fireCountDown = 0f;

    public PoolBase<Bullet> _bulletPool;

    private void Awake()
    {
        _bulletPool = new PoolBase<Bullet>(Preload, GetAction, ReturnAction, BulletPrefabCount);
        fireRate = PlayerPrefs.GetInt("Rate", 2);
    }

    private void Update()
    {
        if(fireCountDown<=0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    private void Shoot()
    {
        Bullet bullet = _bulletPool.Get();
        bullet.isActive = true; 
        bullet.transform.position = GameObject.FindWithTag("FirePoint").transform.position;
        StartCoroutine(End(bullet));
    }

    IEnumerator End(Bullet b)
    {
        yield return new WaitForSeconds(1f);
        b.isActive = false;
        b.transform.position = GameObject.FindWithTag("FirePoint").transform.position;
        _bulletPool.Return(b);
    }

    public Bullet Preload() => Instantiate(bulletPrefab, FirePos.transform.position, Quaternion.identity);
    public void GetAction(Bullet bullet) => bullet.gameObject.SetActive(true);
    public void ReturnAction(Bullet bullet) => bullet.gameObject.SetActive(false);

}
