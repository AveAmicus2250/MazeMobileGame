using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BT;

public class VisionCone : MonoBehaviour
{
    public bool enter = true;

    public TextMeshProUGUI YouveBeenSpottedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SetUI()
    { 

        YouveBeenSpottedText.enabled = false;
      
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.CanSee(other.transform))
            {
                Destroy(other.gameObject);
                Application.LoadLevel(Application.loadedLevel);
                YouveBeenSpottedText.enabled = true;
            }
            
        }
        //If player enters trigger
        //LineCast from transform position to player
        //If line reaches player, then do shit
    }
}
