// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: ordermgmt.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace PartialFoods.Services {

  /// <summary>Holder for reflection information generated from ordermgmt.proto</summary>
  public static partial class OrdermgmtReflection {

    #region Descriptor
    /// <summary>File descriptor for ordermgmt.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static OrdermgmtReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg9vcmRlcm1nbXQucHJvdG8SFVBhcnRpYWxGb29kcy5TZXJ2aWNlcxoScGFy",
            "dGlhbGZvb2RzLnByb3RvIiIKD0dldE9yZGVyUmVxdWVzdBIPCgdPcmRlcklE",
            "GAEgASgJIsYBChBHZXRPcmRlclJlc3BvbnNlEg8KB09yZGVySUQYASABKAkS",
            "EQoJQ3JlYXRlZE9uGAIgASgEEg4KBlVzZXJJRBgDIAEoCRIPCgdUYXhSYXRl",
            "GAQgASgNEjkKDFNoaXBwaW5nSW5mbxgFIAEoCzIjLlBhcnRpYWxGb29kcy5T",
            "ZXJ2aWNlcy5TaGlwcGluZ0luZm8SMgoJTGluZUl0ZW1zGAYgAygLMh8uUGFy",
            "dGlhbEZvb2RzLlNlcnZpY2VzLkxpbmVJdGVtMm4KD09yZGVyTWFuYWdlbWVu",
            "dBJbCghHZXRPcmRlchImLlBhcnRpYWxGb29kcy5TZXJ2aWNlcy5HZXRPcmRl",
            "clJlcXVlc3QaJy5QYXJ0aWFsRm9vZHMuU2VydmljZXMuR2V0T3JkZXJSZXNw",
            "b25zZWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::PartialFoods.Services.PartialfoodsReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::PartialFoods.Services.GetOrderRequest), global::PartialFoods.Services.GetOrderRequest.Parser, new[]{ "OrderID" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::PartialFoods.Services.GetOrderResponse), global::PartialFoods.Services.GetOrderResponse.Parser, new[]{ "OrderID", "CreatedOn", "UserID", "TaxRate", "ShippingInfo", "LineItems" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GetOrderRequest : pb::IMessage<GetOrderRequest> {
    private static readonly pb::MessageParser<GetOrderRequest> _parser = new pb::MessageParser<GetOrderRequest>(() => new GetOrderRequest());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetOrderRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PartialFoods.Services.OrdermgmtReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetOrderRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetOrderRequest(GetOrderRequest other) : this() {
      orderID_ = other.orderID_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetOrderRequest Clone() {
      return new GetOrderRequest(this);
    }

    /// <summary>Field number for the "OrderID" field.</summary>
    public const int OrderIDFieldNumber = 1;
    private string orderID_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string OrderID {
      get { return orderID_; }
      set {
        orderID_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetOrderRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetOrderRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (OrderID != other.OrderID) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (OrderID.Length != 0) hash ^= OrderID.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (OrderID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(OrderID);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (OrderID.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(OrderID);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetOrderRequest other) {
      if (other == null) {
        return;
      }
      if (other.OrderID.Length != 0) {
        OrderID = other.OrderID;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            OrderID = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GetOrderResponse : pb::IMessage<GetOrderResponse> {
    private static readonly pb::MessageParser<GetOrderResponse> _parser = new pb::MessageParser<GetOrderResponse>(() => new GetOrderResponse());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetOrderResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::PartialFoods.Services.OrdermgmtReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetOrderResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetOrderResponse(GetOrderResponse other) : this() {
      orderID_ = other.orderID_;
      createdOn_ = other.createdOn_;
      userID_ = other.userID_;
      taxRate_ = other.taxRate_;
      ShippingInfo = other.shippingInfo_ != null ? other.ShippingInfo.Clone() : null;
      lineItems_ = other.lineItems_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetOrderResponse Clone() {
      return new GetOrderResponse(this);
    }

    /// <summary>Field number for the "OrderID" field.</summary>
    public const int OrderIDFieldNumber = 1;
    private string orderID_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string OrderID {
      get { return orderID_; }
      set {
        orderID_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "CreatedOn" field.</summary>
    public const int CreatedOnFieldNumber = 2;
    private ulong createdOn_;
    /// <summary>
    /// UTC milliseconds of time terminal created transaction
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ulong CreatedOn {
      get { return createdOn_; }
      set {
        createdOn_ = value;
      }
    }

    /// <summary>Field number for the "UserID" field.</summary>
    public const int UserIDFieldNumber = 3;
    private string userID_ = "";
    /// <summary>
    /// User ID of the order owner
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string UserID {
      get { return userID_; }
      set {
        userID_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "TaxRate" field.</summary>
    public const int TaxRateFieldNumber = 4;
    private uint taxRate_;
    /// <summary>
    /// Percentage rate of tax, whole numbers because reasons
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint TaxRate {
      get { return taxRate_; }
      set {
        taxRate_ = value;
      }
    }

    /// <summary>Field number for the "ShippingInfo" field.</summary>
    public const int ShippingInfoFieldNumber = 5;
    private global::PartialFoods.Services.ShippingInfo shippingInfo_;
    /// <summary>
    /// Information on where order is to be shipped
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::PartialFoods.Services.ShippingInfo ShippingInfo {
      get { return shippingInfo_; }
      set {
        shippingInfo_ = value;
      }
    }

    /// <summary>Field number for the "LineItems" field.</summary>
    public const int LineItemsFieldNumber = 6;
    private static readonly pb::FieldCodec<global::PartialFoods.Services.LineItem> _repeated_lineItems_codec
        = pb::FieldCodec.ForMessage(50, global::PartialFoods.Services.LineItem.Parser);
    private readonly pbc::RepeatedField<global::PartialFoods.Services.LineItem> lineItems_ = new pbc::RepeatedField<global::PartialFoods.Services.LineItem>();
    /// <summary>
    /// Individual line items on a transaction
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::PartialFoods.Services.LineItem> LineItems {
      get { return lineItems_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetOrderResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetOrderResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (OrderID != other.OrderID) return false;
      if (CreatedOn != other.CreatedOn) return false;
      if (UserID != other.UserID) return false;
      if (TaxRate != other.TaxRate) return false;
      if (!object.Equals(ShippingInfo, other.ShippingInfo)) return false;
      if(!lineItems_.Equals(other.lineItems_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (OrderID.Length != 0) hash ^= OrderID.GetHashCode();
      if (CreatedOn != 0UL) hash ^= CreatedOn.GetHashCode();
      if (UserID.Length != 0) hash ^= UserID.GetHashCode();
      if (TaxRate != 0) hash ^= TaxRate.GetHashCode();
      if (shippingInfo_ != null) hash ^= ShippingInfo.GetHashCode();
      hash ^= lineItems_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (OrderID.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(OrderID);
      }
      if (CreatedOn != 0UL) {
        output.WriteRawTag(16);
        output.WriteUInt64(CreatedOn);
      }
      if (UserID.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(UserID);
      }
      if (TaxRate != 0) {
        output.WriteRawTag(32);
        output.WriteUInt32(TaxRate);
      }
      if (shippingInfo_ != null) {
        output.WriteRawTag(42);
        output.WriteMessage(ShippingInfo);
      }
      lineItems_.WriteTo(output, _repeated_lineItems_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (OrderID.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(OrderID);
      }
      if (CreatedOn != 0UL) {
        size += 1 + pb::CodedOutputStream.ComputeUInt64Size(CreatedOn);
      }
      if (UserID.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(UserID);
      }
      if (TaxRate != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(TaxRate);
      }
      if (shippingInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ShippingInfo);
      }
      size += lineItems_.CalculateSize(_repeated_lineItems_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetOrderResponse other) {
      if (other == null) {
        return;
      }
      if (other.OrderID.Length != 0) {
        OrderID = other.OrderID;
      }
      if (other.CreatedOn != 0UL) {
        CreatedOn = other.CreatedOn;
      }
      if (other.UserID.Length != 0) {
        UserID = other.UserID;
      }
      if (other.TaxRate != 0) {
        TaxRate = other.TaxRate;
      }
      if (other.shippingInfo_ != null) {
        if (shippingInfo_ == null) {
          shippingInfo_ = new global::PartialFoods.Services.ShippingInfo();
        }
        ShippingInfo.MergeFrom(other.ShippingInfo);
      }
      lineItems_.Add(other.lineItems_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            OrderID = input.ReadString();
            break;
          }
          case 16: {
            CreatedOn = input.ReadUInt64();
            break;
          }
          case 26: {
            UserID = input.ReadString();
            break;
          }
          case 32: {
            TaxRate = input.ReadUInt32();
            break;
          }
          case 42: {
            if (shippingInfo_ == null) {
              shippingInfo_ = new global::PartialFoods.Services.ShippingInfo();
            }
            input.ReadMessage(shippingInfo_);
            break;
          }
          case 50: {
            lineItems_.AddEntriesFrom(input, _repeated_lineItems_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
