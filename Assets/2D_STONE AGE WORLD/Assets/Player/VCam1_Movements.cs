using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCam1_Movements : MonoBehaviour
{
    public CinemachineVirtualCamera vCam1;
    private CinemachineFramingTransposer framingTransposer;
    private float vCamPos = 0.2f;

    void Start()
    {
        framingTransposer = vCam1.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0)
        {
            vCamPos = Mathf.Clamp(vCamPos + 0.003f, 0.2f, 0.7f);
            framingTransposer.m_ScreenX = vCamPos;
        }
        else if (horizontal > 0)
        {
            vCamPos = Mathf.Clamp(vCamPos - 0.003f, 0.2f, 0.7f);
            framingTransposer.m_ScreenX = vCamPos;
        }
    }
}
