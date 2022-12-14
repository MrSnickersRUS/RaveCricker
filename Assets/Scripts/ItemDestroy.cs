using System.Collections;
using UnityEngine;
using UnityEngine.Random;

public class ItemDestroy : MonoBehaviour
{
    [SerializeField] private float itemBreakTime;
    private float currentTime;

    private bool isHeld;

    private Random randomNum;
    [SerializeField] private Random randomChance;

    private int dirtNum;

    private int GravelNum;

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
                DirtGiver;
                GravelGiver;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    void DirtGiver()
    {
        int dirtGiver = new Random randomNum.Next(1, 5)
        dirtNum += dirtGiver;
        PlayerPrefs.SetInt("Dirt number", dirtNum);

        print("получено земля");
    }

    void GravelGiver()
    {
        int DropChance = new Random randomChance.Next(1, 100);
        if (DropChance > 40)
        {
            int GravelGiver = new Random randomNum.Next(0, 1);
            GravelNum += GravelGiver;
            PlayerPrefs.SetInt("Gravel number", gravelNum);

            print("получено гравий");
        }
    }
}
