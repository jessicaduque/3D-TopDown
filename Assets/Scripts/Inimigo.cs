using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public int hp = 10;
  

    private void OnTriggerEnter(Collider colidiu)
    {
        if(colidiu.gameObject.tag == "Ataque")
        {
            TomeiDano();
        }
    }

    public void TomeiDano()
    {
        hp--;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
