using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class _PlayerController : MonoBehaviour
{
    [SerializeField] private bool isMoving = false;

    private Rigidbody rb;
    private float speed = 1000f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {
        if (!isMoving)
        {


            if (_MobileScreenController.Instance.swipeDown) // A�a�� kayd�rma
            {
                rb.AddForce(Vector3.back * speed);
            }
            else if (_MobileScreenController.Instance.swipeUp) // Yukar� kayd�rma
            {
                rb.AddForce(Vector3.forward * speed);
            }
            else if (_MobileScreenController.Instance.swipeLeft) // Sola kayd�rma
            {
                rb.AddForce(Vector3.left * speed);

            }
            else if (_MobileScreenController.Instance.swipeRight) // Sa�a kayd��rma
            {
                rb.AddForce(Vector3.right * speed);

            }

        }
        if (rb.velocity == Vector3.zero)
        {
            Vector3 stopPos = transform.localPosition;
            //Karakteri durdurma
            stopPos.x = (int)Convert.ToInt32(stopPos.x);
            stopPos.z = (int)Convert.ToInt32(stopPos.z);
            transform.localPosition = stopPos;
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
}
