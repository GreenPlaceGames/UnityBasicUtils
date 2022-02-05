using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask mask;

    Rigidbody2D rb;
    Vector2 inputVec;
    public float movementSpeed;

    CapsuleCollider2D cc;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cc = gameObject.GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
        Debug.Log(isGrounded());
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputVec.x * movementSpeed, rb.velocity.y);
    }

    private bool isGrounded()
    {
     
        RaycastHit2D rch2d = Physics2D.Raycast(cc.bounds.center, Vector2.down, cc.bounds.extents.y + .01f, mask);
        if(rch2d.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
