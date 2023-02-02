using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIsinwave : MonoBehaviour
{

    private RectTransform pos;

    // moves us along the x of the sin function
    private float timer;
    [SerializeField] float howLong;

    [SerializeField] float posChange;

    // how much the intensity will be moved by in the end
    private float sinVariable;

    // initial intensity
    private float startPosition;

    void Start()
    {
        pos = GetComponent<RectTransform>();
        startPosition = pos.anchoredPosition.y;
    }

    void Update()
    {
        timer += Time.deltaTime;
        sinVariable = posChange * Mathf.Sin(timer * (2 * Mathf.PI / howLong)) + posChange;
        pos.anchoredPosition = new Vector2(pos.anchoredPosition.x, sinVariable + startPosition);
    }
}
