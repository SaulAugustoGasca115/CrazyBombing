using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{

    [Header("Player Attributes")]
    [SerializeField]
    private float Speed = 8.0f;
    private float rotationSpeed = 30.0f;
    public GameObject laserPrefab;
    public Vector2 movement;
    public Rigidbody2D rb;
    public Transform firePoint;

    [Header("Shoot Coolddown")]
    public float fireRate = 0.15f;
    public float canFire = 0.0f;

    
    public GameObject tripleShootPrefab;
    public bool canTripleShoot = false;

    //Audio Sources
    public AudioSource laserSoundFX;
    public AudioSource powerUp1SoundFX;
    public AudioSource tripleLaserSoundFX;
    public AudioClip playerDeathSoundFX;


    public int life = 3;
    public GameObject[] lifeImage;
    public GameObject explosionPrefab;


    public UIManager uiManager;

    Vector3 positionMouse;

    public bool playerDead = false;

    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        //lifeImage[0].gameObject.SetActive(true);
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        //spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        //if (spawnManager != null)
        //{
        //    //spawnManager.StartSpawnRoutines();
        //    //StartCoroutine(spawnManager.EnemySpawnRoutine());
        //}

    }

    // Update is called once per frame
    void Update()
    {

        GenerateLevelLimits();
        if (Input.GetMouseButton(0))
        {

            //Instantiate(laserPrefab, transform.position, transform.rotation);
            ShootBehaviour();
        }
    }

    private void FixedUpdate()
    {
        AffineMovement();

        

    }

    void Movement()
    {
        float translation = Input.GetAxis("Vertical") * Speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.fixedDeltaTime;
        rotation *= Time.fixedDeltaTime;


        

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,mousePosition.y - transform.position.y);


        transform.up = direction;

        transform.Translate(new Vector3(0,translation,0));


    }


    void GenerateLevelLimits()
    {
        if(transform.position.x < -22.0f)
        {
            transform.position = new Vector3(22f,transform.position.y,0);

        }else if(transform.position.x > 14.0f)
        {
            transform.position = new Vector3(-14.0f,transform.position.y,0);

        }else if(transform.position.y < -13f)
        {
            transform.position = new Vector3(transform.position.x,13.0f,0);
        }
        else if (transform.position.y > 13f)
        {
            transform.position = new Vector3(transform.position.x, -13.0f, 0);
        }
    }


    public void AffineMovement()
    {
        float translationY = Input.GetAxis("Vertical") * Speed;
        float translationX = Input.GetAxis("Horizontal") * Speed;

        movement.x = Input.GetAxis("Horizontal") * Speed;
        movement.y = Input.GetAxis("Vertical") * Speed;

        

        positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        //AffineMousePosition();



        Vector2 lookDirection = positionMouse - transform.position;

        //if(Vector2.Distance(positionMouse,transform.position) > 3.0f)
        //{
        //    transform.Translate(movement * Time.fixedDeltaTime);

        //    float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        //    //transform.Rotate(0,0,angle);

        //    rb.rotation = angle;
        //}

        transform.Translate(movement * Time.fixedDeltaTime);

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;

        //transform.Rotate(0,0,angle);

        rb.rotation = angle;


    }

    void ShootBehaviour()
    {
        if(Time.time > canFire)
        {

            if(canTripleShoot == true)
            {
                //triple shoot
                Instantiate(tripleShootPrefab, transform.position, transform.rotation);

                tripleLaserSoundFX.Play();
                
            }
            else
            {
                //singel shoot
                Instantiate(laserPrefab, transform.position, transform.rotation);
                laserSoundFX.Play();
            }

            

            canFire = Time.time + fireRate;
        }
    }

    public void TripleShootPowerupOn()
    {
        canTripleShoot = true;

        powerUp1SoundFX.Play();

        StartCoroutine(TripleShootPowerUpRoutine());

    }

    public IEnumerator TripleShootPowerUpRoutine()
    {
        yield return new WaitForSeconds(6.0f);

        canTripleShoot = false;
    }


    public void PlayerLifeCount()
    {
        //life--;

        //for(int i = life;i<life;i--)
        //{
        //    lifeImage[i].gameObject.SetActive(false);
        //}

        //life--;

        //lifeImage[0].gameObject.SetActive(false);



        //for(int i = 0;i<lifeImage.Length;i++)
        //{

        //    if(lifeImage.Length == 0)
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

        life--;

        if(life == 2)
        {
            lifeImage[2].SetActive(false);
            //playerDead = true;

        }else if(life == 1)
        {
            lifeImage[1].SetActive(false);

        }
        else if(life == 0)
        {
                if(playerDead == false)
                {
                    lifeImage[0].SetActive(false);
                    Destroy(this.gameObject);
                    AudioSource.PlayClipAtPoint(playerDeathSoundFX, Camera.main.transform.position, 1.0f);
                    Instantiate(explosionPrefab, transform.position, transform.rotation);
                    uiManager.conditionPanels[1].SetActive(true);
                    uiManager.conditionPanels[0].SetActive(false);
                    uiManager.StopTime();
                    //spawnManager.OwnStop();
                    playerDead = true;
                   // spawnManager.StopCoroutine("EnemySpawnRoutine");
                }
                
            
           
        }
        

        //if (life < 1)
        //{
        //    Destroy(this.gameObject);
        //}

    }


    public void ChangeColorOn()
    {
        transform.GetComponent<Renderer>().material.color = Color.green;

        StartCoroutine(ChangeColorRoutine());
    }

    public IEnumerator ChangeColorRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        transform.GetComponent<Renderer>().material.color = Color.white;
    }


    public void AffineMousePosition()
    {
        if(positionMouse.x >= 14.0f)
        {
            positionMouse.Set(-14.0f,positionMouse.y,positionMouse.z);
        }
    }


}
