using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    private Camera cam;
    [SerializeField] private float smooth;
    private float velocidadRotacion;
    CharacterController controller;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
        
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
           
            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion, smooth);

            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);


            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);

            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

        ///controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);


    }
}
