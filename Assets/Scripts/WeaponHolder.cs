using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;
    int indiceArmaActual = 0;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarArmaConTeclado();
        CambiarArmaConRaton();
    }

    private void CambiarArmaConRaton()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        
        if (scrollWheel > 0)
        {
            CambiarArma(indiceArmaActual - 1);
        }
        else if (scrollWheel < 0)
        {
            CambiarArma(indiceArmaActual + 1);
        }

    }

    private void CambiarArmaConTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambiarArma(1);
        }
        
    }

    private void CambiarArma(int nuevoIndice)
    {
        

        if(nuevoIndice >= 0 && nuevoIndice < armas.Length)
        {
            armas[indiceArmaActual].SetActive(false);

            indiceArmaActual = nuevoIndice;

            armas[indiceArmaActual].SetActive(true);
        }
    }
}
