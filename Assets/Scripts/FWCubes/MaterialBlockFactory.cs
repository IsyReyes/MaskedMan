using UnityEngine;

public class MaterialBlockFactory
{
    private static MaterialPropertyBlock _sharedBlock;
    
    public static MaterialPropertyBlock GetSharedBlock()
    {
        //gestión de inst de MaterialPropertyBlock
        if (_sharedBlock == null)
        {
            _sharedBlock = new MaterialPropertyBlock();
        }

        return _sharedBlock;
    }
}
