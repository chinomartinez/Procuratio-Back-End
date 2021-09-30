﻿using Procuratio.Shared.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.Messaging
{
    public interface IMessageChannel
    {
        ChannelReader<IMessage> Reader { get; }

        ChannelWriter<IMessage> Writer { get; }
    }
}
