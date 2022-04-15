using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        public float speed = 5.0f;

        CharacterController controller;

        public float gravity = -9.81f;
        public Vector3 velocity;

        bool groundCheck;
        public Transform groundObject;
        public LayerMask groundMask;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        protected virtual void UnitMove()
        {
            groundCheck = Physics.CheckSphere(groundObject.position, 0.3f, groundMask);
            if (groundCheck)
            {
                velocity.y = -2f;
            }
            //движение на земле
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(speed * move * Time.deltaTime);

            //гравитация
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        void Update()
        {
            UnitMove();
        }
    }
}