using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private Enemigo enemigoPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemigoPrefab, puntosSpawn, Quaternion.identity);
    }

   
}
