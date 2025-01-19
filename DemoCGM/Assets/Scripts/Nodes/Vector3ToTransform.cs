using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Nodes
{

    [UnitCategory("Vector3")]
    public class Vector3ToTransform : Unit
    {

        [DoNotSerialize] public ControlInput Enter;
        [DoNotSerialize] public ControlOutput Exit;

        [DoNotSerialize] public ValueInput Position;
        [DoNotSerialize] public ValueOutput Transform;

        protected override void Definition()
        {
            Position = ValueInput<Vector3>("Position");

            Transform = ValueOutput<Transform>("Transform", (flow) =>
            {
                var gameObject = new GameObject();
                var target = flow.GetValue<Vector3>(Position);
                
                gameObject.transform.position = target;
                var transform = gameObject.transform;
                
                Object.Destroy(gameObject);
                return transform;
            });
            
            Enter = ControlInput("Enter", (flow) => Exit);
            Exit = ControlOutput("Exit");

            Succession(Enter, Exit);
        }
    }
}