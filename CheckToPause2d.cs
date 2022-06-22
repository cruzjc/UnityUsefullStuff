using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckToPause2d : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        CheckToPause();
    }

    bool IsPlayerEngaged()
    {
        bool outOfBoundsA = Input.mousePosition.x <= 0 || Input.mousePosition.y <= 0;
        bool outOfBoundsB = Input.mousePosition.x >= Screen.width - 2 || Input.mousePosition.y >= Screen.height - 2;
        if (outOfBoundsA || outOfBoundsB)
        {
            return false;
        }
        return true;
    }

    void CheckToPause()
    {
        if (!IsPlayerEngaged())
        {
            Time.timeScale = 0;
            Debug.Log("Game is Pause");
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("Game Unpaused");

        }

    }
}
