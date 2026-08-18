using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Void") || other.CompareTag("Obstaculo"))
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}