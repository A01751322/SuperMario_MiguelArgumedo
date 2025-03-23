/**
Controla el movimiento que tiene el personaje de Mario
Autor: Miguel Angel Argumedo
*/
using UnityEngine;

public class MuevePersonaje : MonoBehaviour
{

    // transform, gameObject, 
    
    // Velocidades
    public float velocidadX;

    [SerializeField]

    private float velocidadY;

    // Rigidbody para la física
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");
        
        if (movVertical > 0)
        {
            rb.linearVelocity = new Vector2(movHorizontal * velocidadX, movVertical * velocidadY);

        } else {
            rb.linearVelocity = new Vector2(movHorizontal * velocidadX,rb.linearVelocityY);
        }

    }

}