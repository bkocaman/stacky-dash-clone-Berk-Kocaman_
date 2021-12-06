using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SagYukari : SkipPlatform, ISkipPlatform
{
    private float speed = 1100f;
    private int TypeOfPlane = 0;


    // Objemizi sol sag yukar� koydu�umuz i�in karakteri sola ve asagi g�ndermesi gerekiyor
    public void SkipPlayer(Rigidbody player)
    {
        player.velocity = Vector3.zero;
        if (TypeOfPlane == 0)
        {
            // Karakter yataydan gelirse yukar� g�nderme
            player.AddForce(Vector3.back * speed);
        }
        else
        {
            // Karakter dikeyden gelince sola g�nderme
            player.AddForce(Vector3.left * speed);
        }
    }


    // E�er playerin collideri ile triggerlan�rsa (superclasstan de�erleri �ektik)
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "PlayerCollider")
        {

            TypeOfPlane = base.PlayerTrigger(other);
            SkipPlayer(other.transform.root.GetComponent<Rigidbody>());

        }

    }

}
