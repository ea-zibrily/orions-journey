using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinemaShake : MonoBehaviour
{
    public static cinemaShake Instance { get; private set; }
    CinemachineVirtualCamera cinemaVirCam;
    float shakeTimer;
    float shakeTimerTotal;
    float startingIntensity;

    private void Awake()
    {
        Instance = this;
        cinemaVirCam = GetComponent<CinemachineVirtualCamera>();
    }
   
    // Update is called once per frame
    void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemaBasMult =
                    cinemaVirCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemaBasMult.m_AmplitudeGain = 
                    Mathf.Lerp(startingIntensity, 0f, shakeTimer / shakeTimerTotal);
            }
        }
    }

    public void shakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemaBasMult = 
            cinemaVirCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemaBasMult.m_AmplitudeGain = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }
}
