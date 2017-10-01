# Partial Foods

This is a sample set of services that represents an event-sourcing sample for a _retail grocery chain_ domain. The architecture is based on CQRS. 

There is a command service that receives incoming comands from POS terminals in the form of transactions. If a transaction is accepted, it becomes an event and is emitted, allowing the rest of the system to react accordingly. The services in this suite that do not need to support an external GUI are **gRPC** services, and the client-supporting services are **RESTful**.
