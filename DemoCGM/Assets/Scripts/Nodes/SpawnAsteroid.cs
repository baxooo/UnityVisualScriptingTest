using Unity.VisualScripting;
using UnityEngine;

namespace Nodes
{
    [UnitCategory("Game/Asteroids")]
    public class AsteroidSpawnPosition : Unit
    {
        [DoNotSerialize] public ControlInput Enter;
        [DoNotSerialize] public ControlOutput Exit;
        
        [DoNotSerialize] public ValueInput BorderX { get; private set; }
        [DoNotSerialize] public ValueInput BorderZ { get; private set; }
        [DoNotSerialize] public ValueOutput SpawnPosition { get; private set; }

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
                    float x = Random.value > 0.5f
                        ? Random.Range(-width * 1.1f, -width)
                        : Random.Range(width, width * 1.1f);
                    float z = Random.Range(-height * 1.1f, height * 1.1f);
                    return new Vector3(x, 0, z);
                }
                else
                {
                    float x = Random.Range(-width * 1.1f, width * 1.1f);
                    float z = Random.value > 0.5f
                        ? Random.Range(-height * 1.1f, -height)
                        : Random.Range(height, height * 1.1f);
                    return new Vector3(x, 0, z);
                }
            });
        }
    }
}
