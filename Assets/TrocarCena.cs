using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TrocarCena : MonoBehaviour
{
    // Este m�todo ser� chamado quando o bot�o for clicado
    public void TrocarParaCena0()
    {
        // Troca para a cena com �ndice 0
        SceneManager.LoadScene(0);
    }
}
