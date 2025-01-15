using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaInteracciones : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distanciaInteraccion;
    [SerializeField] private Transform interactuableActual;
    private bool interactuado = false;
    public int coleccionable;
    void Start()
    {
        cam = Camera.main;
        
    }
    void Update()
    {
        if (coleccionable >= 3)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }



        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion))
        {
            if (hit.transform.TryGetComponent(out CajaMunicion scriptCaja))
            {
                if (hit.transform.CompareTag("Coleccionable"))
                {
                    Recoger();
                }
                interactuableActual = hit.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E) && interactuado == false)
                {
                    
                   
                         scriptCaja.abrir();
                    







                    interactuado = true;

                }
                else if (Input.GetKeyDown(KeyCode.E) && interactuado == true)
                {
                    scriptCaja.cerrar();
                    interactuado = false;
                }
            }

        }
        else if (interactuableActual)
        {
            interactuableActual.GetComponent<Outline>().enabled = false;
            interactuableActual = null;

        }

        
               
                
            

        
    }

    private void Recoger()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion))
            {
                if (hit.transform.CompareTag("Coleccionable"))
                {
                        coleccionable++;
                    GameObject objetointeract = hit.collider.gameObject;
                    Destroy(objetointeract);
                    }
            }
        }

            
    }
}

