using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D cuerpitorigido;
    private Vector3 cambio;
    private Animator perritoanimador;

    // Start is called before the first frame update
    void Start()
    {
        perritoanimador = GetComponent<Animator>();
        cuerpitorigido = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        cambio = Vector3.zero;
        cambio.x = Input.GetAxisRaw("Horizontal");
        cambio.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(cambio);
        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove()
    {
        if (cambio != Vector3.zero)
        {
            MoverPersonaje();
            perritoanimador.SetFloat("moveX", cambio.x);
            perritoanimador.SetFloat("moveY", cambio.y);
            perritoanimador.SetBool("moving", true);

        }
        else
        {
            perritoanimador.SetBool("moving", false);
        }

    }

    void MoverPersonaje()
    {

        cuerpitorigido.MovePosition(
            transform.position + cambio * velocidad * Time.deltaTime
            );
    }

}
