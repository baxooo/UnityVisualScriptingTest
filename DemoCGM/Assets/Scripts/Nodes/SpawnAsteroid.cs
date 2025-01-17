using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[UnitCategory("Game/Asteroids")]
public class SpawnAsteroid : Unit
{
    [DoNotSerialize] public ValueInput BorderX { get; private set; }
    [DoNotSerialize] public ValueInput BorderZ { get; private set; }
    [DoNotSerialize] public ValueOutput SpawnPosition { get; private set; }

    private int X = 36;
    private int y = 20;

    protected override void Definition()
    {
        BorderX = ValueInput<float>("BorderX");
        BorderZ = ValueInput<float>("BorderZ");

        SpawnPosition = ValueOutput<Vector3>("SpawnPosition", (flow) =>
        {
            float width = flow.GetValue<float>(BorderX);
            float height = flow.GetValue<float>(BorderZ);
            
            
            if (Random.value > 0.5f)
            {
                float x = Random.value > 0.5f ? width : -width;
                float z = Random.Range(-height, height);
                return new Vector3(x, 0, z);
            }
            else
            {
                float x = Random.Range(-width, width);
                float z = Random.value > 0.5f ? -height : height;
                return new Vector3(x, 0, z);
            }
        });
    }
}
