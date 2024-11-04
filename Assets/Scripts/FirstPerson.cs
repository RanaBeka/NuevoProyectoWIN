using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float vidas;
    

    [Header("Deteccion Suelo")]
    [SerializeField] private Transform pies;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsSuelo;

    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento;
    CharacterController controller;
    [SerializeField] float escalaGravedad;
    [SerializeField] private float alturaSalto;

    private Vector3 movimientoVertical;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Vector2 input = new Vector2(h, v).normalized;

        if (input.magnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }

        AplicarGravedad();
        DeteccionSuelo();
        ///controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);


    }
    private void AplicarGravedad()
    {
        movimientoVertical.y += escalaGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    
    }
    private void DeteccionSuelo()
    {
        
        Collider[] collsDetectados = Physics.OverlapSphere(pies.position, radioDeteccion, queEsSuelo);
        if (collsDetectados.Length > 0)
        {
            movimientoVertical.y = 0;
            Saltar();
        }
    }
    private void Saltar()
    {
       if ( Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(204, 0, 153);
        Gizmos.DrawSphere(pies.position, radioDeteccion);
    }
    private bool EnSuelo()
    {
        bool resultado = Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
        return resultado;

    }
    private void RecibirDanho(float danhoRecibido)
    {
        vidas -= danhoRecibido;
    }
}
