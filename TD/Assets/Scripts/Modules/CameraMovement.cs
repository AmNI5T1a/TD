using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD_game
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _cameraSpeed = 10;
        [SerializeField] private float _cameraRotationSpeed = 10;
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _objectToFollowForCamera;

        void Start()
        {

        }
        void Update()
        {
            /// Camera Rotation

            if (VirtualInputManager.Instance.RightClickMouse)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                transform.Rotate(transform.up, Input.GetAxis("Mouse X") * _cameraRotationSpeed * Time.deltaTime , Space.World);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            
            /// Camera Movement
            if (VirtualInputManager.Instance.MoveBack && VirtualInputManager.Instance.MoveFront)
            {
                return;
            }
            if (VirtualInputManager.Instance.MoveLeft && VirtualInputManager.Instance.MoveRight)
            {
                return;
            }
            if (VirtualInputManager.Instance.MoveFront)
            {
                this.gameObject.transform.Translate(Vector3.forward * _cameraSpeed * Time.deltaTime);
            }
            if (VirtualInputManager.Instance.MoveBack)
            {
                this.gameObject.transform.Translate(-Vector3.forward * _cameraSpeed * Time.deltaTime);
            }
            if (VirtualInputManager.Instance.MoveLeft)
            {
                this.gameObject.transform.Translate(-Vector3.right * _cameraSpeed * Time.deltaTime);
            }
            if (VirtualInputManager.Instance.MoveRight)
            {
                this.gameObject.transform.Translate(Vector3.right * _cameraSpeed * Time.deltaTime);
            }
        }
    }
}

