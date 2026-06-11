using UnityEngine;

public class MoveChildren : MonoBehaviour
{
    public float moveAmount = 10f;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Vector3 pos = child.GetComponent<RectTransform>().position;
            child.GetComponent<RectTransform>().position = new Vector3(pos.x + moveAmount, pos.y, pos.z);
        }
    }
}