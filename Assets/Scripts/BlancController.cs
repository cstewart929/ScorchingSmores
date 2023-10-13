using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlancController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    public GameObject blancCamera;

    public float walkSpeed;
    private float input_right = 0;
    private float input_forward = 0;

    // Add a variable to track whether the player is moving.
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input_right = Input.GetAxis("Horizontal");
        input_forward = Input.GetAxis("Vertical");

        // Check if the player is moving.
        isMoving = input_right != 0 || input_forward != 0;
    }

    void FixedUpdate()
    {
        Vector3 forward = Vector3.ProjectOnPlane(blancCamera.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(blancCamera.transform.right, Vector3.up).normalized;

        // Walking
        Vector3 movement = input_right * right + input_forward * forward;
        movement = walkSpeed * movement.normalized;

        rigidBody.MovePosition(rigidBody.position + movement * Time.deltaTime);
    
        transform.LookAt(transform.position + forward);
    
        // Set the "isWalking" parameter in the Animator.
        animator.SetBool("isWalking", isMoving);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
    }

    void OnCollisionExit(Collision collision)
    {
        GameObject obj = collision.gameObject;
    }
}
