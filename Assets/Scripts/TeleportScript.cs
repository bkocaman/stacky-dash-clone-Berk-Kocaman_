using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Vector3 TeleportPoint; // teleportun kendi pozisyonu
    public TeleportScript whichteleporter; // hangi teleporta ýþýnlancaðýný seçtiðimiz yer
    public bool isTeleport;

    private void Awake()
    {

        isTeleport = true;
        TeleportPoint = transform.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerCollider" && isTeleport)
        {

            if (other.attachedRigidbody.velocity.magnitude != 0)
            {
                TeleportPlayer(other.transform.root);
            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerCollider")
        {
            isTeleport = true;

        }
    }

    public void TeleportPlayer(Transform player)
    {
        whichteleporter.isTeleport = false;
        player.localPosition = new Vector3(whichteleporter.transform.position.x, player.localPosition.y, whichteleporter.transform.position.z);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


}
