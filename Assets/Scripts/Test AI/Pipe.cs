using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public Color defaultColor;  // Default color of the pipe

    private int posX;  // X position in the grid
    private int posY;  // Y position in the grid
    private Color currentColor;  // Current color of the pipe

    private void Start()
    {
        currentColor = defaultColor;
        ApplyColor();
    }

    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }

    public void SetColor(Color color)
    {
        currentColor = color;
        ApplyColor();
    }

    public void Rotate()
    {
        // Rotate the pipe (implement your rotation logic here)
        transform.Rotate(new Vector3(0, 0, 90));
    }

    private void ApplyColor()
    {
        // Apply the current color to the pipe's sprite or material
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = currentColor;
    }
}
