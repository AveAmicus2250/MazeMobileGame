using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    void ActivateMenu()
    {

        Time.timeScale = 0;
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
    }
}
