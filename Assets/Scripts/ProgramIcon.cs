using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramIcon : MonoBehaviour
{
    [Header("Program Icon Values")]

    [Tooltip("Reference to the window connected to this icon")]
    [SerializeField] private Window program;

    /// <summary>
    /// If the icon is clicked, open (or reset) the program window
    /// </summary>
    public void Clicked()
    {
        if (program != null)
        {
            program.Open();
        }
    }
}
