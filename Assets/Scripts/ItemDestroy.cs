using System.Collections;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    [SerializeField] private float itemBreakTime;
    private float currentTime;

    private bool isHeld;

    private void Start()
    {
        currentTime = itemBreakTime;
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
            }
            yield return new WaitForFixedUpdate();
        }
    }
}
