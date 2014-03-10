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
    class LunchLadyHandler : LunchService.Iface
    {

        private readonly List<string> _suggestions = new List<string>{"McDonalds","Super Wok","Indian Princess","Burrito Bandit"}; 

        private readonly IDictionary<string,string> _votes = new Dictionary<string, string>{{"Joe","Tucanos"},{"Steve","Del Taco"}}; 

        public void PlaceVote(Vote vote)
        {
            Console.WriteLine("Vote from {0} for {1}",vote.Name, vote.Restaurant);
            _votes[vote.Name] = vote.Restaurant;
        }

        public List<string> GetSuggestions()
        {
            var random = new Random();
            Console.WriteLine("Get Suggestions");
            return _suggestions.OrderBy(x => random.Next()).ToList();
        }

        public string MakeDecision()
        {
            var random = new Random();
            Console.WriteLine("Deciding...");
            return _votes.OrderBy(x => random.Next()).First().Value;
        }
    }

    class HttpTransport : TServerTransport
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
            return new TStreamTransport(ctx.Request.InputStream,ctx.Response.OutputStream);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var handler = new LunchLadyHandler();
            var processor = new LunchService.Processor(handler);
            var transport = new TServerSocket(9011,2000,true);
            var server = new TThreadPoolServer(processor, transport, new TTransportFactory(),
                new TCompactProtocol.Factory());
            
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Starting server on port 9011");
                server.Serve();
            });

            var httpTransport = new HttpTransport();
            var httpServer = new TThreadPoolServer(processor, httpTransport, new TTransportFactory(),
                new TJSONProtocol.Factory());
            Console.WriteLine("Starting http server on port 9012");
            httpServer.Serve();
        }
    }
}
