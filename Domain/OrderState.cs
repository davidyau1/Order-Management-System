using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{

    public abstract class OrderState
    {
        protected OrderHeader _orderHeader;
        public abstract OrderStates State { get; }

        public OrderState(OrderHeader orderHeader)
        {
            _orderHeader = orderHeader;
        }
        public abstract void Submit(ref OrderState _state);
        public abstract void Complete(ref OrderState _state);
        public abstract void Rejected(ref OrderState _state);
    }
}
