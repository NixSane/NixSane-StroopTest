using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct UIPlacement
{
    public GameObject gameObject;
    public Vector3 end_position;
}

public class TransitionScript : MonoBehaviour
{
    public TransitionCanvasObject transition_object;

    public RectTransform[] canvas_elements;

    void StartTransition()
    {
        for (int i = 0; i < canvas_elements.Length; i ++)
        {
            LeanTween.move(canvas_elements[i], Vector2.zero, transition_object.animation_duration).setEaseInOutBack();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartTransition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
