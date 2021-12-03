using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipPlatform : MonoBehaviour
{

    // Yataydan mý yoksa dikeydenmi geldiðini bulma
    public int FindTypeOfPlane(Vector3 playerVelocity)
    {
        float zTransform = playerVelocity.z;
        int TypeOfPlane;

        if(zTransform !=0)
        {

            // Dikeyden geliyor
            TypeOfPlane = 1;
        }
        else
        {
            // Yataydan geliyor
            TypeOfPlane = 0;
        }
        return TypeOfPlane;

    }


    // Playerin nerden geldiðini kontrol etme
    public int PlayerTrigger(Collider other)
    {

        Vector3 playerVelocity = other.transform.root.GetComponent<Rigidbody>().velocity;
        int TypeOfPlane = FindTypeOfPlane(playerVelocity);
        return TypeOfPlane;
    }


        
}
