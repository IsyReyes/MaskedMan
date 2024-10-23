using UnityEngine;

public class ColorCubes : MonoBehaviour
{
    private Renderer _renderer;
    private MaterialPropertyBlock _propertyBlock;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _propertyBlock = new MaterialPropertyBlock();
    }

    void Update()
    {
        _renderer.material.color = GetRandomColor();
        _renderer.material.SetColor("_BaseColor", GetRandomColor());
    }

    // void Update()
    // {
    //     _renderer.GetPropertyBlock(_propertyBlock);
    //     _propertyBlock.SetColor("_BaseColor",value: GetRandomColor());
    //     _renderer.SetPropertyBlock(_propertyBlock);
    // }

    private Color GetRandomColor()
    {
        return new Color(
            Random.Range(0.0f, 1.0f), 
            Random.Range(0.0f, 1.0f), 
            Random.Range(0.0f, 1.0f));
    }
    
}
