using System;
using System.Collections.Generic;
using EasyManager.Domain.Core.Events;
using EasyManager.Domain.Models;
using EasyManager.Domain.Types;

namespace EasyManager.Domain.Events
{
    public class CustomerUpdatedEvent : CustomerEvent
    {
         public CustomerUpdatedEvent()
        {
            
        }
    }
}