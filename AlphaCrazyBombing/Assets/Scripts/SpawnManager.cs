using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Attributes")]
    public GameObject enemiesPrefab;
    public GameObject[] powerupsPrefab;
    PlayerMove player;



    public IEnumerator coroutine;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMove>();


        //if(player != null)
        //{
        //    EnemySpawnOn();
        //    PowerupSpawnOn();
        //}

        EnemySpawnOn();
        PowerupSpawnOn();

        //print("Starting " + Time.time);
        //coroutine = EnemySpawnRoutine();
        //StartCoroutine(coroutine);
        //print("Done " + Time.time);


    }

    // Update is called once per frame
    void Update()
    {
        //if(player == null)
        //{
        //    StopAllCoroutines();
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    EnemySpawnOn();
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StopCoroutine("EnemySpawnRoutine");
        //    yield return null;
        //}


        //if (player.life < 1)
        //{
        //    StopCoroutine(coroutine);
        //    //print("Stopped " + Time.time);
        //}

        

    }

    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawnRoutine());
    }


    //Spawn Coroutines
    public void EnemySpawnOn()
    {
        StartCoroutine(EnemySpawnRoutine());
    }

    public IEnumerator EnemySpawnRoutine()
    {
        //while (true)
        //{
        //    Instantiate(enemiesPrefab, new Vector3(Random.Range(-12.0f, 12.0f), 13.15f, 0), Quaternion.identity);

        //    yield return new WaitForSeconds(3.5f);

        //    if(player.life < 1)
        //    {
        //        enemiesPrefab.SetActive(false);
        //        print("HEREEEEEEEEEEEEEEEEEEE");
        //    }

        //    yield return null;
        //}


        //if (player.playerDead == false)
        //{
        //    Instantiate(enemiesPrefab, new Vector3(Random.Range(-12.0f, 12.0f), 13.15f, 0), Quaternion.identity);

        //    yield return new WaitForSeconds(3.5f);
        //}

        //if(player != null)
        //{
        //    while (player.playerDead == false)
        //    {
        //        Instantiate(enemiesPrefab, new Vector3(Random.Range(-12.0f, 12.0f), 13.15f, 0), Quaternion.identity);

        //        yield return new WaitForSeconds(3.5f);
        //    }
        //}



        //if (player.life < 1)
        //{
        //    yield break;
        //}
        //else
        //{
        //    Instantiate(enemiesPrefab, new Vector3(Random.Range(-12.0f, 12.0f), 13.15f, 0), Quaternion.identity);

        //    yield return new WaitForSeconds(3.5f);
        //}

        
        while(true)
        {
            Instantiate(enemiesPrefab, new Vector3(Random.Range(-12.0f, 12.0f), 13.15f, 0), Quaternion.identity);

            yield return new WaitForSeconds(1.5f);
        }


    }


    public void OwnStop()
    {
        StopCoroutine(EnemySpawnRoutine());
    }



    public void PowerupSpawnOn()
    {
        StartCoroutine(PowerupRoutine());
    }

    public IEnumerator PowerupRoutine()
    {
        while(true)
        {
            Instantiate(powerupsPrefab[0], transform.position, Quaternion.identity);

            yield return new WaitForSeconds(10.0f);
        }
    }





    public IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
        }
    }











}
