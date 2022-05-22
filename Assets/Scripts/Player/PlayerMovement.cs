using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSettingsScriptable playerSettings;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (IsMovingUp())
        {
            Translate(Vector3.up);
        }

        if (IsMovingDown())
        {
            Translate(Vector3.down);
        }

        if (IsMovingLeft())
        {
            Translate(Vector3.left);
        }

        if (IsMovingRight())
        {
            Translate(Vector3.right);
        }
    }

    /*
     * FUNTIONS TO CHECK DIRECTION OF THE MOVEMENT
     */
    private bool IsMovingUp()
    {
        return Input.GetKey(KeyCode.W);
    }
    private bool IsMovingDown()
    {
        return Input.GetKey(KeyCode.S);
    }
    private bool IsMovingLeft()
    {
        return Input.GetKey(KeyCode.A);
    }
    private bool IsMovingRight()
    {
        return Input.GetKey(KeyCode.D);
    }

    /*
     * FUNCTION TO TRANSLATE THE PLAYER 
     */
    private void Translate(Vector3 direction)
    {
        transform.Translate(direction * playerSettings.speed * Time.deltaTime, Space.World);
    }
}
