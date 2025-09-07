using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 10f;
    public float projectileSpeed = 20f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(h, 0f, v);
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Fire1"))
        {
            FireProjectile(Color.yellow);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            FireProjectile(Color.red);
        }
    }

    void FireProjectile(Color color)
    {
        GameObject projectile = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        projectile.transform.position = transform.position + transform.forward;
        Rigidbody rb = projectile.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = transform.forward * projectileSpeed;
        Renderer renderer = projectile.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
        Destroy(projectile, 5f);
    }
}
