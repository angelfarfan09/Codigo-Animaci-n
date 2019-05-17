using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallazoHandler : MonoBehaviour
{
    private static PantallazoHandler instance;

    private Camera miCamara;
    private bool tomarPantallazoSiguienteFrame;

    private void Awake()
    {
        instance = this;
        miCamara = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (tomarPantallazoSiguienteFrame)
        {
            tomarPantallazoSiguienteFrame = false;
            RenderTexture renderTexture = miCamara.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            System.IO.File.WriteAllBytes(Application.dataPath + ("/Resources/Textures/PantallazoCamara" + timeStamp + ".png"), byteArray);
            Debug.Log("Pantallazo de Camara guardado");

            RenderTexture.ReleaseTemporary(renderTexture);
            miCamara.targetTexture = null;
        }
    }

    private void TomarPantallazo(int width, int height)
    {
        miCamara.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        tomarPantallazoSiguienteFrame = true;
    }

    public static void TomarPantallazo_Static(int width, int height)
    {
        instance.TomarPantallazo(width, height);
    }
}
