using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public RoofSlot roofslot;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") / 10;
        vertical = Input.GetAxis("Vertical") / 10;
        if (horizontal != 0 || vertical != 0)
        {
            transform.position += new Vector3(horizontal, vertical, 0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            roofslot.Interact();
        }
    }
}
