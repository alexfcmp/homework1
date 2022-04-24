using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Debug;

namespace LevelMaze
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        public int keys;

        public static float speed;

        CharacterController controller;

        public float gravity = -9.81f;
        public Vector3 velocity;

        bool groundCheck;
        public Transform groundObject;
        public LayerMask groundMask;

        public Animator cameraAnim;

        public static UnityAction AudioEvent;

        void Start()
        {
            controller = GetComponent<CharacterController>();
            KeyPanel.onPlayerTouchedPanel += onTouchPanel;

            speed = 5f;
        }

        protected void UnitMove()
        {
            groundCheck = Physics.CheckSphere(groundObject.position, 0.3f, groundMask);
            if (groundCheck)
            {
                velocity.y = -2f;
            }
            //движение на земле
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (x != 0 || z != 0) 
            {
                cameraAnim.SetBool("isWalking", true);
                AudioEvent.Invoke();
            }
            else { cameraAnim.SetBool("isWalking", false); }

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

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Key")
            {
                keys++;
                Destroy(other.gameObject);
                Log("destroy");
            }
        }

        void onTouchPanel()
        {
            Log("touch");
            if (keys == 4)
            {
                KeyPanel.hasKeys = true;
            }
        }
    }
}