using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Attributes")]
    public GameObject enemiesPrefab;
    public GameObject[] powerupsPrefab;



    // Start is called before the first frame update
    void Start()
    {
        EnemySpawnOn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spawn Coroutines
    public void EnemySpawnOn()
    {
        StartCoroutine(EnemySpawnRoutine());
    }

    public IEnumerator EnemySpawnRoutine()
    {
        while(true)
        {
            Instantiate(enemiesPrefab, new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);

            yield return new WaitForSeconds(5.0f);
        }
    }


}
