using System;
using System.Collections.Generic;

namespace Bot
{
    public class ChatBot
    {
        string _currentFlowId = "start";
        static Dictionary<(string, string), (string, string)> _flow = new()
        {
            [("start", null)] = ("welcome", "Oi!"),
            [("welcome", "Olá")] = ("option", "Escolha 1,2,3"),
            [("exception", null)] = ("start", "Desculpe, não entendi.")
        };
        static string _exceptionFlowId = "exception";

        public string ProcessMessage(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("input");
            }

            (string nextFlowId, string outputMessage) flowTuple;

            (string _currentFlowId, string input) key = (_currentFlowId, input);
            if (_flow.ContainsKey(key))
            {
                flowTuple = _flow[key];
            }
            else if (_currentFlowId == "start") 
            {
                flowTuple = _flow[(_currentFlowId, null)];
            }
            else
            {
                flowTuple = _flow[(_exceptionFlowId, null)];
            }

            _currentFlowId = flowTuple.nextFlowId;

            return flowTuple.outputMessage;

        }

    }
}
