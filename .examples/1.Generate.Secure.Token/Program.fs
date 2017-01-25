
open System
open Fake.AzureRm.Auth
open Newtonsoft.Json

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let tenantId = Environment.GetEnvironmentVariable("FAKE_AZURERM_EXAMPLES_TEN_ID")
    let clientId = Environment.GetEnvironmentVariable("FAKE_AZURERM_EXAMPLES_APP_ID")
    let secret = "balls"//Environment.GetEnvironmentVariable("FAKE_AZURERM_EXAMPLES_SECRET")
    let bearerToken = GetAuth tenantId clientId secret |> Async.RunSynchronously
    match bearerToken with
    | Choice1Of2 x -> printf "%s" (x.ToString()) // GVDM: This works great if you can find the right tenant without powershell, see todo in docs.
    | Choice2Of2 x -> printf "Fail %s" (x.ToString()) // GVDM: How do we make errors more simple? 
    0
