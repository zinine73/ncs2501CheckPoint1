using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private int xyz;
    private float speed;
    private float r,g,b;
    private bool br,bg,bb;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        Material material = Renderer.material;
        
        r = 0.5f;
        g = 1.0f;
        b = 0.3f;
        br = bg = true;
        material.color = new Color(r, g, b, 1.0f);

        xyz = Random.Range(0, 3);
        speed = Random.Range(10.0f, 100.0f);
    }
    
    void Update()
    {
        float x = 0.0f, y = 0.0f, z = 0.0f;
        switch (xyz)
        {
            case 0:
                x = speed * Time.deltaTime;
                break;
            case 1:
                y = speed * Time.deltaTime;
                break;
            case 2:
                z = speed * Time.deltaTime; 
                break;
        }
        transform.Rotate(x, y, z);
        
        ChangeColor(ref br, ref r, 0.07f * Time.deltaTime);
        ChangeColor(ref bg, ref g, 0.08f * Time.deltaTime);
        ChangeColor(ref bb, ref b, 0.09f * Time.deltaTime);
        Renderer.material.color = new Color(r, g, b, 1.0f);
    }

    private void ChangeColor(ref bool isAdd, ref float col, float val)
    {
        if (isAdd)
        {
            col += val;
            if (col > 1.0f)
            {
                col = 1.0f;
                isAdd = false;
            }
        }
        else
        {
            col -= val;
            if (col < 0.0f)
            {
                col = 0.0f;
                isAdd = true;
            }
        }
    }
}
