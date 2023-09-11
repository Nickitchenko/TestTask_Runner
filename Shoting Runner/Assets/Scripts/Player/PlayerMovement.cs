using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Slider movementSlider;

    private CharacterController cc;

    public Animator PlayerAnimator;

    private Vector3 moveVec;
    
    public float speed = 5;

    public float sliderPos,
                 sideSpeed;

    public void PlayerPosChanger()
    {
        sliderPos = movementSlider.value;
    }

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        moveVec = new Vector3(1, 0, 0);
    }

    private void FixedUpdate()
    {
        moveVec.z = speed;
        moveVec *= Time.deltaTime;
        cc.Move(moveVec);
        transform.position = new Vector3(sliderPos, transform.position.y, transform.position.z);
    }


}
