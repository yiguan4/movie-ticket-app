using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageNavigation : MonoBehaviour
{
    public void StartUpPage() {
        SceneManager.LoadScene("StartUpPage");

    }

    public void HomePage()
    {
        SceneManager.LoadScene("HomePage");

    }

    public void MoviesPage()
    {
        SceneManager.LoadScene("MoviesPage");

    }

    public void ProfilePage()
    {
        SceneManager.LoadScene("ProfilePage");

    }
}
