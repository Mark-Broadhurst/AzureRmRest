namespace Fake.AzureRm
    type ResourceManager = 
        new : subscriptionId : string * tenantId : string * clientId : string * clientSecret : string -> ResourceManager
        member SubscriptionId : string
        member TenantId : string
        member CreateResourceGroup : (string -> Location -> Async<Response>)
        member CreateAppServicePlan : (string -> string -> WebAppServiceSku -> Location -> int -> Async<Response>)
        member CreateAppService : (string -> string -> string -> Location -> Async<Response>)
        member CreateSqlServer : (string -> string -> string -> string -> Location -> Async<Response>)
        member CreateSqlDatabase : (string -> string -> string -> DatabaseSku -> Location -> string -> Async<Response>)