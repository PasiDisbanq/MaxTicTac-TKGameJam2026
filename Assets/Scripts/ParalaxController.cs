using UnityEngine;

public class ParalaxController : MonoBehaviour {
    private float length, startpos;
    [SerializeField] private GameObject Cam;
    [SerializeField] private float parallaxEffect;

    private void Start() {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        float temp = (Cam.transform.position.x * (1 - parallaxEffect));
        float dist = (Cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
