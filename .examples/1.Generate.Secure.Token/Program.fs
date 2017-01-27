
open System

open Fake.AzureRm

open Fake.AzureRm.Env

open Fake.AzureRm.Auth

open Fake.AzureRm.Rest

open Fake.AzureRm.Resources

open Newtonsoft.Json

[<EntryPoint>]
let main argv = 
    
    let e = GetEnvironment()

    let r = new ResourceManager (e.SubscriptionId, e.TenantId, e.ApplicationId, (e.Secret + "balls"))

    Console.WriteLine "Created resource manager ... "

    Console.ReadLine () |> ignore
    
    0
