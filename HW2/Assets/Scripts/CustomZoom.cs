using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomZoom : MonoBehaviour
{
    public Camera MagnifiedView; // Camera for rendering magnified view
    public RenderTexture ZoomTexture; // Render texture for magnified view
    public RawImage magnifiedViewDisplay; // UI Image to display magnified view

    private void Start()
    {
        // Ensure necessary components are assigned
        if (MagnifiedView == null || ZoomTexture == null || magnifiedViewDisplay == null)
        {
            Debug.LogError("Assign all required components!");
            return;
        }

        // Set the target texture of the magnified view camera
        MagnifiedView.targetTexture = ZoomTexture;
    }

    private void Update()
    {
        // Render magnified view into the render texture
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = ZoomTexture;
        MagnifiedView.Render();
        RenderTexture.active = currentRT;

        // Display the render texture on the UI Image
        magnifiedViewDisplay.texture = ZoomTexture;
    }
}
