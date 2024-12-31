using UnityEngine;

public class Bubble : MonoBehaviour
{
    [Header("Movement Controls")]
    [SerializeField] float speed;
    [SerializeField] float refreshRate;

    // Trackers
    int refreshRateCounter = 0;
    Vector3 newPos;

    void Start()
    {
        newPos = transform.position;    
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
        newPos.x = transform.position.x + speed;
        transform.position = newPos;
    }
}
