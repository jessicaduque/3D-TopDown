using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorFases : MonoBehaviour
{
    public int faseAtual;

    private void Start()
    {
        if(faseAtual > 0 && faseAtual < 4)
        {
            PlayerPrefs.SetInt("FASE", faseAtual);
        }
        
    }

    public void Fase(int numeroFase)
    {
        SceneManager.LoadScene(numeroFase);
    }



    public void PassarFase()
    {
        int pFase = faseAtual + 1;
        SceneManager.LoadScene(pFase);
    }

    public void IrParaFaseSalva()
    {
        int fSave = PlayerPrefs.GetInt("FASE");
        SceneManager.LoadScene(fSave);
    }

}
