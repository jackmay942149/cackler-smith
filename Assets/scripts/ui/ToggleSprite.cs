using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ToggleSprite : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField] Sprite onSprite;
    [SerializeField] Sprite offSprite;

    [SerializeField] GameObject[] masterToggleObjects;

    [SerializeField] ScriptableRendererFeature[] renderfeatures;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (renderfeatures.Length == 0)
        {
            return;
        }

        if (!renderfeatures[0].isActive)
        {
            sr.sprite = offSprite;
        }
    }

    public void Toggle()
    {
        if (sr.sprite == onSprite)
        {
            ToggleOff();
            if (masterToggleObjects.Length > 0) { ToggleAllOff(); }
        }
        else
        {
            ToggleOn();
            if (masterToggleObjects.Length > 0) { ToggleAllOn(); }  
        }
    }

    private void ToggleOff()
    {
        sr.sprite = offSprite;
        foreach (ScriptableRendererFeature srf in renderfeatures)
        {
            srf.SetActive(false);
        }
    }

    private void ToggleOn()
    {
        sr.sprite = onSprite;
        foreach (ScriptableRendererFeature srf in renderfeatures)
        {
            srf.SetActive(true);
        }
    }

    private void ToggleAllOff()
    {
        foreach (GameObject g in masterToggleObjects)
        {
            g.GetComponent<ToggleSprite>().ToggleOff();
        }
    }

    private void ToggleAllOn()
    {
        foreach (GameObject g in masterToggleObjects)
        {
            g.GetComponent<ToggleSprite>().ToggleOn();
        }
    }
}
