using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro : MonoBehaviour
{

    public GameObject AreaDeAtk;
    // Start is called before the first frame update


    public void AtivarAtk()
    {
        AreaDeAtk.SetActive(true);
    }

    public void DesativarAtk()
    {
        AreaDeAtk.SetActive(false);
    }

}
