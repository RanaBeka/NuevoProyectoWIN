using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaMunicion : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cerrada()
    {
        anim.SetTrigger("cerrada");
    }
    public void abrir()
    {
        anim.SetTrigger("abrir");
        
    }
    public void cerrar()
    {
        anim.SetTrigger("cerrar");
        
    }
}
