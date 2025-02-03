using UnityEngine;
using UnityEngine.Rendering.Universal;

public class postprocessing : MonoBehaviour
{
    Camera cam;
    bool postProcessingOn = true;

    public ScriptableRenderer noPP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            postProcessingOn = !postProcessingOn;
            if (postProcessingOn)
            {
                cam.GetUniversalAdditionalCameraData().SetRenderer(2);

            }
            else
            {
                cam.GetUniversalAdditionalCameraData().SetRenderer(1);

            }
        }
    }
}
