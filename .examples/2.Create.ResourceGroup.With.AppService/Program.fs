
open System
open Newtonsoft.Json
open Fake.AzureRm.Env
open Fake.AzureRm.Auth
open Fake.AzureRm.Rest
open Fake.AzureRm.Resources

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let env = GetEnvironment()
    let bearerToken = GetToken (env) |> Async.RunSynchronously
    match bearerToken with
    | Choice1Of2 token -> 
        printf "Token=%s" (token.ToString()) 
        CreateResourceGroup token env.SubscriptionId "my-new-resource-group" "northeurope" 
            |> Async.RunSynchronously 
            |> ignore
    | Choice2Of2 (Error(x,y)) -> 
        printf "Fail %s" (x.ToString()) 
            |> ignore
    Console.ReadLine () |> ignore
    0
