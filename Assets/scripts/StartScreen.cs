using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class StartScreen : MonoBehaviour
{
    // Sound stuff
    public float maxVolume = 1f;
    public float minVolume = 0f;

    public float fadeOutDuration = 2f;
    public IEnumerator fadeOut;
    private AudioSource source;
    public Component music;
    public static StartScreen instance;

    Animator anim;
    public GameObject dagger;

    private void Start()
    {
        anim = dagger.GetComponent<Animator>();
    }

    public void GoNewScene()
    {
        anim.Play("LogoAnim");
    }

    public void Test()
    {
        SceneManager.LoadScene(1);
    }
}