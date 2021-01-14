using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD_game
{
    public class KeyboardInputManager : MonoBehaviour
    {

        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                VirtualInputManager.Instance.MoveFront = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveFront = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                VirtualInputManager.Instance.MoveBack = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveBack = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.MoveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveLeft = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.MoveRight = true;
            }
            else
            {
                VirtualInputManager.Instance.MoveRight = false;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                VirtualInputManager.Instance.LeftClickMouse = true;
            }
            else
            {
              VirtualInputManager.Instance.LeftClickMouse = false;  
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                VirtualInputManager.Instance.RightClickMouse = true;
            }
            else
            {
              VirtualInputManager.Instance.RightClickMouse = false;  
            }
        }
    }
}

