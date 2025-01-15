using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distanciaInteraccion;
    [SerializeField] private Transform interactuableActual;
    private bool abierto = false;

    void Start()
    {
        cam = Camera.main;

    }
    void Update()
    {




        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion))
        {
            if (hit.transform.TryGetComponent(out CajaMunicion scriptCaja))
            {
                interactuableActual = hit.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E) && abierto == false)
                {
                    scriptCaja.abrir();

                    abierto = true;

                }
                else if (Input.GetKeyDown(KeyCode.E) && abierto == true)
                {
                    scriptCaja.cerrar();
                    abierto = false;
                }
            }

        }
        else if (interactuableActual)
        {
            interactuableActual.GetComponent<Outline>().enabled = false;
            interactuableActual = null;

        }


    }

}
