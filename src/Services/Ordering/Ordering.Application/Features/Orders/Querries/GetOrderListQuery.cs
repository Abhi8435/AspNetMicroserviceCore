using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Features.Orders.Querries
{
    public class GetOrderListQuery : IRequest<List<OrdersVm>>
    {
        public GetOrderListQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
        
    }
}
