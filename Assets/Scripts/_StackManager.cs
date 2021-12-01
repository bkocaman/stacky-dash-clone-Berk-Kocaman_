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
    }

    void Update()
    {
        
    }

    public void StackPlatform(GameObject Platform)
    {

        Vector3 playerPos = transform.localPosition;
        playerPos.y += platformHeight;
        transform.localPosition = playerPos;

        Platform.transform.SetParent(platformParent);
        Vector3 pos = prevPlatform.transform.localPosition;
        pos.y -= platformHeight;
        Platform.transform.localPosition = pos;

        

        prevPlatform.GetComponent<BoxCollider>().isTrigger = false;
        prevPlatform = Platform;

    }
}
