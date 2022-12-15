using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemDestroy : MonoBehaviour
{
    [SerializeField] private float itemBreakTime;
    private float currentTime;

    private bool isHeld;

    private int dirtNum;

    private int gravelNum;

    private void Start()
    {
        currentTime = itemBreakTime;
        dirtNum = 0;
    }

    public void OnButtonDown() {
        currentTime = 0;
        isHeld = true;
        StartCoroutine(Breaking());
    }

    public void OnButtonUp() {
        isHeld = false;
    }

    private IEnumerator Breaking() {
        while (isHeld) {
            currentTime += Time.deltaTime;
            if ((int) currentTime == itemBreakTime) {
                print("broken");
                Destroy(gameObject);
                DirtGiver();
                GravelGiver();
            }
            yield return new WaitForFixedUpdate();
        }
    }

    void DirtGiver()
    {
        int dirtGiver = Random.Range(1, 5);
        dirtNum += dirtGiver;
        PlayerPrefs.SetInt("Dirt number", dirtNum);

        print("сейчас у вас земля" + dirtNum);
    }

    void GravelGiver()
    {
        int DropChance = Random.Range(1, 100);
        if (DropChance >= 40)
        {
            int gravelGiver = 1;
            gravelNum += gravelGiver;
            PlayerPrefs.SetInt("Gravel number", gravelNum);

            print("сейчас у вас гравий:" + gravelNum);
        }
    }
}
