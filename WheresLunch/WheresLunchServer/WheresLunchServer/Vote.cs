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

  /// <summary>
  /// Struct represents a single vote
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Vote : TBase
  {
    private string _Name;
    private string _Place;

    public string Name
    {
      get
      {
        return _Name;
      }
      set
      {
        __isset.Name = true;
        this._Name = value;
      }
    }

    public string Place
    {
      get
      {
        return _Place;
      }
      set
      {
        __isset.Place = true;
        this._Place = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Name;
      public bool Place;
    }

    public Vote() {
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
            if (field.Type == TType.String) {
              Name = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Place = iprot.ReadString();
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
      TStruct struc = new TStruct("Vote");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Name != null && __isset.Name) {
        field.Name = "Name";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Name);
        oprot.WriteFieldEnd();
      }
      if (Place != null && __isset.Place) {
        field.Name = "Place";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Place);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Vote(");
      sb.Append("Name: ");
      sb.Append(Name);
      sb.Append(",Place: ");
      sb.Append(Place);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
