using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    Animator anim;
    public GameObject dagger;
    private void Start()
    {
        anim = dagger.GetComponent <Animator> ();
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
