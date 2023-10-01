
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TeleportEmptyObject : UdonSharpBehaviour
{
    
    void Start()
    {
        
    }

    public void TeleportPlayer()
    {
        //print to console that the player has been teleported
        Debug.Log("Teleporting player to " + transform.position + " " + transform.rotation);
        Networking.LocalPlayer.TeleportTo(transform.position, transform.rotation);
        
        
        
    }
}
