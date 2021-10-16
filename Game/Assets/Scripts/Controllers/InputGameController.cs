using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MobileGame
{
    public class InputGameController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath { PathResource = "Prefabs/endlessMove" };
        private BaseInputView _view;
        public InputGameController(SubscriptionProperty<float> leftMove, SubscriptionProperty<float> rightMove, Car car)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, car.SpeedCar);
        }

        private BaseInputView LoadView()
        {
            var objView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObject(objView);

            return objView.GetComponent<BaseInputView>();
        }
    }
}
