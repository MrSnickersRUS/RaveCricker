using UnityEngine.UI;
using UnityEngine;
[RequireComponent(typeof(Image))]
public abstract class Block : MonoBehaviour
{
    public int id;
    public Sprite sprite;

    public Block(int id, Sprite sprite) {
        this.id = id;
        this.sprite = sprite;
        GetComponent<Image>().sprite = sprite;
    }
}
