using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class _PlayerController : MonoBehaviour
{
    [SerializeField] private bool isMoving = false;

    public static _PlayerController instance;
    private Rigidbody rb;
    private float speed = 1000f;


    private void Awake()
    {
        if(instance == null)
        {
            instance = null;
        }
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {
        if (!isMoving)
        {


            if (_MobileScreenController.Instance.swipeDown) // Aþaðý kaydýrma
            {
                rb.AddForce(Vector3.back * speed);
            }
            else if (_MobileScreenController.Instance.swipeUp) // Yukarý kaydýrma
            {
                rb.AddForce(Vector3.forward * speed);
            }
            else if (_MobileScreenController.Instance.swipeLeft) // Sola kaydýrma
            {
                rb.AddForce(Vector3.left * speed);

            }
            else if (_MobileScreenController.Instance.swipeRight) // Saða kaydýýrma
            {
                rb.AddForce(Vector3.right * speed);

            }

        }
        //Karakteri durdurma
        if (rb.velocity == Vector3.zero)
        {
            Vector3 stopPos = transform.localPosition;
            
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

