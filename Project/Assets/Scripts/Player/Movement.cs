﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    CharacterController ctrl;
    public float speed = 4f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform cam;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public float jumpHeight = 5f;
    public float gravity = 18f;
   public bool canJump;
     Vector3 velocity;

    Rigidbody rb;
    public AudioSource footSrc;


    public Animator anim;
    void Start()
    {
        ctrl = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    public IEnumerator ReturnToNormal()
    {
        yield return new WaitForSeconds(0.4f);
        ctrl.enabled = true;
        rb.isKinematic = true;
    }


    void Update()
    {
        if (!ctrl.enabled)
            return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {
            if (!footSrc.isPlaying && isGrounded)
            {
                footSrc.volume = Random.Range(0.05f, 0.1f);
                footSrc.pitch = Random.Range(0.87f, 0.91f);
                footSrc.Play();
            }
             
            anim.SetBool("isWalking", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            ctrl.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        Jump();
    }

    void Jump()
    {
        if (!canJump) return;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        ctrl.Move(velocity * Time.deltaTime);
    }
}
