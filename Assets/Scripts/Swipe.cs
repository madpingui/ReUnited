using System;
using UnityEngine;

public enum Direction { Left, Right, Down, Up }

public class Swipe : MonoBehaviour {

    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    public static event Action<Direction> OnSwipe;

    // Update is called once per frame
    void Update () 
    {
        #region standalone input
        if (Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region mobile inputs
        if(Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion


        //calculating swipes
        if(!isDraging)
            swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (swipeDelta.magnitude > 20)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x< 0)
                {
                    OnSwipe?.Invoke(Direction.Left);
                    Reset();
                }
                else
                {
                    OnSwipe?.Invoke(Direction.Right);
                    Reset();
                }
            }
            else
            {
                if (y < 0)
                {
                    OnSwipe?.Invoke(Direction.Down);
                    Reset();
                }
                else
                {
                    OnSwipe?.Invoke(Direction.Up);
                    Reset();
                }
            }
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}
