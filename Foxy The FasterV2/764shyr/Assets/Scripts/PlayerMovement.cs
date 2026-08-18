using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidadePadrao = 5f;
    public float velocidadeMaxima = 10f;
    public float aumentoVelocidade = 0.5f;

    public float forcaPulo = 7f;

    private float velocidadeAtual;
    private Rigidbody2D rb;
    private int pulos = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        velocidadeAtual = velocidadePadrao;
    }

    void Update()
    {
        // Aumenta a velocidade com o tempo
        velocidadeAtual += aumentoVelocidade * Time.deltaTime;

        // Impede que ultrapasse a velocidade máxima
        velocidadeAtual = Mathf.Min(velocidadeAtual, velocidadeMaxima);

        // Movimento para esquerda e direita
        float movimento = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(
            movimento * velocidadeAtual,
            rb.linearVelocity.y
        );

        // Pulo e Double Jump
        if (Input.GetKeyDown(KeyCode.Space) && pulos < 2)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                forcaPulo
            );

            pulos++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reseta os pulos quando tocar no chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            pulos = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Bebida reseta a velocidade
        if (other.CompareTag("Bebida"))
        {
            velocidadeAtual = velocidadePadrao;

            Destroy(other.gameObject);
        }
    }
}