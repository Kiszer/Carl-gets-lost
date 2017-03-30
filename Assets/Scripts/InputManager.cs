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
		if(Input.GetKey(KeyCode.W))
        {
            playerController.MovePlayer(0, 1);
        }
        if(Input.GetKey(KeyCode.A))
        {
            playerController.MovePlayer(-1, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            playerController.MovePlayer(0, -1);
        }
        if(Input.GetKey(KeyCode.D))
        {
            playerController.MovePlayer(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerController.Shoot(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerController.Shoot(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            playerController.Shoot(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerController.Shoot(1, 0);
        }
    }
}
