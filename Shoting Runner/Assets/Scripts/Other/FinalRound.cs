using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRound : MonoBehaviour
{
    [SerializeField] private GameObject FinalBoss;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject player = other.gameObject;

            player.GetComponent<PlayerMovement>().enabled = false;
            player.transform.position = transform.position;
            player.GetComponent<PlayerMovement>().PlayerAnimator.enabled = false;


            FinalBoss.GetComponent<FinalBoss>().isFight = true;
            FinalBoss.GetComponent<FinalBoss>().target = player;


        }
    }
}
