using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] public GameObject YouWinPanel;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //if the sphere collider on the door hits the player 
        if (other.gameObject.CompareTag("Player"))
        {
            print("I was touched inappropriately");
            //gets the player interaction scripts
            Player_Interaction playerInteractionCheck = other.GetComponent<Player_Interaction>();
            //checks to see if the player has obtained the key. If the player has
            if (playerInteractionCheck.hasObtainedKey == true)
            {
                //gets fadeyboi, a script used to change the Alpha on a ui image
                FadeyBoi fade = FindObjectOfType<FadeyBoi>();
                //sets the door as inactive, allowing the player to pass
                gameObject.SetActive(false);
                YouWinPanel.SetActive(true);
                //the player no longer has the key
                playerInteractionCheck.hasObtainedKey = false;
                //sets the alpha on the key image in ui to be transparent
                fade.SetSpriteTransparency(.2f);
                //playerInteractionCheck.hasObtainedKey = false;
            }

        }
    }
}
