using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Controls")]
    [SerializeField] float speed;
    [SerializeField] int refreshRate;

    [Header("Play Zone Bounds")]
    [SerializeField] Vector2 maxBounds;
    [SerializeField] Vector2 minBounds;

    // Trackers
    int refreshRateCounter = 0;
    Vector3 moveDir = Vector3.zero;

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x = -1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDir.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.y = -1;
        }
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
        float xUpdate = transform.position.x + moveDir.x * speed;
        float yUpdate = transform.position.y + moveDir.y * speed;

        if (xUpdate > maxBounds.x || minBounds.x > xUpdate)
        {
            xUpdate = transform.position.x;
        }
        if (yUpdate > maxBounds.y || minBounds.y > yUpdate)
        {
            yUpdate = transform.position.y;
        }

        transform.position = new Vector3(xUpdate, yUpdate, transform.position.z);
        moveDir = Vector3.zero; // Reset moveDir flag
    }
}
