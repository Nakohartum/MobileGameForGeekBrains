﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace MobileGame
{
    public class BaseInputView : MonoBehaviour
    {
        private SubscriptionProperty<float> _leftMove;
        private SubscriptionProperty<float> _rightMove;
        protected float _speed;

        public virtual void Init(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, float speed)
        {
            _leftMove = leftMove;
            _rightMove = rightMove;
            _speed = speed;
        }

        protected void OnLeftMove(float value)
        {
            _leftMove.Value = value;
        }

        protected void OnRightMove(float value)
        {
            _rightMove.Value = value;
        }
    }
}
