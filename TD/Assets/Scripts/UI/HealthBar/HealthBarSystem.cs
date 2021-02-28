using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD_game
{
    public class HealthBarSystem : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private Slider _healthBarSlider;
        [SerializeField] private GameObject _cameraToFollow;

        void Start()
        {
            _cameraToFollow = GameObject.Find("Main Camera");

            if (_cameraToFollow == null)
                ShowErrorToConsoleIfCameraNotFound();
        }
        void Update()
        {
            this.transform.LookAt(_cameraToFollow.transform);
        }

        private void ShowErrorToConsoleIfCameraNotFound()
        {
            Debug.LogError("Doesn't found definition for camera");
        }
    }
}
