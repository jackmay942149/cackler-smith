using UnityEngine;

public class UpdateSpiral : MonoBehaviour
{
    [SerializeField] Material[] materials;
    int index = 0;
    [SerializeField] GameObject spiral;
    SpriteRenderer sr;

    private void Start()
    {
        sr = spiral.GetComponent<SpriteRenderer>();
    }

    public void SpriteRight()
    {
        index++;
        if (index >= materials.Length) { index = 0; }
        sr.material = materials[index];
    }

    public void SpriteLeft()
    {
        index--;
        if (index < 0) { index = materials.Length - 1; }
        sr.material = materials[index];
    }
}
