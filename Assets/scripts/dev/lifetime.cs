using Unity.VisualScripting;
using UnityEngine;

public class lifetime : MonoBehaviour
{
    [SerializeField] float lifeTime = 10.0f;
    float timeCreated;

    void Start()
    {
        timeCreated = Time.time;
    }

    private void Update()
    {
        if (Time.time - timeCreated > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
