using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI1 : MonoBehaviour
{

    [Header("Enemy1 Attributes")]
    public float Speed = 4.0f;
    public float lifes = 3.0f;
    public AudioClip enemyDeathSoundFX;
    public AudioClip playerDeathSoundFX;
   

    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 3; i < lifeImage.Length; i--)
        //{

        //    if (lifeImage.Length == 0)
        //    {
        //        lifeImage[i].gameObject.SetActive(false);
        //    }

        //    if (lifeImage.Length == 1)
        //    {
        //        lifeImage[i].gameObject.SetActive(false);
        //    }

        //    if (lifeImage.Length == 2)
        //    {
        //        lifeImage[i].gameObject.SetActive(false);
        //    }

        //}

       

    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(transform.position.y <= -12.8f)
        {
            transform.position = new Vector3(Random.Range(-17.4f,17.4f),13.85f,0);
        }


    }

    void Movement()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {

            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }

            Destroy(other.gameObject);

            LifeCount();


            ChangeColorOn();


        }

        if(other.tag == "Player")
        {

            PlayerMove player = other.GetComponent<PlayerMove>();

            if (player != null)
            {
                //Destroy(other.gameObject);
                player.PlayerLifeCount();
                //AudioSource.PlayClipAtPoint(playerDeathSoundFX, Camera.main.transform.position, 1.0f);
                player.ChangeColorOn();
            }



            


        }
    }

    public void LifeCount()
    {
        lifes--;

        if(lifes < 1)
        {
            
            AudioSource.PlayClipAtPoint(enemyDeathSoundFX,Camera.main.transform.position,1.0f);
            Destroy(this.gameObject);
        }
    }

    public void ChangeColorOn()
    {
        transform.GetComponent<Renderer>().material.color = Color.red;

        StartCoroutine(ChangeColorRoutine());
    }

    public IEnumerator ChangeColorRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        transform.GetComponent<Renderer>().material.color = Color.green;
    }


}
