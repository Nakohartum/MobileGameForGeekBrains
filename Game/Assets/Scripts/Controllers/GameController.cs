namespace MobileGame
{
    internal class GameController : BaseController
    {

        public GameController(PlayerProfile playerProfile)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, playerProfile.CurrentCar);
            AddController(inputGameController);

            var carController = new CarController();
            AddController(carController);
        }
    }
}