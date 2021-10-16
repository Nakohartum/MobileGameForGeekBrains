using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MobileGame
{
    public abstract class BaseController : IDisposable
    {
        private List<BaseController> _baseControllers = new List<BaseController>();
        private List<GameObject> _gameObjects = new List<GameObject>();
        private bool _isDisposed;
        public void Dispose()
        {
           
            if (!_isDisposed)
            {
                _isDisposed = true;
                OnDispose();
                if (_baseControllers != null)
                {
                    foreach (BaseController controller in _baseControllers)
                    {
                        controller?.Dispose();
                    }
                    _baseControllers.Clear(); 
                }
                if (_gameObjects != null)
                {
                    foreach (GameObject gameObject in _gameObjects)
                    {
                        UnityEngine.Object.Destroy(gameObject);
                    }
                    _gameObjects.Clear();
                }
            }
        }

        protected void AddController(BaseController controller)
        {
            if (_baseControllers == null)
            {
                _baseControllers = new List<BaseController>();
            }
            _baseControllers.Add(controller);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            if (_gameObjects == null)
            {
                _gameObjects = new List<GameObject>();
            }
            _gameObjects.Add(gameObject);
        }

        protected virtual void OnDispose()
        {
            
        }
    }
}

