using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TrocarCena : MonoBehaviour
{
    // Este método será chamado quando o botão for clicado
    public void TrocarParaCena0()
    {
        // Troca para a cena com índice 0
        SceneManager.LoadScene(0);
    }
}
