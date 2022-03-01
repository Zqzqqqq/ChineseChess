﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChineseChess.message_processing;


namespace ChineseChess
{
    class MessageProcessingFactory
    {
        string type;
        public MessageProcessing Produce(string type)
        {
            switch (type)
            {
                case "chat" :
                    return new ChatMessageProcessing();
                case "step":
                    return new StepMessageProcessing();
                default:
                    return null;
            }
        }
    }
}
