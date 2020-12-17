using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    public float speed = 4;
    public RoofSlot roofslot;
    public Animator animator;
    public Rigidbody2D rigidbody2D;

    Vector2 movePos;
    void Update()
    {
        movePos.x = Input.GetAxisRaw("Horizontal");
        movePos.y = Input.GetAxisRaw("Vertical");

        rigidbody2D.MovePosition(rigidbody2D.position + movePos * speed * Time.fixedDeltaTime);

        if (movePos.x != 0 || movePos.y != 0)
        {

            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.PausGame();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (roofslot != null)
            {
                animator.SetTrigger("Interact");

                roofslot.Interact();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactabels"))
        {
            roofslot = collision.GetComponent<RoofSlot>();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        roofslot = null;
    }
}
