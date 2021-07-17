using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Data
    [Header("Player Data")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float fallSpeed;

    private bool onGround;
    private Rigidbody2D playerRb;
    #endregion

    private void Awake()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);

        if (onGround && Input.GetAxisRaw("Jump") != 0) { Jump(); }
        if (playerRb.velocity.y < 0) { Fall(); }

        //if (Input.GetAxisRaw("Pick") != 0) { PickItem(); }
    }

    #region Methods
    private void Move(float input) { 
        playerRb.velocity = new Vector2(input * moveSpeed, playerRb.velocity.y); 
    }
    private void Jump() {
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
    }
    private void Fall() {
        playerRb.velocity += Vector2.up * Physics2D.gravity.y * (fallSpeed - 1) * Time.deltaTime;
    }
    private void PickItem() {
    }
    #endregion

    #region CollisionDetection
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer == 3) { onGround = true; }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer == 3) { onGround = false; }
    }
    
    #endregion
}