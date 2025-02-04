using UnityEngine;

public class resolutionresizer : MonoBehaviour
{
    [SerializeField] float xScale;

    private void Update()
    {
        ResizeRes();
    }

    public void ResizeRes()
    {
        float i = ((float)Screen.currentResolution.width) / (xScale * (float)Screen.currentResolution.height);
        Vector3 newScale = new Vector3(i, transform.localScale.y, transform.localScale.z);
        this.transform.localScale = newScale;
    }
}
