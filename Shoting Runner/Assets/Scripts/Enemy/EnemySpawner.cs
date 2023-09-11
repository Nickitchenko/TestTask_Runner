using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;

    [SerializeField] private float StartLenth;

    [SerializeField] private Vector3 CurrentPoint;
    [SerializeField] private float leftSide;
    [SerializeField] private float rightSide;
    [SerializeField] private float lastDistance;

    [SerializeField] private GameObject FinalRound;

    private float lenth;
    private float lvl;

    private bool isCanSpawn = true;

    private bool isFinalBoss = false;

    private void Start()
    {
        lvl = PlayerPrefs.GetInt("Level", 1);
        lenth = StartLenth - lvl / 10;
        if(lenth<=5)
        {
            lenth = 5;
        }
    }


    private void FixedUpdate()
    {
        if (isCanSpawn)
        {
            isCanSpawn = false;
            StartCoroutine(SpawnEnemy());
        }
        else if(isFinalBoss)
        {
            //GameObject player = GameObject.FindGameObjectWithTag("Player");
            //player.GetComponent<PlayerMovement>().enabled = false;
            //player.transform.position = new Vector3(0, 2, 220);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject enemy = Instantiate(Enemy, CurrentPoint, Quaternion.identity);
        if(lenth==5)
        {
            Enemy current_enemy= enemy.GetComponent<Enemy>();
            current_enemy.health = lvl;
            current_enemy.price = current_enemy.health / 2;
            current_enemy.RefreshUIHealth();
        }
        float new_z = CurrentPoint.z + lenth;
        if (new_z >= lastDistance)
        {
            isFinalBoss = true;
        }
        else
        {
            CurrentPoint = new Vector3(Random.Range(leftSide, rightSide), CurrentPoint.y, new_z);
            isCanSpawn = true;
        }
    }


}
