using UnityEngine;
using TMPro;

public class ResolutionSelect : MonoBehaviour
{
    [SerializeField] Vector2Int[] resolutions;
    TextMeshProUGUI tmPro;
    int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < resolutions.Length; i ++)
        {
            if (Screen.width == resolutions[i].x)
            {
                index = i;
                tmPro.text = resolutions[index].x + "x" + resolutions[index].y;
            }
        }
    }

    public void ResRight()
    {
        index++;
        if (index >= resolutions.Length) { index = 0; }
        Screen.SetResolution(resolutions[index].x, resolutions[index].y, FullScreenMode.FullScreenWindow);
        tmPro.text = resolutions[index].x + "x" + resolutions[index].y;
    }

    public void ResLeft()
    {
        index--;
        if (index < 0) { index = resolutions.Length - 1; }
        Screen.SetResolution(resolutions[index].x, resolutions[index].y, FullScreenMode.FullScreenWindow);
        tmPro.text = resolutions[index].x + "x" + resolutions[index].y;
    }
}
