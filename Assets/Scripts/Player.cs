using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    //varijable
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSmoother;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject playerObject;
    [SerializeField] ParticleSystem gunShot;
    [SerializeField] GameObject bulletSpawn;
    [SerializeField] GameObject bullet;
    Vector3 mousePos;
    private bool hasCollided = false;
    public float points;
    float highScore;
    [SerializeField] float health, maxHealth;
    [SerializeField] Slider slider;
    [SerializeField] float fireRate = 8, timeToShoot = 0f;
    [SerializeField] AudioClip gunSound;
    AudioSource audioSource;


    //metode
    void Start()
    {
        points = 0;
        health = maxHealth;
        slider.value = CalculateHealth();
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
    }
    void Update()
    {
        highScore = PlayerPrefs.GetInt("highscore");

        timeToShoot += Time.deltaTime;

        MouseLook();

        Move();

        //pucanje
        if (Input.GetMouseButton(0) && timeToShoot >= 1/fireRate)
            Shoot();

        if (health <= 0)
            Die();

        hasCollided = false;

        score.text = "Score: " + points.ToString();

        slider.value = CalculateHealth();

        if(points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetInt("highscore", (int)highScore);
            PlayerPrefs.Save();
        }
    }

    void Shoot()
    {
        Instantiate(bullet.transform, bulletSpawn.transform.position, playerObject.transform.rotation);
        audioSource.PlayOneShot(gunSound);
        timeToShoot = 0f;
    }

    void OnCollisionEnter(Collision hitted)
    {
        if(hitted.gameObject.tag == "Enemy" && hasCollided == false)
        {
            hasCollided = true;
            health -= 5;
            Destroy(hitted.gameObject);
        }
    }

    void OnTriggerEnter(Collider hitted)
    {
        if (hitted.gameObject.tag == "Enemy" && hasCollided == false)
        {
            hasCollided = true;
            health -= 5;
            Destroy(hitted.gameObject);
        }
    }

        void MouseLook()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDist = 0f;

        //player je okrenut prema misu
        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0f;
            targetRotation.z = 0f;
            playerObject.transform.rotation = Quaternion.Slerp(playerObject.transform.rotation, targetRotation, rotationSmoother * Time.deltaTime);
        }
    }

    void Move()
    {
        //kretanje
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
    }

    void Die()
    {
        FindObjectOfType<GameManager>().GameOver();
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
