using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MobileGame
{
    public class CarController : BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath { PathResource = "Prefabs/Car" };
        private readonly CarView _carView;

        public CarController()
        {
            _carView = LoadView();
        }

        private CarView LoadView()
        {
            var objView = UnityEngine.Object.Instantiate(ResourceLoader.LoadPrefab(_resourcePath));
            AddGameObject(objView);
            return objView.GetComponent<CarView>();
        }

        public GameObject GetViewObject()
        {
            return _carView.gameObject;
        }
    }
}
