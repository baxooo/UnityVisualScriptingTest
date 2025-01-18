using Unity.VisualScripting;
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

            
            Enter = ControlInput("Enter", (flow) =>
            {
                var gameObject = new GameObject();
                var target = flow.GetValue<Vector3>(Position);
                gameObject.transform.position = target;
                flow.SetValue(Transform, gameObject.transform);
                return Exit;
            });
            
            Exit = ControlOutput("Exit");
            Transform = ValueOutput<Transform>("Transform", (flow) =>
            {
                var gameObject = new GameObject();
                var target = flow.GetValue<Vector3>(Position);
                gameObject.transform.position = target;
                return gameObject.transform;
            });

            Succession(Enter, Exit);
        }
    }
}