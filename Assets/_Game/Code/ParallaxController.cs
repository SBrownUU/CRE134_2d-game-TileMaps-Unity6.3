using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float length, startposX, startposY;
    public GameObject cam;
    public float parallaxEffectX;
    public float parallaxEffectY;

    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffectX));
        float dist_x = (cam.transform.position.x * parallaxEffectX);
        float dist_y = (cam.transform.position.y * parallaxEffectY);

        transform.position = new Vector3(startposX + dist_x, startposY + dist_y, transform.position.z);

        if (temp > startposX + length) startposX += length;
        else if (temp < startposX - length) startposX -= length;
    }
}