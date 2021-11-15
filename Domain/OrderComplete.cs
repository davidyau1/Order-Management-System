using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class OrderComplete:OrderState
    {
        public override OrderStates State => OrderStates.Complete;


        public OrderComplete(OrderHeader orderheader) : base(orderheader)
        {
        }
        public override void Complete(ref OrderState _state)
        {
            throw new InvalidCastException("complete can't complete to complete");
        }
        public override void Rejected(ref OrderState _state)
        {
            throw new InvalidCastException("complete can't change to reject");
        }
        public override void Submit(ref OrderState _state)
        {
            throw new InvalidCastException("complete can't change to submit");
        }

    }
}
