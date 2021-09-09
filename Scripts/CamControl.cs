using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    private Vector2 mousePos, mousePosDinamic;
    public float s1 = 1, s2 = 50;
    float x, y, k = 1, size, inc = 0, futureSize = 0, k2 = 1;
    bool b = true;
    public bool bActiv = false;

    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        futureSize = Camera.main.orthographicSize;
    }

    void Update()
    {
            if (Input.GetMouseButtonDown(1))
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                x = transform.position.x;
                y = transform.position.y;
            }

            if (Input.GetMouseButton(1))
            {
                mousePosDinamic = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float x2 = mousePos.x - mousePosDinamic.x;
                float y2 = mousePos.y - mousePosDinamic.y;
                x = x + x2;
                y = y + y2;
                transform.position = new Vector3(x, y, -10);
            }

            if (Input.mouseScrollDelta.y != 0)
            {
                if ((futureSize - (Input.mouseScrollDelta.y / 2) * k >= s1) && (futureSize - (Input.mouseScrollDelta.y / 2) * k <= s2))
                {
                    k = futureSize / 7;
                    futureSize += -(Input.mouseScrollDelta.y / 2) * k;
                    mousePosDinamic = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }

            size = Camera.main.orthographicSize;
            
            if (size != futureSize)
            {
                mousePosDinamic = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (size > futureSize)
                {                     
                    k2 = size - futureSize;
                    if (k2 < 0.025f) k2 = 0.025f;
                    Camera.main.orthographicSize -= 7f * k2 * Time.deltaTime;
                    if (Camera.main.orthographicSize < futureSize)
                    Camera.main.orthographicSize = futureSize;
                }

                if (size < futureSize)
                {
                    k2 = futureSize - size;
                    if (k2 < 0.025f) k2 = 0.025f;
                    Camera.main.orthographicSize += 7f * k2 * Time.deltaTime;
                    if (Camera.main.orthographicSize > futureSize)
                    Camera.main.orthographicSize = futureSize;
                }

                float x2 = mousePosDinamic.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                float y2 = mousePosDinamic.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
                x = x + x2;
                y = y + y2;
                transform.position = new Vector3(x, y, -10);
            }
    }
}