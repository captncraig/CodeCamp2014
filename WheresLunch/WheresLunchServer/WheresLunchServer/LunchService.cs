/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace WheresLunchServer
{
  public partial class LunchService {
    public interface Iface {
      /// <summary>
      /// Place a vote
      /// </summary>
      /// <param name="vote"></param>
      void PlaceVote(Vote vote);
      #if SILVERLIGHT
      IAsyncResult Begin_PlaceVote(AsyncCallback callback, object state, Vote vote);
      void End_PlaceVote(IAsyncResult asyncResult);
      #endif
      List<string> GetSuggestions();
      #if SILVERLIGHT
      IAsyncResult Begin_GetSuggestions(AsyncCallback callback, object state);
      List<string> End_GetSuggestions(IAsyncResult asyncResult);
      #endif
      string MakeDecision();
      #if SILVERLIGHT
      IAsyncResult Begin_MakeDecision(AsyncCallback callback, object state);
      string End_MakeDecision(IAsyncResult asyncResult);
      #endif
    }

    public class Client : IDisposable, Iface {
      public Client(TProtocol prot) : this(prot, prot)
      {
      }

      public Client(TProtocol iprot, TProtocol oprot)
      {
        iprot_ = iprot;
        oprot_ = oprot;
      }

      protected TProtocol iprot_;
      protected TProtocol oprot_;
      protected int seqid_;

      public TProtocol InputProtocol
      {
        get { return iprot_; }
      }
      public TProtocol OutputProtocol
      {
        get { return oprot_; }
      }


      #region " IDisposable Support "
      private bool _IsDisposed;

      // IDisposable
      public void Dispose()
      {
        Dispose(true);
      }
      

      protected virtual void Dispose(bool disposing)
      {
        if (!_IsDisposed)
        {
          if (disposing)
          {
            if (iprot_ != null)
            {
              ((IDisposable)iprot_).Dispose();
            }
            if (oprot_ != null)
            {
              ((IDisposable)oprot_).Dispose();
            }
          }
        }
        _IsDisposed = true;
      }
      #endregion


      
      #if SILVERLIGHT
      public IAsyncResult Begin_PlaceVote(AsyncCallback callback, object state, Vote vote)
      {
        return send_PlaceVote(callback, state, vote);
      }

      public void End_PlaceVote(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        recv_PlaceVote();
      }

      #endif

      /// <summary>
      /// Place a vote
      /// </summary>
      /// <param name="vote"></param>
      public void PlaceVote(Vote vote)
      {
        #if !SILVERLIGHT
        send_PlaceVote(vote);
        recv_PlaceVote();

        #else
        var asyncResult = Begin_PlaceVote(null, null, vote);
        End_PlaceVote(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_PlaceVote(AsyncCallback callback, object state, Vote vote)
      #else
      public void send_PlaceVote(Vote vote)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("PlaceVote", TMessageType.Call, seqid_));
        PlaceVote_args args = new PlaceVote_args();
        args.Vote = vote;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public void recv_PlaceVote()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        PlaceVote_result result = new PlaceVote_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        return;
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_GetSuggestions(AsyncCallback callback, object state)
      {
        return send_GetSuggestions(callback, state);
      }

      public List<string> End_GetSuggestions(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetSuggestions();
      }

      #endif

      public List<string> GetSuggestions()
      {
        #if !SILVERLIGHT
        send_GetSuggestions();
        return recv_GetSuggestions();

        #else
        var asyncResult = Begin_GetSuggestions(null, null);
        return End_GetSuggestions(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_GetSuggestions(AsyncCallback callback, object state)
      #else
      public void send_GetSuggestions()
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("GetSuggestions", TMessageType.Call, seqid_));
        GetSuggestions_args args = new GetSuggestions_args();
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public List<string> recv_GetSuggestions()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        GetSuggestions_result result = new GetSuggestions_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetSuggestions failed: unknown result");
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_MakeDecision(AsyncCallback callback, object state)
      {
        return send_MakeDecision(callback, state);
      }

      public string End_MakeDecision(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_MakeDecision();
      }

      #endif

      public string MakeDecision()
      {
        #if !SILVERLIGHT
        send_MakeDecision();
        return recv_MakeDecision();

        #else
        var asyncResult = Begin_MakeDecision(null, null);
        return End_MakeDecision(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_MakeDecision(AsyncCallback callback, object state)
      #else
      public void send_MakeDecision()
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("MakeDecision", TMessageType.Call, seqid_));
        MakeDecision_args args = new MakeDecision_args();
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public string recv_MakeDecision()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        MakeDecision_result result = new MakeDecision_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "MakeDecision failed: unknown result");
      }

    }
    public class Processor : TProcessor {
      public Processor(Iface iface)
      {
        iface_ = iface;
        processMap_["PlaceVote"] = PlaceVote_Process;
        processMap_["GetSuggestions"] = GetSuggestions_Process;
        processMap_["MakeDecision"] = MakeDecision_Process;
      }

      protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
      private Iface iface_;
      protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

      public bool Process(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public void PlaceVote_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        PlaceVote_args args = new PlaceVote_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        PlaceVote_result result = new PlaceVote_result();
        iface_.PlaceVote(args.Vote);
        oprot.WriteMessageBegin(new TMessage("PlaceVote", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void GetSuggestions_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        GetSuggestions_args args = new GetSuggestions_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        GetSuggestions_result result = new GetSuggestions_result();
        result.Success = iface_.GetSuggestions();
        oprot.WriteMessageBegin(new TMessage("GetSuggestions", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void MakeDecision_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        MakeDecision_args args = new MakeDecision_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        MakeDecision_result result = new MakeDecision_result();
        result.Success = iface_.MakeDecision();
        oprot.WriteMessageBegin(new TMessage("MakeDecision", TMessageType.Reply, seqid)); 
        result.Write(oprot);
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class PlaceVote_args : TBase
    {
      private Vote _vote;

      public Vote Vote
      {
        get
        {
          return _vote;
        }
        set
        {
          __isset.vote = true;
          this._vote = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool vote;
      }

      public PlaceVote_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.Struct) {
                Vote = new Vote();
                Vote.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("PlaceVote_args");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Vote != null && __isset.vote) {
          field.Name = "vote";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          Vote.Write(oprot);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("PlaceVote_args(");
        sb.Append("Vote: ");
        sb.Append(Vote== null ? "<null>" : Vote.ToString());
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class PlaceVote_result : TBase
    {

      public PlaceVote_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("PlaceVote_result");
        oprot.WriteStructBegin(struc);

        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("PlaceVote_result(");
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class GetSuggestions_args : TBase
    {

      public GetSuggestions_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("GetSuggestions_args");
        oprot.WriteStructBegin(struc);
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("GetSuggestions_args(");
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class GetSuggestions_result : TBase
    {
      private List<string> _success;

      public List<string> Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public GetSuggestions_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.List) {
                {
                  Success = new List<string>();
                  TList _list0 = iprot.ReadListBegin();
                  for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                  {
                    string _elem2 = null;
                    _elem2 = iprot.ReadString();
                    Success.Add(_elem2);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("GetSuggestions_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          if (Success != null) {
            field.Name = "Success";
            field.Type = TType.List;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            {
              oprot.WriteListBegin(new TList(TType.String, Success.Count));
              foreach (string _iter3 in Success)
              {
                oprot.WriteString(_iter3);
              }
              oprot.WriteListEnd();
            }
            oprot.WriteFieldEnd();
          }
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("GetSuggestions_result(");
        sb.Append("Success: ");
        sb.Append(Success);
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class MakeDecision_args : TBase
    {

      public MakeDecision_args() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("MakeDecision_args");
        oprot.WriteStructBegin(struc);
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("MakeDecision_args(");
        sb.Append(")");
        return sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class MakeDecision_result : TBase
    {
      private string _success;

      public string Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public MakeDecision_result() {
      }

      public void Read (TProtocol iprot)
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 0:
              if (field.Type == TType.String) {
                Success = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }

      public void Write(TProtocol oprot) {
        TStruct struc = new TStruct("MakeDecision_result");
        oprot.WriteStructBegin(struc);
        TField field = new TField();

        if (this.__isset.success) {
          if (Success != null) {
            field.Name = "Success";
            field.Type = TType.String;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            oprot.WriteString(Success);
            oprot.WriteFieldEnd();
          }
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }

      public override string ToString() {
        StringBuilder sb = new StringBuilder("MakeDecision_result(");
        sb.Append("Success: ");
        sb.Append(Success);
        sb.Append(")");
        return sb.ToString();
      }

    }

  }
}
