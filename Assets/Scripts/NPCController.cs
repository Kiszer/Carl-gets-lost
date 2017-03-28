using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    private Vector2 destination;
    private float moveSpeed = 0.04f;

    void Start()
    {
        destination = new Vector2(12 * (Random.Range(0f, 1f) > 0.5f ? -1 : 1), Random.Range(-6f, 6f));
        transform.position = new Vector2(-destination.x, Random.Range(-6, 6f));
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed);
        if ((Vector2)transform.position == destination)
        {
            Destroy(gameObject);
        }
    }
}
