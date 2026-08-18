using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Entrar()
    {
        SceneManager.LoadScene(1);
    }

    public void Sair()
    {
        Application.Quit();
    }
}