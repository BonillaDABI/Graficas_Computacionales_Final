//Scrip Movimiento
//Ivan Eloy Bonilla Gameros A00826077
//Alan Lespron A01194016
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 3.0f; // La velocidad a la que se mueve el personaje
    private Animator animator; // Referencia al componente Animator

    void Start()
    {
        // Obtiene el componente Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Obtiene el input horizontal y vertical (WASD o teclas de flecha)
        float horizontal = Input.GetAxis("Horizontal"); // A/D o Flecha Izquierda/Derecha
        float vertical = Input.GetAxis("Vertical"); // W/S o Flecha Arriba/Abajo

        // Crea un nuevo vector para almacenar la dirección del movimiento
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // Si hay algún input (es decir, si el jugador está presionando una tecla)
        if (movement != Vector3.zero)
        {
            // Establece el parámetro isWalking a verdadero
            animator.SetBool("isWalking", true);

            // Rota el personaje en la dirección del movimiento
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

            // Mueve el personaje
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        else
        {
            // Si no hay input (es decir, si el jugador no está presionando ninguna tecla)
            // Establece el parámetro isWalking a falso
            animator.SetBool("isWalking", false);
        }
    }
}
