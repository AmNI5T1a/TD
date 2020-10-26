using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TD_game
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                _instance = (T)FindObjectOfType(typeof(T));

                if (_instance == null)
                {
                    GameObject vumAsObject = new GameObject();
                    _instance = vumAsObject.AddComponent<T>();
                    vumAsObject.name = "VirtualInputManager";
                }
                return _instance;
            }
        }
    }
}