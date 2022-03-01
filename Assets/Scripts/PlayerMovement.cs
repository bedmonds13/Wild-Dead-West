using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100f;
    [SerializeField]
    private float forwardSpeed = 200f;
    [SerializeField]
    private float backwardSpeed = 100f;

    private float movementSpeed = 20f;

    private Animator animator;
    CharacterController controller;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        float direction = 1;
        if (horizontal < 0.1 && horizontal > -0.1)
        {
            //continue vertical animation
            direction = 1;
            animator.SetFloat("Speed", vertical);
        }
        else
        {
            direction = 0;
            animator.SetFloat("Speed", horizontal);
        }

        animator.SetFloat("Direction", direction);

        /*animator.SetFloat("Direction", direction);
        animator.SetFloat("Speed", vertical);
        */
        if (Input.GetMouseButton(1) == false)
        {
            var mouseHorizontal = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up, mouseHorizontal * Time.deltaTime * rotationSpeed);
        }
        Vector3 playerDirection = (transform.forward * vertical + transform.right * horizontal);
        movementSpeed = vertical < 0 ? backwardSpeed : forwardSpeed;
        controller.SimpleMove(playerDirection * Time.deltaTime * movementSpeed );
    }



}
