open Fake.AzureRm
open Fake.AzureRm.Env

[<EntryPoint>]
let main argv = 
    let e = GetEnvironment()
    let r = new ResourceManager (e.SubscriptionId, e.TenantId, e.ApplicationId, e.Secret)
    let version = 1;
    let location = "northeurope"
    let resource = ( sprintf "fake-azurerm-examples-resource-%i" version )
    let plan = ( sprintf "fake-azurerm-examples-plan-%i" version )
    let appService = ( sprintf "fake-azurerm-examples-app-service-%i" version )
    r.CreateResourceGroup resource location |> Async.RunSynchronously |> ignore
    r.CreateAppServicePlan resource plan "S1" location 1 |> Async.RunSynchronously |> ignore
    r.CreateAppService resource plan appService location |> Async.RunSynchronously |> ignore
    // TODO: Figure out how to upload the app service
    0
