using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace HilamPrototype
{
    public class CameraShake : Singleton<CameraShake>
    {
        [SerializeField] Camera gameCamera;
        [SerializeField] CinemachineVirtualCamera virtualCamera;
        float shakeTimer;
        float shakeTimerTotal;

        float startingIntensity;
        [Space(2)]
        [Header("Slow Shake")]
        [SerializeField] float slowShakeIntensity;
        [SerializeField] float slowShakeTime;
        [Header("Middle Shake")]
        [SerializeField] float middleShakeIntensity;
        [SerializeField] float middleShakeTime;
        [Header("Fast Shake")]
        [SerializeField] float fastShakeIntensity;
        [SerializeField] float fastShakeTime;

        public void ShakeCameraSlow()
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = slowShakeIntensity;
            shakeTimer = slowShakeTime;
            shakeTimerTotal = shakeTimer;
            startingIntensity = slowShakeIntensity;
        }
        public void ShakeCameraMiddle()
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = middleShakeIntensity;
            shakeTimer = middleShakeTime;
            shakeTimerTotal = shakeTimer;
            startingIntensity = middleShakeIntensity;
        }
        public void ShakeCameraFast()
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = fastShakeIntensity;
            shakeTimer = fastShakeTime;
            shakeTimerTotal = shakeTimer;
            startingIntensity = fastShakeIntensity;
        }
        public void ShakeCameraCustom(float shakeIntensity, float shakeTime)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = shakeIntensity;
            shakeTimer = shakeTime;
            shakeTimerTotal = shakeTimer;
            startingIntensity = shakeIntensity;
        }
        void StopCameraShake()
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeTimerTotal));

        }
        void Update()
        {
            if (shakeTimer > 0)
            {
                shakeTimer -= Time.deltaTime;
                StopCameraShake();
            }

        }
    }
}

