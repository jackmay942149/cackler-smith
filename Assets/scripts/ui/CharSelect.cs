using UnityEngine;

public class CharSelect : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    int index = 0;
    SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SpriteRight()
    {
        index++;
        if (index >= sprites.Length) { index = 0; }
        sr.sprite = sprites[index];
    }

    public void SpriteLeft()
    {
        index--;
        if (index < 0) { index = sprites.Length - 1; }
        sr.sprite = sprites[index];
    }

    void OnDestroy(){
        PlayerPrefs.SetInt("CharSelect", index);
    }
}
