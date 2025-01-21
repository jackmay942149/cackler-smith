using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    [SerializeField] int refreshRate;
    [SerializeField] Vector2 speed;
    [SerializeField] float amplitude;

    // Trackers
    int refreshRateCounter = 0;
    float initYPos;

    // Flip sprite stuff
    SpriteRenderer sr;
    [SerializeField] float chanceToFlip;

    private void Start()
    {
        initYPos = transform.position.y;
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (refreshRateCounter == refreshRate)
        {
            RefreshUpdate();
            refreshRateCounter = 0;
        }
        else
        {
            refreshRateCounter++;
        }
    }

    void RefreshUpdate()
    {
        // Check in bounds
        float xUpdate = transform.position.x - speed.x;
        float yUpdate = initYPos + amplitude * Mathf.Sin(Time.time * speed.y);


        transform.position = new Vector3(xUpdate, yUpdate, transform.position.z);

        if (Random.Range(0.0f, 1.0f) < chanceToFlip)
        {
            sr.flipX = !sr.flipX;
        }
    }
}
