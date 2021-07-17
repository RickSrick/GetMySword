using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public Animator animator;
    public bool swordInChest = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        openChest(collision);
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("OnZone", true);
            //animator.SetBool("IsPressed", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("OnZone", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        openChest(collision);
    }

    private void openChest(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && swordInChest)
        {
            animator.SetBool("IsPressed", true);
            Debug.Log("ABBIAMO LA SPADA");
            swordInChest = false;
        }
    }
}
