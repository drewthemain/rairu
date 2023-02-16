using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowHeader : MonoBehaviour, 
    IPointerDownHandler, IPointerUpHandler
{

    [Header("Movement Values")]

    [Tooltip("The speed of dragging the window")]
    [SerializeField] private float dragSpeed = 0.7f;

    // Is the header currently clicked?
    private bool isClicked = false;
    // The offset for dragging a window object
    private Vector3 offset;
    // The starting position of the window (pre-movement)
    private Vector3 startingPosition;

    /// <summary>
    /// Event function for a header being clicked (down)
    /// </summary>
    /// <param name="eventData">The corresponding event data object</param>
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }

    /// <summary>
    /// Event function for a header being clicked (up)
    /// </summary>
    /// <param name="eventData">The corresponding event data object</param>
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
    }

    private void Update()
    {
        if (isClicked)
        {
            transform.parent.position = Input.mousePosition - offset;
        }
    }

    /// <summary>
    /// Resets (moved) position to original window position
    /// </summary>
    public void ResetPositions()
    {
        transform.parent.position = startingPosition;
    }

    /// <summary>
    /// Resets and initializes a window for movement
    /// </summary>
    public void Reset()
    {
        offset = new Vector3(0, transform.parent.GetComponent<RectTransform>().sizeDelta.y / 3, 0);
        startingPosition = transform.parent.position;
    }
}
