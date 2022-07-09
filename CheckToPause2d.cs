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


    // Checks if Mouse cursor is within borders
    bool IsMouseCursorWithinBorders()
    {
        int offset = 2;
        bool outOfBoundsLeftSide = Input.mousePosition.x <= 0;
        bool outOfBoundsRightSide = Input.mousePosition.x >= Screen.width - offset ;
        bool outOfBoundsTopSide = Input.mousePosition.y >= Screen.height - offset;
        bool outOfBoundsBottomSide = Input.mousePosition.y <= 0;
        
        if (outOfBoundsLeftSide || outOfBoundsRightSide || outOfBoundsTopSide || outOfBoundsBottomSide)
        {
            return false;
        }
        return true;
    }


    //Pauses game if cursor is out of bounds
    void CheckToPause()
    {
        if (!IsMouseCursorWithinBorders())
        {
            Time.timeScale = 0;
            //Debug.Log("Game is Pause");
        }
        else
        {
            Time.timeScale = 1;
            //Debug.Log("Game Unpaused");
        }

    }
}
