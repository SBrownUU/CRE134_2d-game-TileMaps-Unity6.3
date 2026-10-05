using UnityEngine;

public class token : MonoBehaviour
{
    static int collected = 0;


    public enum Worth {
        SMALL = 1,
        BIG = 10
    }

    [SerializeField] private Worth worth = Worth.SMALL;

    private void OnTriggerEnter2D(Collider2D col)
    {   
        if (col.CompareTag("Player")) {
            collected += (int)worth;
            Debug.Log(collected);
            Destroy(gameObject);
        }
    }
}
