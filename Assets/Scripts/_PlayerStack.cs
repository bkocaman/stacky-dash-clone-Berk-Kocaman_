using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerStack : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private _StackManager stackManager;
    private _GameManager gameManager;

    private void Awake()
    {
        
        //player = this.transform.root.gameObject;
       //stackManager = player.GetComponent<_StackManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
          // Platform Trigger Enter
        if (other.tag == "Platform")
        {
            Debug.Log("Platform stacklendi");
            other.tag = "Untagged";
            _StackManager.instance.StackPlatform(other.gameObject);
            //other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //stackManager.StackPlatform(other.gameObject);

            //Yeni platformlar ekleme
            other.gameObject.AddComponent<_PlayerStack>();

            // Platformlarý yoketme
            Destroy(this);
        }

        else if( other.tag == "DropPlatform")
        {
            // Yeterli playform yoksa karakteri durdurma

            /*if (gameManager.PlatformUnder == 0)
            {
                //Yeterli platform yoksa karakteri geri yollama

                Vector3 playerVelocity = player.GetComponent<Rigidbody>().velocity;
                playerVelocity *= 1.5f;
                player.GetComponent<Rigidbody>().velocity -= playerVelocity;



            }
            */
            other.tag = "Untagged";
            //stackManager.DropPlatform(other.gameObject, 0);
            _StackManager.instance.DropPlatform(other.gameObject,0);
            Destroy(this);
        }
        


    }

        

       





    }

