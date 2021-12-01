using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerStack : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private _StackManager stackManager;

    private void Awake()
    {
        player = this.transform.root.gameObject;
        stackManager = player.GetComponent<_StackManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
          
        if (other.tag == "Platform")
        {
            other.tag = "Untagged";
            stackManager.StackPlatform(other.gameObject);
            
            other.gameObject.AddComponent<_PlayerStack>();
            
            Destroy(this);
        }
    }
}
