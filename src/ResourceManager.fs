namespace Fake.AzureRm

open Auth
open Resources

    type ResourceManager(subscriptionId, tenantId, clientId, clientSecret) = 
        let token = GetAuth tenantId clientId clientSecret
                    |> Async.RunSynchronously
                    |> (fun x -> 
                        printf "%A" x
                        x)
                    |> AsyncChoice
        member this.SubscriptionId = subscriptionId
        member this.TenantId = tenantId
        member this.CreateResourceGroup = (CreateResourceGroup subscriptionId token)
        member this.CreateAppServicePlan = (CreateAppServicePlan subscriptionId token)
        member this.CreateAppService = (CreateAppService subscriptionId token)
        member this.CreateSqlServer serverName username password = (CreateSqlServer subscriptionId token)
        member this.CreateSqlDatabase serverName databaseName sku = (CreateSqlDatabase subscriptionId token)