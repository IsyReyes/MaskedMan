using UnityEngine;

public class FlyweightFullCubes : MonoBehaviour
{
    private Renderer _renderer;
    private MaterialPropertyBlock _propertyBlock;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        // sacar el mat de la factory para cada cubo
        _propertyBlock = MaterialBlockFactory.GetSharedBlock();
    }

    void Update()
    {
        // aplicar propiedades individuales
        _renderer.GetPropertyBlock(_propertyBlock);
        _propertyBlock.SetColor("_BaseColor", GetRandomColor());
        _renderer.SetPropertyBlock(_propertyBlock);
    }

    private Color GetRandomColor()
    {
        return new Color(
            Random.Range(0.0f, 1.0f), 
            Random.Range(0.0f, 1.0f), 
            Random.Range(0.0f, 1.0f));
    }
}
