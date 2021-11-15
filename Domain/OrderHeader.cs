using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class OrderHeader
    {
        //fields
        //declare and instantiate List<OrderItem> called _orderItems
            public List<OrderItem> _orderItems = new List<OrderItem>();
            public int Count { get => _orderItems.Sum(oi => oi.Quantity); }
            //declare OrderState ref called _state (COMPLETED)
            public  OrderState _state;
            //prop
            //DateTime - DateTime (public getter, private setter)
            public DateTime DateTime { get;private set; }
            //Id - int ((public getter, private setter))
            public int Id { get; private set; }
            //Total - decimal (public getter returns all items' total)
            public decimal Total { get=> _orderItems.Sum(oi=>oi.Total); }
            //State - OrderStates (public getter returns state enum) (COMPLETED)

            //cons
            public OrderHeader(int id, DateTime dateTime, int stateId)
            {
                //assign value from param to Id prop
                Id = id;
                //assign value from param to DateTime prop
                DateTime = dateTime;
                //call setState method and pass stateId
                setState(stateId);
            }
            

            public OrderStates State
            {
                get
                {
                    return _state.State;
                }
            }
            //methods
            //Complete() (COMPLETED)
            public void Complete()
        {
            _state.Complete(ref _state);
        }
        //Reject() (COMPLETED)
        public void Rejected()
        {
            _state.Rejected(ref _state);
        }
        //Submit() (COMPLETED)
        public void Submit()
        {
            _state.Submit(ref _state);
        }
        //setState() (COMPLETED)
        private void setState(int stateId)
            {
                switch (stateId)
                {
                    case 1:
                        _state = new OrderNew(this);
                        break;
                    case 2:
                        _state = new OrderPending(this);
                        break;
                    case 3:
                        _state = new OrderRejected(this);
                        break;
                    case 4:
                        _state = new OrderComplete(this);
                        break;
                   
                    default: throw new InvalidOrderStateException ($"Invalid State Id: {stateId}") ;
                                            
                }
            }
           

            public OrderItem AddOrderItem(int stockItemId, decimal price, string description, int quantity)
            {
               
            var item = _orderItems.FirstOrDefault(i => i.StockItemId == stockItemId);
                if (item != null)
                {
                    if (quantity == 0)
                    {
                        item.Quantity = quantity;
                        _orderItems.Remove(item);
                    }
                    else
                    {
                        item.Quantity = quantity;

                    }
                }

            
                else
                {
                    item = new OrderItem(this, stockItemId, price, description, quantity);
                    _orderItems.Add(item);

                }
                return item;

            }


    }
}
