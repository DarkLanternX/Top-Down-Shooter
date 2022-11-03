using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public GameObject gun;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject player;
    AudioSource audioSrc;
    public Joystick Joystick;

    Vector3 velocity;
    bool isGrounded;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }




    void Update()
    {
        if(view.IsMine)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)                   // resets velocity if not grounded
            {
                velocity.y = -2f;
            }

            /*float x = Input.GetAxis("Horizontal");    //Keyboard controls
            float z = Input.GetAxis("Vertical");*/

            float x = Joystick.Horizontal;           //Touch Controls
            float z = Joystick.Vertical;


            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);


        }

    }

}

  
