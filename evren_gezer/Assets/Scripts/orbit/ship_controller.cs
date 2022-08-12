using UnityEngine;
using UnityEngine.UI;

public class ship_controller : MonoBehaviour
{
    public Transform mainNozzle = null;
    public float mainNozzleForce;
    public float rotationSensitivity;
    public float rotationSmoothTime;
    public float range;
    public float fireRate;
    public GameObject missile;
    public GameObject bullet;
    public GameObject brakeParticlesLeft;
    public GameObject brakeParticlesRight;
    public Image[] images;

    private Transform head;
    private Rigidbody2D rb = null;
    private Vector3 currentRotation;
    private Vector3 rotationSmoothVelocity;
    private float dirX;
    private float dirY;
    private float yaw;
    private float nextFire;
    private bool hasRocket;

    private void Start()
    {
        hasRocket = true;
        brakeParticlesLeft.SetActive(false);
        brakeParticlesRight.SetActive(false);
        head = transform.Find("HeadOfRocket");
        rb = GetComponent<Rigidbody2D>();
        nextFire = Time.time;
    }

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxis("Vertical");
        if (Input.GetKeyDown("space"))
        {
            if (hasRocket)
            {
                GameObject[] targets = GameObject.FindGameObjectsWithTag("EnemyShip");
                for (int i = 0; i < targets.Length; i++)
                {
                    if (!hasRocket)
                    {
                        break;
                    }
                    GameObject target = targets[i];
                    if (Vector2.Distance(transform.position, target.transform.position) < range)
                    {
                        GameObject instantiatedMissile = Instantiate(missile, transform.position, Quaternion.identity);
                        HomingMissile homingMissileScript = instantiatedMissile.GetComponent<HomingMissile>();
                        homingMissileScript.target = target.transform;
                        homingMissileScript.speed = 5;
                        homingMissileScript.rotateSpeed = 200;
                        for (int j = images.Length - 1; j >= 0; j--)
                        {
                            Debug.Log("Here1");
                            if (images[j].isActiveAndEnabled)
                            {
                                images[j].enabled = false;
                                break;
                            }
                        }
                        if (!images[0].isActiveAndEnabled)
                        {
                            hasRocket = false;
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextFire)
            {
                Instantiate(bullet, head.position, Quaternion.identity).transform.up = transform.up;
                nextFire = Time.time + fireRate;
            }
        }
    }

    private void FixedUpdate()
    {
        if (dirY > 0)
        {
            Vector3 mainForceDir = transform.up * dirY * mainNozzleForce;
            if (brakeParticlesLeft.activeSelf && brakeParticlesRight.activeSelf)
            {
                brakeParticlesLeft.SetActive(false);
                brakeParticlesRight.SetActive(false);
            }
            rb.AddForceAtPosition(mainForceDir, mainNozzle.position);
        }
        else if(dirY < 0)
        {
            Vector3 brakeForceDir = rb.velocity.normalized * dirY * mainNozzleForce;
            if (!brakeParticlesLeft.activeSelf && !brakeParticlesRight.activeSelf)
            {
                brakeParticlesLeft.SetActive(true);
                brakeParticlesRight.SetActive(true);
            }
            rb.AddForceAtPosition(brakeForceDir, transform.position);
        }
        else
        {
            if (brakeParticlesLeft.activeSelf && brakeParticlesRight.activeSelf)
            {
                brakeParticlesLeft.SetActive(false);
                brakeParticlesRight.SetActive(false);
            }
        }
    }

    private void LateUpdate()
    {
        yaw -= dirX * rotationSensitivity;

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(0, 0, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;
    }
}
