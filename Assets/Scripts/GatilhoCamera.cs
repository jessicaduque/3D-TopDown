using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatilhoCamera : MonoBehaviour
{
    public int numeroCam;
    public ControladorDeCameras ConCam;

    private void OnTriggerEnter(Collider gatilho)
    {
        if(gatilho.gameObject.tag == "Player")
        {
            ConCam.AtivarCam(numeroCam);
        }
    }

}
