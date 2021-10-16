using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileGame
{
    public class PlayerProfile
    {
        public SubscriptionProperty<GameState> CurrentState { get; }
        public Car CurrentCar { get; }

        public PlayerProfile(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentCar = new Car(speedCar); 
        }
    }
}
