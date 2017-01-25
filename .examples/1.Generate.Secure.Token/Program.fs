
open System
open Fake.AzureRm.Auth

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let tenantId = Environment.GetEnvironmentVariable("FAKE_AZURERM_EXAMPLES_TEN_ID")
    let clientId = Environment.GetEnvironmentVariable("FAKE_AZURERM_EXAMPLES_APP_ID")
    let secret = Environment.GetEnvironmentVariable("FAKE_AZURERM_EXAMPLES_SECRET")
    let bearerTokenChoice = GetAuth tenantId clientId secret |> Async.RunSynchronously
    let bearerTokenHeader = bearerTokenChoice;
    printf "Do it %s" (bearerTokenHeader.ToString())
    0
