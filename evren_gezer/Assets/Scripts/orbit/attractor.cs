using UnityEngine;

public class attractor : MonoBehaviour
{
    public int segments;
    public float radius;
    public Rigidbody2D rb = null;
    public float forceMultiplier = 0;

    private GameObject shipObj = null;
    private Rigidbody2D shipRb = null;
    private LineRenderer line;
    private float range;

    private void Start()
    {
	    range = radius * transform.localScale.x;
        shipObj = GameObject.FindGameObjectWithTag("ship");
        shipRb = shipObj.GetComponent<Rigidbody2D>();
        line = transform.Find("GravitationalField").gameObject.GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        CreatePoints();
    }


    private void FixedUpdate()
    { 
        if (shipObj != null && Vector2.Distance(transform.position, shipObj.transform.position) < range)
        {
            Debug.Log(gameObject.name);
            Vector3 gravity = calcGravity();
            shipRb.AddForce(gravity);
        }
    }


    Vector3 calcGravity()
    {
        Vector3 direction = rb.position - shipRb.position;
        float distance = direction.magnitude;
        float forceMagnitude = (rb.mass * shipRb.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;
        return force * forceMultiplier;
    }

    private void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }

    }
}
