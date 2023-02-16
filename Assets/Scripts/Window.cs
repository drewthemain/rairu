using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [Header("Window Values")]

    [Tooltip("Is the current window visible or minimized?")]
    public bool isOpen = false;

    // The list of possible window orientations
    private List<GameObject> orientations = new List<GameObject>();
    // The current windown orientation
    private int currentWindowOrientation = 0;
    // A collection of the window's header objects for easy resetting
    private WindowHeader[] headers;
    // Has the window been opened yet?
    private bool isInit = false;

    private void Start()
    {
        // Adds each window orientation to a list for future indexing
        foreach (Transform window in transform)
        {
            orientations.Add(window.gameObject);
        }

        // Grabs all headers
        headers = GetComponentsInChildren<WindowHeader>(true);
    }

    /// <summary>
    /// Updates window to the next available window orientation
    /// </summary>
    public void ChangeSize()
    {
        orientations[currentWindowOrientation].SetActive(false);
        currentWindowOrientation = currentWindowOrientation + 1 < orientations.Count ? currentWindowOrientation + 1 : 0;
        orientations[currentWindowOrientation].SetActive(true);

        // If size is changed, reset positions
        foreach (WindowHeader header in headers)
        {
            header.ResetPositions();
        }
    }

    /// <summary>
    /// Closes the current window, either minimized or exited
    /// </summary>
    /// <param name="isExited">Was the window fully exited?</param>
    public void Close(bool isExited)
    {
        orientations[currentWindowOrientation].SetActive(false);

        // If fully closed, reset the initial window
        if (isExited)
        {
            currentWindowOrientation = 0;

            // If window is fully closed, reset all headers for next opening
            foreach (WindowHeader header in headers)
            {
                header.ResetPositions();
            }
        }
        
        isOpen = !isExited;
    }

    /// <summary>
    /// Opens the current window and moves to front of draw stack
    /// </summary>
    public void Open()
    {
        isOpen = true;
        orientations[currentWindowOrientation].SetActive(true);
        transform.SetAsLastSibling();

        // Only when a window is first opened, initialize all of the headers
        if (!isInit)
        {
            isInit = true;

            foreach (WindowHeader header in headers)
            {
                header.Reset();
            }
        }
    }
}
