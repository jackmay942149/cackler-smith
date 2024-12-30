using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int refreshRate;
    int refreshRateCounter = 0;

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
        Vector3 moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x += speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x -= speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDir.y += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.y -= speed;
        }

        transform.position += moveDir.normalized * speed; 
    }
}
