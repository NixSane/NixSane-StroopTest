/* TransitionCanvasObject
 * Author: Nixon Sok
 * 
 * Purpose: To provide a common template for canvas UI that transitions from one canvas to another.
 * 
 * Last Edit: 17/12/2021
 */


using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "TransitionUIObject", menuName = "TransitionObject", order = 1)]
public class TransitionCanvasObject : ScriptableObject
{
    GameObject last_state;
    GameObject next_state; // Track what the next state is
    public float duration = 2f; // Duration of the transition
    private IEnumerator coroutine;

    /// <summary>
    /// Set the next state to active
    /// </summary>
    public void setStateActive()
    {
        last_state.SetActive(false);
        next_state.SetActive(true);
    }

    /// <summary>
    /// Set state to active after a certain duration
    /// </summary>
    /// <param name="duration"></param>
    public void setStateActive(float duration)
    {
        // If transition is still occuring
        if (duration > 0f)
        {
            if (!last_state.activeSelf)
            {
                last_state.SetActive(false);
            }

        }

    }

    /// <summary>
    /// Perform some sort of action during the transition time
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    private IEnumerator loadIn(float duration)
    {
        while (duration > 0f)
        {
            duration -= Time.deltaTime;
            yield return null;
        }
    }
}
