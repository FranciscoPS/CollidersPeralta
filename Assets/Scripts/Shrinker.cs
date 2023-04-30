using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Shrinker : MonoBehaviour
{
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out HarryController player))
        {
            //Obtenemos el tamaño original que tenía el player
            var originalSize = player.GetOriginalSize();
            //Obtenemos el collider del player
            var playerCollider = player.GetComponent<CapsuleCollider>();

            //Validamos si  tiene su tamaño original, esto significaría que hay que reducirlo
            if (player.transform.localScale == originalSize)
            {
                //Cambiamos el tamaño del jugador a la mitad
                player.transform.localScale /= 2f;


                /////////// MOVER AL JUGADOR HACIA ADELANTE PARA QUE NO VUELVA A TOCAR EL COLLIDER///////////


                //Estamos calculando la relación entre la magnitud del tamaño original del jugador (originalSize)
                //la magnitud de su tamaño actual después de ser escalado (player.transform.localScale).
                //Esto nos da un valor que podemos usar para ajustar la posición del jugador después de ser escalado,
                //para evitar que quede atrapado dentro del collider de la puerta.
                //Con factor nos referimos a la relación entre el tamañno original y el tamaño redecido
                float factor = originalSize.magnitude / player.transform.localScale.magnitude;

                //Luego, calculamos la distancia que debe moverse el jugador hacia adelante
                //para evitar que quede atrapado dentro del collider de la puerta. 
                Vector3 distancia = Vector3.forward * (transform.position.z - player.transform.position.z) * factor;

                //Finalmente, actualizamos la posición del jugador sumando la distancia calculada:
                player.transform.position += distancia;
            }
            else
            {  
                player.transform.localScale = originalSize;
            }
        }
    }

}
