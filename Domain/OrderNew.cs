using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class OrderNew:OrderState
    {
        public override OrderStates State => OrderStates.New;

        public OrderNew(OrderHeader orderheader):base(orderheader)
        { 


        }
        public override void Complete(ref OrderState _state)
        {
            throw new InvalidCastException("New can't change to complete");
        }
        public override void Rejected(ref OrderState _state)
        {
            throw new InvalidCastException("New can't change to reject");
        }
        public override void Submit(ref OrderState _state)
        {
         _state=new OrderPending (_orderHeader) ;
        }

    }
}
