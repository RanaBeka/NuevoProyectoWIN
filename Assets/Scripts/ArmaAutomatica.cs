using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : MonoBehaviour
{

    private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
    private Camera cam;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        timer = misDatos.cadenciaAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
       if(Input.GetMouseButton(0) && timer >= misDatos.cadenciaAtaque)
        {
            system.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                Debug.Log(hitInfo.transform);

                hitInfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(misDatos.danhoAtaque);
            }
        }
    }
}
