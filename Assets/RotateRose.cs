using UnityEngine;

public class RotateRose : WorldEntity
{
    private RectTransform _rect;

    protected override void WorldStart()
    {
        _rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        _rect.rotation = Quaternion.Euler(0, 0, worldRoot.windDirection);
    }
}