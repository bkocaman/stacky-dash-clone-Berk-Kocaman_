using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _StackManager : MonoBehaviour
{
    [SerializeField] Transform platformParent;
    [SerializeField] GameObject prevPlatform;
    [SerializeField] private float platformHeight = 0.050f;
    private _PlayerController playerController;
    void Start()
    {
        playerController = GetComponent<_PlayerController>();

        platformParent = transform.GetChild(2);
        prevPlatform = platformParent.GetChild(0).gameObject;
    }

    void Update()
    {

    }

    public void StackPlatform(GameObject Platform)
    {

        // Player yükseldikçe
        Vector3 playerPos = transform.localPosition;
        playerPos.y += platformHeight;
        transform.localPosition = playerPos;

        // Platformu stackleme
        Platform.transform.SetParent(platformParent);
        Vector3 pos = prevPlatform.transform.localPosition;
        pos.y -= platformHeight;
        Platform.transform.localPosition = pos;



        prevPlatform.GetComponent<BoxCollider>().isTrigger = false;
        prevPlatform = Platform;

    }

    public void DropPlatform(GameObject platform, int type)
    {
        
        //Sýradaki platformu bulmak için indexi alýyoruz
        int i = prevPlatform.transform.GetSiblingIndex();
        prevPlatform.transform.SetParent(platform.transform.parent);
        Vector3 pos = prevPlatform.transform.localPosition;
        prevPlatform.transform.localPosition = platform.transform.localPosition;
        Vector3 playerPos = transform.localPosition;

        platform.GetComponent<BoxCollider>().isTrigger = false;

        if (type == 0)
        {
            // Platformu býrakan yoldan geçince
            playerPos.y -= platformHeight;
        }
       
        transform.localPosition = playerPos;
        if (platformParent.childCount != 0)
        {
            prevPlatform = platformParent.GetChild(i - 1).gameObject;
            prevPlatform.AddComponent<_PlayerController>();

        }
    }
}
