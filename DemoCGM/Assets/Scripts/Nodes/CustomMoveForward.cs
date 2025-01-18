using Unity.VisualScripting;
using UnityEngine;

namespace Nodes
{
    public class CustomMoveForward : Unit
    {
        [DoNotSerialize] public ControlInput Enter;
        [DoNotSerialize] public ControlOutput Exit;
        
        [DoNotSerialize] public ValueInput Speed;
        [DoNotSerialize] public ValueInput GameObject;
        
        
        protected override void Definition()
        {
            GameObject = ValueInput<GameObject>("GameObject");
            Speed = ValueInput<float>("Speed");
            
            Enter = ControlInput("Enter", (flow) =>
            {
                var rock = flow.GetValue<GameObject>(GameObject);
                var speed = flow.GetValue<float>(Speed);
                
                rock.transform.Translate(Time.fixedDeltaTime * speed * Vector3.forward);
                
                return Exit;
            });
        }
    }
}