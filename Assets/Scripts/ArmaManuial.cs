using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManuial : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;
    public AudioSource aud;
    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ReproducirSonido(aud.clip);
            system.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                Debug.Log(hitInfo.transform);

                hitInfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(misDatos.danhoAtaque);
            }
        }
    }
    private void ReproducirSonido(AudioClip clip)
    {
        aud.PlayOneShot(clip);
    }
}
