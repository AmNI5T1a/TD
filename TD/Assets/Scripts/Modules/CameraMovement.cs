using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD_game
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _cameraSpeed = 10;

        void Update()
        {
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
                this.gameObject.transform.Translate(-Vector3.right* _cameraSpeed * Time.deltaTime);
            }
            if (VirtualInputManager.Instance.MoveRight)
            {
                this.gameObject.transform.Translate(Vector3.right * _cameraSpeed * Time.deltaTime);
            }
        }
    }
}

