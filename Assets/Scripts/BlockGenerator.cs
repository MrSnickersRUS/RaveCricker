using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float PreGenerationDelay;
    [SerializeField] private GameObject block;
    private bool isFull;
    private int blockId;
    
    void Start()
    {
        isFull = false;
        blockId = 0;
        StartCoroutine(PreGenerate());
    }

    private IEnumerator PreGenerate() {
        while (!isFull) {
            GenerateBlock();
            yield return new WaitForSeconds(PreGenerationDelay);
        }
    }

    public void GenerateBlock() {
        var currentBlock = Instantiate(block, gameObject.transform);
        var blockPosition = currentBlock.GetComponent<RectTransform>();
        var blockSprite = currentBlock.GetComponent<Image>();
        blockSprite.sprite = sprites[blockId];
        switch (blockId)
        {
            case 0:
                blockPosition.anchoredPosition = new Vector3(-123.8f, 123.8f);
                break;
            case 1:
                blockPosition.anchoredPosition = new Vector2(247.6f - 123.8f, 123.8f);
                break;
            case 2:
                blockPosition.anchoredPosition = new Vector2(-123.8f, -123.2f);
                break;
            case 3:
                blockPosition.anchoredPosition = new Vector2(247.6f - 123.8f, -123.2f);
                blockId = 0;
                isFull = true;
                break;
        }
        blockId++;
    }
}
