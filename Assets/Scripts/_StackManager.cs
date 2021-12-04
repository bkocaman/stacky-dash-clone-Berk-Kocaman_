using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _StackManager : MonoBehaviour
{

    [SerializeField]Transform platformParent;
    [SerializeField]GameObject prevPlatform;
    [SerializeField]private float platformHeight = 0.050f;
    private _GameManager gameManager;
    private _PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<_PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<_GameManager>();

        //Unity içinden elimizlede atabilirdik
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
        gameManager.PlatformUnder += 1;

        // Platformu stackleme
        Platform.transform.SetParent(platformParent);
        Vector3 pos = prevPlatform.transform.localPosition;
        pos.y -= platformHeight;
        Platform.transform.localPosition = pos;
        

        prevPlatform = Platform;
        prevPlatform.GetComponent<BoxCollider>().isTrigger = false;

        // Score ve platformunder tanýmladýk
        gameManager.Score += 1;
        gameManager.PlatformUnder += 1;
    }

    public void DropPlatform(GameObject platform, int type)
    {
        
       
        // Sýradaki platformu bulmak için indexi alýyoruz
        int i = prevPlatform.transform.GetSiblingIndex();
        prevPlatform.transform.SetParent(platform.transform.parent);
        Vector3 pos = prevPlatform.transform.localPosition;
        prevPlatform.transform.localPosition = platform.transform.localPosition;
        Vector3 playerPos = transform.localPosition;


        platform.GetComponent<BoxCollider>().isTrigger = false;
        // Bir platform düþtüðünde
        gameManager.PlatformUnder -= 1;

        if (type == 0)
        {
            //DropPlatform
            playerPos.y -= platformHeight;
        }

        // FinishGame platformda puan kazanmaya devam eder
        if (playerController.EndGamePoint)
        {
            gameManager.Score += 1;
        }


        transform.localPosition = playerPos;
        if (platformParent.childCount != 0)
        {
            prevPlatform = platformParent.GetChild(i - 1).gameObject;
            prevPlatform.AddComponent<_PlayerStack>();

        }
        


    }
}
