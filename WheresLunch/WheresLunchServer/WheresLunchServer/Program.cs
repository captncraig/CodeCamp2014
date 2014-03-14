using System;
using System.Collections.Generic;
using System.Linq;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;

namespace WheresLunchServer
{
    class LunchHandler : LunchService.Iface
    {
        private readonly IList<string> _suggestions = new List<string>{"McDonalds","Tucanos","Yuppy Burrito Hut"};
        private readonly Random _r = new Random();
        private readonly IDictionary<string,string> _votes = new Dictionary<string, string>();

        public LunchHandler()
        {
            PlaceVote(new Vote{Name = "Joe",Place = "Taco Bell"});
            PlaceVote(new Vote{Name = "Steve",Place = "Thai Palace"});
        }

        public string MakeDecision()
        {
            return _votes.OrderBy(x => _r.Next()).First().Value;
        }

        public List<string> GetSuggestions()
        {
            return _suggestions.Distinct().OrderBy(x => _r.Next()).ToList();
        }

        public void PlaceVote(Vote v)
        {
            if(_votes.ContainsKey(v.Name)) throw new AlreadyVotedException();
            _votes[v.Name] = v.Place;
            _suggestions.Add(v.Place);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var handler = new LunchHandler();
            var processor = new LunchService.Processor(handler);
            var transport = new TServerSocket(9011,2000,true);
            var server = new TThreadPoolServer(processor, transport, new TTransportFactory(),
                new TCompactProtocol.Factory());
            Console.WriteLine("Listening on port 9011");
            server.Serve();
        }
    }
}
