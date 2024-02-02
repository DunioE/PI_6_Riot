using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public GameObject videoPlayerObject;
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = videoPlayerObject.GetComponent<VideoPlayer>();
        videoPlayerObject.SetActive(false);

        // Adiciona um listener para o evento de conclusão do vídeo
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            videoPlayerObject.SetActive(true);
            videoPlayer.Play();
        }
    }

    // Método chamado quando o vídeo atinge o ponto de conclusão
    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the main menu scene (index 0)
        SceneManager.LoadScene(0);
    }
}
