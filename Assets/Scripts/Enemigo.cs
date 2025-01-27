using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vidas;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;

    private NavMeshAgent agent;
    private FirstPerson player;
    private Animator anim;
    private bool ventanaAbierta;
    private bool danhoRealizado;
    private Rigidbody[] huesos;

    public float Vidas { get => vidas; set => vidas = value; }
    public float DanhoAtaque { get => danhoAtaque; set => danhoAtaque = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        huesos = GetComponentsInChildren<Rigidbody>();
        player = GameObject.FindObjectOfType<FirstPerson>();

        CambiarEstadoHuesos(true);
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();
        if(ventanaAbierta && danhoRealizado == false )
        {
            DetectarJugador();
        }
    }
    
    private void DetectarJugador()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsDanhable);
        if (collsDetectados.Length > 0 )
        {
            Debug.Log("1");
            for (int i = 0; i < collsDetectados.Length; i++)
            {
                collsDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoAtaque);
                Debug.Log("2");
            }
            Debug.Log("3");
            danhoRealizado = true;
        }
    }
    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("attacking", true);
            EnfocarPlayer();
        }
    }
    private void FinAtaque()
    {
        agent.isStopped = false;
        danhoRealizado = false;
        anim.SetBool("attacking", false);

    }
    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
    }
    private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;
        FinAtaque();
    }
    public void Morir()
    {
        agent.enabled = false;
        anim.enabled = false;
        CambiarEstadoHuesos(false);
        Destroy(gameObject, 10);
    }

    private void CambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }

    private void EnfocarPlayer()
    {
        Vector3 direccionAPlayer = (player.transform.position - this.gameObject.transform.position).normalized;
        Quaternion.LookRotation(direccionAPlayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(204, 0, 153);
        Gizmos.DrawSphere(attackPoint.position, radioAtaque);
    }
}
