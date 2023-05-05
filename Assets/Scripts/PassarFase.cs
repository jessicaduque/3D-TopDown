using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassarFase : MonoBehaviour
{



    private void OnTriggerEnter(Collider colidiu)
    {
        if(colidiu.gameObject.tag == "Player")
        {
            GetComponent<GerenciadorFases>().PassarFase();
        }
    }


}
