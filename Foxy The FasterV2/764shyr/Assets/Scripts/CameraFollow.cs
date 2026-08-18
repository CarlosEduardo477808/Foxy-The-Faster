using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jogador;
    public float suavidade = 5f;
    public float deslocamentoY = -2f;

    void LateUpdate()
    {
        Vector3 novaPosicao = new Vector3(
            jogador.position.x,
            jogador.position.y + deslocamentoY,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            novaPosicao,
            suavidade * Time.deltaTime
        );
    }
}