using UnityEngine;
using System.Collections.Generic;

public class RandomSprite : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;

    void Start()
    {
        int i = Random.Range(0, sprites.Count);
        GetComponent<SpriteRenderer>().sprite = sprites[i];
    }
}
