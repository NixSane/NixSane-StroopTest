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

    public GameObject[] gameObject;
    public Vector3[] end_position;
    UIPlacement[] UI_elements;

    void StartTransition()
    {
        LeanTween.moveLocal(gameObject[0], end_position[0], transition_object.duration).setEaseInBounce();
    }

    // Start is called before the first frame update
    void Start()
    {
        //UI_elements = new UIPlacement[gameObject.Length];

        //for (int i = 0; i < UI_elements.Length; i++)
        //{
        //    UI_elements[i].gameObject = gameObject[i];
        //    UI_elements[i].end_position = end_position[i];
        //}

        StartTransition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
