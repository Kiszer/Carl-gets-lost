using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject playerFab;
    private PlayerController keyboardController;
    private PlayerController pad1Controller;
    private PlayerController pad2Controller;

    void Start()
    {
        keyboardController = FindObjectOfType<PlayerController>();
        pad1Controller = FindObjectOfType<PlayerController>();
    }

	void FixedUpdate ()
    {
        //Keyboard Input
        if (keyboardController != null)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                keyboardController.MovePlayer(0, Input.GetAxis("Vertical"));
            }
            if (Input.GetAxis("Horizontal") != 0)
            {
                keyboardController.MovePlayer(Input.GetAxis("Horizontal"), 0);
            }
            if (Input.GetAxis("LookVertical") > 0)
            {
                keyboardController.Rotate(0, 1);
            }
            if (Input.GetAxis("LookVertical") < 0)
            {
                keyboardController.Rotate(0, -1);
            }
            if (Input.GetAxis("LookHorizontal") > 0)
            {
                keyboardController.Rotate(1, 0);
            }
            if (Input.GetAxis("LookHorizontal") < 0)
            {
                keyboardController.Rotate(-1, 0);
            }
            if (Input.GetButtonDown("RedColor"))
            {
                keyboardController.shootColor = Color.red;
            }
            if (Input.GetButtonDown("BlueColor"))
            {
                keyboardController.shootColor = Color.blue;
            }
            if (Input.GetButtonDown("GreenColor"))
            {
                keyboardController.shootColor = Color.green;
            }
            if (Input.GetButtonDown("YellowColor"))
            {
                keyboardController.shootColor = Color.yellow;
            }
        }

        //Gamepad 1
        if (pad1Controller != null)
        {
            if (Input.GetAxis("Vertical_1") != 0)
            {
                pad1Controller.MovePlayer(0, Input.GetAxis("Vertical_1"));
            }
            if (Input.GetAxis("Horizontal_1") != 0)
            {
                pad1Controller.MovePlayer(Input.GetAxis("Horizontal_1"), 0);
            }
            if (Input.GetAxis("LookVertical_1") > 0)
            {
                pad1Controller.Rotate(0, 1);
            }
            if (Input.GetAxis("LookVertical_1") < 0)
            {
                pad1Controller.Rotate(0, -1);
            }
            if (Input.GetAxis("LookHorizontal_1") > 0)
            {
                pad1Controller.Rotate(1, 0);
            }
            if (Input.GetAxis("LookHorizontal_1") < 0)
            {
                pad1Controller.Rotate(-1, 0);
            }
            if (Input.GetButtonDown("RedColor_1"))
            {
                pad1Controller.shootColor = Color.red;
            }
            if (Input.GetButtonDown("BlueColor_1"))
            {
                pad1Controller.shootColor = Color.blue;
            }
            if (Input.GetButtonDown("GreenColor_1"))
            {
                pad1Controller.shootColor = Color.green;
            }
            if (Input.GetButtonDown("YellowColor_1"))
            {
                pad1Controller.shootColor = Color.yellow;
            }
        }

        //Gamepad 2
        if (pad2Controller != null)
        {
            if (Input.GetAxis("Vertical_2") != 0)
            {
                pad2Controller.MovePlayer(0, Input.GetAxis("Vertical_2"));
            }
            if (Input.GetAxis("Horizontal_2") != 0)
            {
                pad2Controller.MovePlayer(Input.GetAxis("Horizontal_2"), 0);
            }
            if (Input.GetAxis("LookVertical_2") > 0)
            {
                pad2Controller.Rotate(0, 1);
            }
            if (Input.GetAxis("LookVertical_2") < 0)
            {
                pad2Controller.Rotate(0, -1);
            }
            if (Input.GetAxis("LookHorizontal_2") > 0)
            {
                pad2Controller.Rotate(1, 0);
            }
            if (Input.GetAxis("LookHorizontal_2") < 0)
            {
                pad2Controller.Rotate(-1, 0);
            }
            if (Input.GetButtonDown("RedColor_2"))
            {
                pad2Controller.shootColor = Color.red;
            }
            if (Input.GetButtonDown("BlueColor_2"))
            {
                pad2Controller.shootColor = Color.blue;
            }
            if (Input.GetButtonDown("GreenColor_2"))
            {
                pad2Controller.shootColor = Color.green;
            }
            if (Input.GetButtonDown("YellowColor_2"))
            {
                pad2Controller.shootColor = Color.yellow;
            }
        }
    }

    public void SetNewPlayers(int numPlayers)
    {
        if (numPlayers > 1)
        {
            GameObject player2 = Instantiate(playerFab, Vector2.zero + Vector2.right * 2, Quaternion.identity);
            if (Input.GetJoystickNames().Length > 1)
            {
                if (Input.GetJoystickNames()[1] != "")
                {
                    pad1Controller = keyboardController;
                    pad2Controller = player2.GetComponent<PlayerController>();
                    return;
                }
            }
            pad1Controller = player2.GetComponent<PlayerController>();
        }
    }

    public void RemovePlayer(PlayerController deadPlayer)
    {
        if(keyboardController == deadPlayer)
        {
            keyboardController = null;
        }
        if(pad1Controller == deadPlayer)
        {
            pad1Controller = null;
        }
        if (pad2Controller == deadPlayer)
        {
            pad2Controller = null;
        }
    }
}
