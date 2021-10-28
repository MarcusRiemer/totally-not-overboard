using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaterRoot))]
public class WaterRootEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        
        if(GUILayout.Button("Build Water"))
        {
            WaterRoot waterRoot = (WaterRoot)target;
            var cellMesh = waterRoot.waterCell.GetComponent<MeshFilter>();

            var terrainPosition = waterRoot.terrain.transform.position;
            var terrainData = waterRoot.terrain.terrainData;
            RectInt terrainDimensions = new RectInt(
                (int) terrainPosition.x,
                (int) terrainPosition.y,
                (int) terrainData.size.x,
                (int) terrainData.size.y
            );

            Vector2Int cellDim = new Vector2Int((int) cellMesh.sharedMesh.bounds.size.x, (int) cellMesh.sharedMesh.bounds.size.z);
            
            Debug.Log(cellDim);

            for (int i = waterRoot.transform.childCount; i > 0; --i)
            {
                DestroyImmediate(waterRoot.transform.GetChild(0).gameObject);
            }

            if (true)
            {
                for (int y = terrainDimensions.y; y <= terrainDimensions.yMax; y += cellDim.y)
                {
                    for (int x = terrainDimensions.x; x <= terrainDimensions.xMax; x += cellDim.x)
                    {
                        var obj = Instantiate(
                            waterRoot.waterCell,
                            new Vector3(x, 0, y - terrainDimensions.yMax / 2),
                            Quaternion.identity
                        );
                        obj.transform.parent = waterRoot.transform;
                        obj.name = $"Water {x},{y}";
                    }
                }
            }
        }
    }
}
