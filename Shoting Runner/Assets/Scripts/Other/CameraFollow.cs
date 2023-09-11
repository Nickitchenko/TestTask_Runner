using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform Target;

    //private Vector3 startDistance, moveVec;

    //private void Start()
    //{
    //    startDistance = transform.position - Target.position;
    //}

    //private void FixedUpdate()
    //{
    //    moveVec = Target.position + startDistance;

    //    moveVec.x = 0;
    //    moveVec.y = startDistance.y;

    //    transform.position = moveVec;
    //}

    public Transform target;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float damping = 2.0f;
    public float rotationDamping = 3.0f;

    public bool isMenu = true;

    private void LateUpdate()
    {
        if (!isMenu)
        {
            if (target == null) return;

            float wantedRotationAngle = target.eulerAngles.y;
            float wantedHeight = target.position.y + height;

            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, damping * Time.deltaTime);

            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            transform.position = target.position;
            transform.position -= currentRotation * Vector3.forward * distance;
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

            transform.LookAt(target);
        }
    }

    public void StartMoving()
    {
        this.GetComponent<Animator>().Play("StartCamera");
    }

}
