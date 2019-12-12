using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    public bool hasObtainedKey;
    
    private void OnTriggerEnter(Collider other)
    {
        //if the player collides with the key
        if (other.gameObject.CompareTag("Key"))
        {
            //gets fadeyboi, a script used to change the Alpha on a ui image
            FadeyBoi fade = FindObjectOfType<FadeyBoi>();
            if (fade)
            {
                //set the sprite transparency to be full alpha (opaque)
                fade.SetSpriteTransparency(1);
            }
            //the player has got the key
            hasObtainedKey = true;
            //remove the gameobject from the scene
            Destroy(other.gameObject);
        }

        //if other is a door and you have the key
        //Delete door object

        //if other is portal
        //load next scene
    }
}

