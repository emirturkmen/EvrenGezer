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
    public GameObject smokeEffect;
    public GameObject flameEffect;
    public Image[] images;
    public GameObject healthBar;
    public GameObject fuelBar;

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
        SaveLoad.Load();
        transform.position = new Vector3(SaveData.shipPosition[0], SaveData.shipPosition[1], SaveData.shipPosition[2]);
        transform.rotation = Quaternion.Euler(SaveData.shipRotation[0], SaveData.shipRotation[1], SaveData.shipRotation[2]);
        Bar_controller fuelBarScript = fuelBar.gameObject.GetComponent<Bar_controller>();
        Bar_controller healthBarScript = healthBar.gameObject.GetComponent<Bar_controller>();
        
        fuelBarScript.setFillRate(SaveData.fuel);
        healthBarScript.setFillRate(SaveData.health);
        hasRocket = true;
        brakeParticlesLeft.SetActive(false);
        brakeParticlesRight.SetActive(false);
        flameEffect.SetActive(false);
        head = transform.Find("HeadOfRocket");
        rb = GetComponent<Rigidbody2D>();
        nextFire = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            float[] shipPosition = {transform.position.x, transform.position.y, transform.position.z};
            Debug.Log(shipPosition[0]);
            Debug.Log(shipPosition[1]);
            Debug.Log(shipPosition[2]);
            SaveData.shipPosition = shipPosition;
            float[] shipRotation = {transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z};
            Debug.Log(shipRotation[0]);
            Debug.Log(shipRotation[1]);
            Debug.Log(shipRotation[2]);
            SaveData.shipRotation = shipRotation;
            SaveLoad.Save();
        }
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
            if (!flameEffect.activeSelf)
            {
                flameEffect.SetActive(true);
            }
            Vector3 mainForceDir = transform.up * dirY * mainNozzleForce;
            if (brakeParticlesLeft.activeSelf && brakeParticlesRight.activeSelf)
            {
                brakeParticlesLeft.SetActive(false);
                brakeParticlesRight.SetActive(false);
            }
            rb.AddForceAtPosition(mainForceDir, mainNozzle.position);
            ReduceFuel(0.05f);
        }
        else if(dirY < 0)
        {
            if (flameEffect.activeSelf)
            {
                flameEffect.SetActive(false);
            }
            Vector3 brakeForceDir = rb.velocity.normalized * dirY * mainNozzleForce;
            if (!brakeParticlesLeft.activeSelf && !brakeParticlesRight.activeSelf)
            {
                brakeParticlesLeft.SetActive(true);
                brakeParticlesRight.SetActive(true);
                brakeParticlesLeft.gameObject.transform.rotation = Quaternion.Euler((360 + Vector2.SignedAngle(new Vector2(-1, 0), rb.velocity)) % 360, -90, 90);
                brakeParticlesRight.gameObject.transform.rotation = Quaternion.Euler((360 + Vector2.SignedAngle(new Vector2(-1, 0), rb.velocity)) % 360, -90, 90);
            }
            rb.AddForceAtPosition(brakeForceDir, transform.position);
        }
        else
        {
            if (flameEffect.activeSelf)
            {
                flameEffect.SetActive(false);
            }
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

    public void ReduceHealth(int reduceAmount)
    {
        SaveLoad.Load();
        Bar_controller barScript = healthBar.gameObject.GetComponent<Bar_controller>();
        barScript.ReduceBar((float)reduceAmount / 100);
        SaveData.health -= (float)reduceAmount/100;
        Debug.Log(SaveData.health);
        SaveLoad.Save();
    }

    public void ReduceFuel(float reduceAmount)
    {
        SaveLoad.Load();
        Bar_controller barScript = fuelBar.gameObject.GetComponent<Bar_controller>();
        barScript.ReduceBar(reduceAmount / 100);
        SaveData.fuel -= (float)reduceAmount/100;
        Debug.Log(SaveData.fuel);
        SaveLoad.Save();
    }
}
