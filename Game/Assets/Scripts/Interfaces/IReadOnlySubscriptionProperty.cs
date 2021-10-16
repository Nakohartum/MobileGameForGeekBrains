using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileGame
{
    public interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }

        void SubscribeOnChange(Action<T> subscriptionAction);

        void UnsubscribeOnChange(Action<T> subscriptionAction);
    }
}
