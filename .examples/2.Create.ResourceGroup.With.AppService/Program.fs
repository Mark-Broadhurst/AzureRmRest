
open System
open Fake.AzureRm.Env
open Fake.AzureRm.Auth
open Fake.AzureRm.Rest
open Newtonsoft.Json

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let env = GetEnvironment()
    let bearerToken = GetToken (env) |> Async.RunSynchronously
    match bearerToken with
    | Choice1Of2 x -> printf "%s" (x.ToString()) 
    | Choice2Of2 (Error(x,y)) -> printf "Fail %s" (x.ToString()) 
    Console.ReadLine () |> ignore
    0
