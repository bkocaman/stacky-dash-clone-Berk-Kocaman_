using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerStack : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private _StackManager stackManager;

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

            // Platformlar� yoketme
            Destroy(this);
        }

        /* else if( other.tag == "DropPlatform")
        {
            // Sonra yap�lcak
        }

        */

       





    }
}
