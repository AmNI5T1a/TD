using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TD_game
{
    public class FinishLine : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {

            if (other.tag == "Enemy")
            {
                Debug.Log("Triggered by Enemy");
                Destroy(other.gameObject, 1f);
            }
            else
            {
                Debug.LogWarning("Triggered by another object");
            }
        }
    }
}
