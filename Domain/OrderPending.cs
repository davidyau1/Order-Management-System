using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class OrderPending:OrderState
    {
        public override OrderStates State => OrderStates.Pending;
        public OrderPending(OrderHeader orderheader) : base(orderheader)
        {


        }
        public override void Complete(ref OrderState _state)
        {
            _state = new OrderComplete(_orderHeader);
                }
        public override void Rejected(ref OrderState _state)
        {
            _state = new OrderRejected(_orderHeader);
        }
        public override void Submit(ref OrderState _state)
        {
            throw new InvalidCastException("pending can't change to pending");
        }
    }
}
