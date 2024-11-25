using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class ScrollContentScaler : MonoBehaviour
{
    [SerializeField]
    private bool horizontalResize = false;
    [SerializeField]
    private bool verticalResize = false;
    [SerializeField]
    private VerticalLayoutGroup verticalLayout = null;
    [SerializeField]
    private HorizontalLayoutGroup horizontalLayout = null;

    private RectTransform rect;
    private int curChildCount = -1;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        var newChildCount = transform.childCount;
        if (newChildCount != curChildCount)
        {
            curChildCount = newChildCount;
            UpdateRectSize();
        }
    }

    private void UpdateRectSize()
    {
        float horTotal = 0;
        float vertTotal = 0;
        int elements = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            var ch = transform.GetChild(i);
            var chRect = ch.GetComponent<RectTransform>();
            if (chRect == null)
                continue;

            horTotal += chRect.rect.width;
            vertTotal += chRect.rect.height;
            elements++;
        }

        if (horizontalLayout != null)
            horTotal += horizontalLayout.spacing * (elements - 1);
        if (verticalLayout != null)
            vertTotal += verticalLayout.spacing * (elements - 1);

        Vector2 finalSizeDelta = new(
            horizontalResize ? horTotal : rect.sizeDelta.x,
            verticalResize ? vertTotal : rect.sizeDelta.y
        );
        rect.sizeDelta = finalSizeDelta;
    }
}