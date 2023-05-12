using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeCameras : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;

    public int cameraAtiva = 1;
    public int cameraAnterior = 1;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarCam(int nCam)
    {
        if (nCam != cameraAtiva)
        {
            switch (nCam)
            {
                case 1:
                    Cam1.SetActive(true);
                    cameraAtiva = 1;
                    DesativarCam();
                    break;
                case 2:
                    Cam2.SetActive(true);
                    cameraAtiva = 2;
                    DesativarCam();
                    break;
            }
        }
    }

    public void DesativarCam()
    {
        switch (cameraAnterior)
        {
            case 1:
                Cam1.SetActive(false);
                cameraAnterior = cameraAtiva;
                break;
            case 2:
                Cam2.SetActive(false);
                cameraAnterior = cameraAtiva;
                break;
        }
    }

}
