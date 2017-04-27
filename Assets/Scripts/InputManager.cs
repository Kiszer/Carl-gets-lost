using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

	void Update ()
    {
		if(Input.GetAxis("Vertical") != 0)
        {
            playerController.MovePlayer(0, Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            playerController.MovePlayer(Input.GetAxis("Horizontal"), 0);
        }
        if (Input.GetAxis("LookVertical") > 0)
        {
            playerController.Rotate(0, 1);
        }
        if (Input.GetAxis("LookVertical") < 0)
        {
            playerController.Rotate(0, -1);
        }
        if (Input.GetAxis("LookHorizontal") > 0)
        {
            playerController.Rotate(1, 0);
        }
        if (Input.GetAxis("LookHorizontal") < 0)
        {
            playerController.Rotate(-1, 0);
        }
    }
}
