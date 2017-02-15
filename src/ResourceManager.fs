namespace AzureRmRest

open Auth
open Resources

    type ResourceManager(subscriptionId, tenantId, clientId, clientSecret) = 
        let token = GetAuth tenantId clientId clientSecret
                    |> Async.RunSynchronously
                    |> (fun x -> 
                        printf "%A" x
                        x)
                    |> AsyncChoice
        member x.SubscriptionId = subscriptionId
        member x.TenantId = tenantId
        member x.CreateResourceGroup = (CreateResourceGroup subscriptionId token)
        member x.CreateAppServicePlan = (CreateAppServicePlan subscriptionId token)
        member x.CreateAppService = (CreateAppService subscriptionId token)
        member x.CreateSqlServer = (CreateSqlServer subscriptionId token)
        member x.CreateSqlDatabase = (CreateSqlDatabase subscriptionId token)