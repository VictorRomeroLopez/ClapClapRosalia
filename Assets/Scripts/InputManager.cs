using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public int TouchCount { get; set; } = 0;
    public Touch[] Touches { get; set; }
    public IDictionary<int, Vector2> TouchesPositions { get; private set; } = new Dictionary<int, Vector2>();
    public Action SlideLeft = delegate { };
    public Action SlideRight = delegate { };

    void Update()
    {
        TouchCount = Input.touchCount;
        Touches = Input.touches;

        foreach (KeyValuePair<int, Vector2> touch in TouchesPositions)
        {
            Vector2 startPosition = PositionOnScreen(GetTouch(touch.Key).position);
            Vector2 endPosition = PositionOnScreen(touch.Value);
            float distanceOnScreen = Vector2.Distance(startPosition, endPosition);

            if (GetTouch(touch.Key).phase == TouchPhase.Ended && distanceOnScreen > 0.2f)
            {
                //Slide
                if (Mathf.Cos(Mathf.Deg2Rad * Vector2.SignedAngle(endPosition - startPosition, Vector2.right)) > 0)
                    SlideLeft.Invoke();
                else
                    SlideRight.Invoke();
            }
        }

        foreach (Touch touch in Touches)
        {
            if (touch.phase == TouchPhase.Began)
                TouchesPositions.Add(touch.fingerId, touch.position);
            else if(touch.phase == TouchPhase.Ended)
                TouchesPositions.Remove(touch.fingerId);
        }
    }

    private Touch GetTouch(int idTouch)
    {
        foreach (Touch touch in Touches)
            if (idTouch == touch.fingerId)
                return touch;

        return new Touch();
    }

    private Vector2 PositionOnScreen(Vector2 position)
    {
        return new Vector2(position.x / Screen.width, position.y / Screen.height);
    }
}
