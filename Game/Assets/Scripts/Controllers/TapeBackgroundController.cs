using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MobileGame
{
    public class TapeBackgroundController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/background" };
        private TapeBackgroundView _view;
        private readonly SubscriptionProperty<float> _diff;
        private readonly IReadOnlySubscriptionProperty<float> _leftMove;
        private readonly IReadOnlySubscriptionProperty<float> _rightMove;
        public TapeBackgroundController(IReadOnlySubscriptionProperty<float> leftMove,
       IReadOnlySubscriptionProperty<float> rightMove)
        {
            _view = LoadView();
            _diff = new SubscriptionProperty<float>();

            _leftMove = leftMove;
            _rightMove = rightMove;

            _view.Init(_diff);

            _leftMove.SubscribeOnChange(Move);
            _rightMove.SubscribeOnChange(Move);
        }
        protected override void OnDispose()
        {
            _leftMove.UnsubscribeOnChange(Move);
            _rightMove.UnsubscribeOnChange(Move);

            base.OnDispose();
        }

        private TapeBackgroundView LoadView()
        {
            var objView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObject(objView);

            return objView.GetComponent<TapeBackgroundView>();
        }

        private void Move(float value)
        {
            _diff.Value = value;
        }

    }

}
