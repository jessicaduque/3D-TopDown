using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorFases : MonoBehaviour
{
    public int faseAtual;

    public void Fase(int numeroFase)
    {
        SceneManager.LoadScene(numeroFase);
    }

    public void PassarFase()
    {
        int pFase = faseAtual + 1;
        SceneManager.LoadScene(pFase);
    }
}
