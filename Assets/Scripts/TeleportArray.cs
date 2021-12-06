using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportArray : MonoBehaviour
{
    public TeleportScript[] teleports;
    
    void Start()
    {
        // Teleport arrayi oluþturduk 
        teleports = GetComponentsInChildren<TeleportScript>();
        teleportArray();
    }


    private void teleportArray()
    {
        for (int i = 0; i <= teleports.Length - 2; i += 2)
        {
            teleports[i].whichteleporter = teleports[i + 1];
            teleports[i + 1].whichteleporter = teleports[i];
        }
    }

}
