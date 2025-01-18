using Unity.VisualScripting;
using UnityEngine;

namespace Nodes
{
    
    [UnitCategory("Math/Vector3")]
    public class MultiplyScalar : Unit
    {
        [DoNotSerialize] public ValueInput A { get; private set; }
        [DoNotSerialize] public ValueInput B { get; private set; }
        
        
        [DoNotSerialize] public ValueOutput Position { get; private set; }
        protected override void Definition()
        {
            var A = ValueInput<Vector3>("A");
            var B = ValueInput<float>("B");

            Position = ValueOutput<Vector3>("SpawnPosition", (flow) =>
            {
                var a = flow.GetValue<Vector3>(A);
                var b = flow.GetValue<float>(B);
                
                return b * a;
            });
        }
    }
}