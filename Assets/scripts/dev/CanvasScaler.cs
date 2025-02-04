using UnityEngine;

public class CanvasScaler : MonoBehaviour
{
    [SerializeField] float xScale;
    RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        ResizeRes();
    }

    public void ResizeRes()
    {
        float i = ((float)Screen.currentResolution.width) / (xScale * (float)Screen.currentResolution.height);
        Vector3 newScale = new Vector3(i, transform.localScale.y, transform.localScale.z);
        rt.localScale = newScale;
    }
}
