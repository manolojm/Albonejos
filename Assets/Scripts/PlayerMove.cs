using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 7f;
    public float rotationSpeed = 250f;

    public Animator animator;
    private float x, y;

    public Rigidbody rb;
    public float jumpHeight = 3;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        if (Input.GetKey("d")) {
            animator.SetBool("Other", false);
            animator.Play("Dance");
        }

        if (x > 0 || x < 0 || y > 0 || y < 0) {
            animator.SetBool("Other", true);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Input.GetKey("space") && isGrounded) {
            animator.Play("Jump");
            Invoke("Salto", 1f);
            
        }
    }

    public void Salto() {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }
}
