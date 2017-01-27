namespace Fake.AzureRm

open Auth
open Resources

    type ResourceManager(subscriptionId, tenantId, clientId, clientSecret) = 
        let token = GetAuth tenantId clientId clientSecret
                    |> Async.RunSynchronously
                    |> AsyncChoice
        member this.SubscriptionId = subscriptionId
        member this.TenantId = tenantId
        member this.ClientId = clientId
        member this.ClientSecret = clientSecret
        member this.CreateResourceGroup = (CreateResourceGroup subscriptionId token)
        member this.CreateAppServicePlan name sku capacity = (CreateAppServicePlan subscriptionId token)
        member this.CreateAppService planName name = (CreateAppService subscriptionId token)
        member this.CreateSqlServer serverName username password = (CreateSqlServer subscriptionId token)
        member this.CreateSqlDatabase serverName databaseName sku = (CreateSqlDatabase subscriptionId token)