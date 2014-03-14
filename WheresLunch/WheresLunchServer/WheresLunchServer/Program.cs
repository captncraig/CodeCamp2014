using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            Console.WriteLine("Vote from {0} for {1}.",v.Name,v.Place);
            if(_votes.ContainsKey(v.Name)) throw new AlreadyVotedException();
            _votes[v.Name] = v.Place;
            _suggestions.Add(v.Place);
        }
    }

    class THttpServer : TServerTransport
    {
        private HttpListener _listener;

        public override void Listen()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:9012/");
            _listener.Start();
        }

        public override void Close()
        {
            _listener.Stop();
        }

        protected override TTransport AcceptImpl()
        {
            var ctx = _listener.GetContextAsync().Result;
            ctx.Response.AddHeader("Access-Control-Allow-Origin","*");
            return new TStreamTransport(ctx.Request.InputStream, ctx.Response.OutputStream);
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
            Task.Run(() => server.Serve());

            var http = new THttpServer();
            var httpServer = new TThreadPoolServer(processor, http, new TTransportFactory(), new TJSONProtocol.Factory());
            Console.WriteLine("Listening for http on port 9012");
            httpServer.Serve();
        }
    }
}
