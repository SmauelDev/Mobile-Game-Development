using UnityEngine;

public class Screensaver : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D square;
    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        square = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        // cam scale ready for screen size
        float camHeight = cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;

        // putting screen corners into array
        Vector2[] edgePoints = new Vector2[5];
        edgePoints[0] = new Vector2(-camWidth, camHeight);
        edgePoints[1] = new Vector2(camWidth, camHeight);
        edgePoints[2] = new Vector2(camWidth, -camHeight);
        edgePoints[3] = new Vector2(-camWidth, -camHeight);
        edgePoints[4] = new Vector2(-camWidth, camHeight);

        // creating boundary object using found screen corners
        GameObject screenBoundary = new GameObject("ScreenBoundary");
        EdgeCollider2D edgeCollider = screenBoundary.AddComponent<EdgeCollider2D>();
        edgeCollider.points = edgePoints;

        // random direction 
        float xDirection = Random.Range(-1f, 1f);
        float yDirection = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        square.linearVelocity = direction * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
