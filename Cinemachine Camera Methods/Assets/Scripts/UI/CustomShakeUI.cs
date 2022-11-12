using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HilamPrototype
{
    public class CustomShakeUI : MonoBehaviour
    {
        [Header("Sliders")]
        [SerializeField] Slider timeSlide;
        [SerializeField] Slider powerSlide;

        [Header("Values")]
        [SerializeField] float time;
        [SerializeField] float power;

        void Update()
        {

            timeSlide.onValueChanged.AddListener(delegate { time = timeSlide.value; });
            powerSlide.onValueChanged.AddListener(delegate { power = powerSlide.value; });
            
        }

        public void ApplyShake() 
        {
            CameraShake.Instance.ShakeCameraCustom(power,time);
        }
    }
}
