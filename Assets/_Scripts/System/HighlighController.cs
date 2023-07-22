using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlighController : MonoBehaviour
{
    [SerializeField] GameObject highlighter;

    GameObject currentTarget;

    public void Highligh(GameObject target)
    {
        if (currentTarget == target)
        {
            return;
        }
        currentTarget = target;
        Vector3 position = target.transform.position + Vector3.up * 0.5f;
        Highligh(position);
    }

    public void Highligh(Vector3 position)
    {
        highlighter.SetActive(true);
        highlighter.transform.position = position;
    }

    public void Hide()
    {
        currentTarget = null;
        highlighter.SetActive(false);
    }
}
