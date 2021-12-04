using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class _PlayerController : MonoBehaviour
{
    [SerializeField] private bool isMoving = false;
    [SerializeField] public bool EndGamePoint = false;
    [SerializeField] public bool GameFinished = false;
    private _GameManager gameManager;

    private Rigidbody rb;
    private float speed = 1000f;
    private Animator animator;

    int endPlatform = 0;

    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<_GameManager>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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


        if (EndGamePoint)
        {
            if (gameManager.PlatformUnder == 0 && !GameFinished)
            {
              //Oyunu bitirme
                rb.velocity = Vector3.zero;
                GameFinished = true;

               
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishGame")
        {
            // Son noktaya gelince karakteri durdurup animasyonu oynatma
            rb.velocity = Vector3.zero;
            gameManager.endGameMethod();

        }
        else if (other.tag == "EndGamePoint")
        {
            endPlatform = gameManager.PlatformUnder;
            EndGamePoint = true;
        }
        

    }

}

