using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class granada : MonoBehaviour
{
   
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private float tiempoVida;
    [SerializeField] private float radioExplosion;
    [SerializeField] private LayerMask queEsDanhable;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody>().AddForce(transform.forward * fuerzaImpulso, ForceMode.Impulse);
        Destroy(gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
       /// Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        

       Collider[] collsDetectadps = Physics.OverlapSphere(transform.position, radioExplosion, queEsDanhable);
    
        if(collsDetectadps.Length > 0 )
        {
            foreach (Collider coll in collsDetectadps)
            {
                coll.GetComponent<ParteDeEnemigo>().Explotar();
                coll.GetComponent<Rigidbody>().isKinematic = false;


                coll.GetComponent<Rigidbody>().AddExplosionForce(50, transform.position, radioExplosion, 3.5f);


            }

            Debug.Log("A mimir");
        }
    
    }
}
