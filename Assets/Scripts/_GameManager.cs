using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameManager : MonoBehaviour
{

    private int platformUnder = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }



    public int PlatformUnder
    {
        get
        {
            return platformUnder;
        }
        set
        {
            platformUnder = value;
        }
    }


}
