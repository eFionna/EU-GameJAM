using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 4;
    public RoofSlot roofslot;
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public GameObject pausemenu;
    void Start()
    {
        pausemenu.SetActive(false);
    }

    Vector2 movePos;
    void Update()
    {
        movePos.x = Input.GetAxisRaw("Horizontal");
        movePos.y = Input.GetAxisRaw("Vertical");

        rigidbody2D.MovePosition(rigidbody2D.position + movePos * speed * Time.deltaTime);

        if (movePos.x > 0 || movePos.y > 0)
        {

            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (roofslot != null)
            {
                animator.SetTrigger("Interact");

                roofslot.Interact();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausemenu.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
