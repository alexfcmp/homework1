using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public class Camera : MonoBehaviour
    {
        float xRotation = 0f;

        public float mouseS;

        public Transform playerBody;

        float mouseX;
        float mouseY;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            mouseS = 100f;
        }

        // Update is called once per frame
        void Update()
        {
            mouseX = Input.GetAxis("Mouse X") * mouseS * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseS * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

}