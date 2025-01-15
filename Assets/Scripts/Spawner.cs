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
        StartCoroutine(SpawnEnemigos());
    }

    private IEnumerator SpawnEnemigos()
    {
        while (true)
        {
            Enemigo slenderman = Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(22);

        }
        
        
    }
}
