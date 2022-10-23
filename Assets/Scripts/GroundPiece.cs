using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPiece : MonoBehaviour
{
    public bool isColored = false;

    public void Colored(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
        isColored = true;

        FindObjectOfType<GameManager>().CheckComplete();
    }
}
