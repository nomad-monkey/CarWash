
using System.Collections;
using System.Collections.Generic;
using PaintIn3D;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MaskMaker : MonoBehaviour
{
    private P3dPaintableTexture[] p3dPaintableTextures;
    private Texture texture;
    [SerializeField] int baseIndex = 0;
    [SerializeField] int toBeMaskedIndex = 1;
    void Start()
    {
        p3dPaintableTextures = GetComponents<P3dPaintableTexture>();
        if (gameObject != null)
        {
            texture = p3dPaintableTextures[baseIndex].Slot.FindTexture(gameObject);
            
        }
    }
    
    void Update()
    {
        if (gameObject != null)
        {
            var tex = p3dPaintableTextures[baseIndex].Slot.FindTexture(gameObject);
            if(texture.name != tex.name)
            {
                texture = tex;
            }
            p3dPaintableTextures[toBeMaskedIndex].LocalMaskTexture = texture;
        }

       // SwitchBlackAndWhite(p3dPaintableTextures[toBeMaskedIndex].LocalMaskTexture);

    }



    void SwitchBlackAndWhite(Texture2D texture)
    {
        List<Vector2> whitePixels = new List<Vector2>();
        List<Vector2> blackPixels = new List<Vector2>();
       
        {
            for (var y = 0; y < texture.height; y++)
            {
                for (var x = 0; x < texture.width; x++)
                {
                    if (texture.GetPixel(x, y).r == 0)
                    {
                        
                        blackPixels.Add(new Vector2(x,y));
                    }
                    if (texture.GetPixel(x, y).r == 1)
                    {
                        
                        whitePixels.Add(new Vector2(x,y));
                    } 
                }
            }


            foreach (var pixel  in whitePixels)
            {
                texture.SetPixel((int)pixel.x, (int)pixel.y, new Color(0,0, 0, 1.0f));
            }
            
            foreach (var pixel  in blackPixels)
            {
                texture.SetPixel((int)pixel.x, (int)pixel.y, new Color(1,1, 1, 1.0f));
            }
           
           
            texture.Apply();
        }

        
        
        
    }
}
