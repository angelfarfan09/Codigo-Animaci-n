using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;

public class GIF : MonoBehaviour {


   
   
    public GameObject destruir;


     Texture2D[] frames;
     int fps = 10;





    void Update()
    {


        int index = (int)(Time.time * fps) % frames.Length;
        GetComponent<RawImage>().texture = frames[index];

    }



    public void number24()
    {

        fps = 24;

        

}

    public void number12()
    {

         fps = 12;

    }

    public void number8()
    {

         fps = 8;

    }





   public void Play()
    {

        UnityEditor.AssetDatabase.Refresh();
        destruir.SetActive(false);
        
        frames = Resources.LoadAll<Texture2D>("Textures");

    }



   public void Borrar()
    {

        
        if (Directory.Exists("Assets/Resources/Textures")) { Directory.Delete("Assets/Resources/Textures", true); }
        Directory.CreateDirectory("Assets/Resources/Textures");
        
       



    }

    
}
                 







