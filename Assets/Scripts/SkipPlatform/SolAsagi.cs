using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolAsagi : SkipPlatform, ISkipPlatform
{
    private float speed = 1100f;
    private int TypeOfPlane = 0;

    // Objemizi sol asagi koyduðumuz için karakteri saga ve yukarý göndermesi gerekiyor
    public void SkipPlayer(Rigidbody player)
    {
        player.velocity = Vector3.zero;
        if (TypeOfPlane == 0)
        {
            // Karakter yataydan gelirse yukarý gönderme
            player.AddForce(Vector3.forward * speed);
        }
        else
        {
            // Karakter dikeyden gelince saga gönderme
            player.AddForce(Vector3.right * speed);
        }
    }

    // Eðer playerin collideri ile triggerlanýrsa (superclasstan deðerleri çektik)
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "PlayerCollider")
        {

            TypeOfPlane = base.PlayerTrigger(other);
            SkipPlayer(other.transform.root.GetComponent<Rigidbody>());

        }
    }
}
