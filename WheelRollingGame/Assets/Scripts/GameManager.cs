using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float SkyboxSpeed;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * SkyboxSpeed);
    }
    public void PlayButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
