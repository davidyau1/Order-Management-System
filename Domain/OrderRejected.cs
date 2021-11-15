using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class OrderRejected:OrderState
    {
        public override OrderStates State => OrderStates.Rejected;
        public OrderRejected(OrderHeader orderheader) : base(orderheader)
        {


        }
        public override void Complete(ref OrderState _state)
        {
        throw new InvalidCastException("rejected can't change to completed");
        }
        public override void Rejected(ref OrderState _state)
        {
            throw new InvalidCastException("rejected can't change to rejected");
        }
        public override void Submit(ref OrderState _state)
        {
            throw new InvalidCastException("rejected can't change to pending");
        }
    }
}
