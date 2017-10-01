// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: partialfoods.proto
#pragma warning disable 1591
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using grpc = global::Grpc.Core;

namespace PartialFoods.Services {
  public static partial class PointOfSaleCommand
  {
    static readonly string __ServiceName = "PartialFoods.Services.PointOfSaleCommand";

    static readonly grpc::Marshaller<global::PartialFoods.Services.PointOfSaleTransaction> __Marshaller_PointOfSaleTransaction = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PartialFoods.Services.PointOfSaleTransaction.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PartialFoods.Services.TransactionSubmissionResponse> __Marshaller_TransactionSubmissionResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PartialFoods.Services.TransactionSubmissionResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::PartialFoods.Services.PointOfSaleTransaction, global::PartialFoods.Services.TransactionSubmissionResponse> __Method_SubmitTransaction = new grpc::Method<global::PartialFoods.Services.PointOfSaleTransaction, global::PartialFoods.Services.TransactionSubmissionResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SubmitTransaction",
        __Marshaller_PointOfSaleTransaction,
        __Marshaller_TransactionSubmissionResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::PartialFoods.Services.PartialfoodsReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PointOfSaleCommand</summary>
    public abstract partial class PointOfSaleCommandBase
    {
      public virtual global::System.Threading.Tasks.Task<global::PartialFoods.Services.TransactionSubmissionResponse> SubmitTransaction(global::PartialFoods.Services.PointOfSaleTransaction request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for PointOfSaleCommand</summary>
    public partial class PointOfSaleCommandClient : grpc::ClientBase<PointOfSaleCommandClient>
    {
      /// <summary>Creates a new client for PointOfSaleCommand</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public PointOfSaleCommandClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for PointOfSaleCommand that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public PointOfSaleCommandClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected PointOfSaleCommandClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected PointOfSaleCommandClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::PartialFoods.Services.TransactionSubmissionResponse SubmitTransaction(global::PartialFoods.Services.PointOfSaleTransaction request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return SubmitTransaction(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::PartialFoods.Services.TransactionSubmissionResponse SubmitTransaction(global::PartialFoods.Services.PointOfSaleTransaction request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SubmitTransaction, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::PartialFoods.Services.TransactionSubmissionResponse> SubmitTransactionAsync(global::PartialFoods.Services.PointOfSaleTransaction request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return SubmitTransactionAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::PartialFoods.Services.TransactionSubmissionResponse> SubmitTransactionAsync(global::PartialFoods.Services.PointOfSaleTransaction request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SubmitTransaction, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override PointOfSaleCommandClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new PointOfSaleCommandClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(PointOfSaleCommandBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SubmitTransaction, serviceImpl.SubmitTransaction).Build();
    }

  }
}
#endregion
