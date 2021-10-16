using JoostenProductions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MobileGame
{
    class InputAcceleration : BaseInputView
    {
        public override void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            base.Init(leftMove, rightMove, speed);
            UpdateManager.SubscribeToUpdate(Move);
        }

        private void OnDestroy()
        {
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            var direction = Vector3.zero;
            direction.x = -Input.acceleration.y;
            direction.z = Input.acceleration.x;

            if (direction.sqrMagnitude > 1)
            {
                direction.Normalize();
            }

            OnRightMove(direction.sqrMagnitude / 20 * _speed);
        }
    }
}
