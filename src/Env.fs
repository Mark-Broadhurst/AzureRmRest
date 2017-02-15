module Fake.AzureRm.Env

open System

type Env(sub, ten, app, sec) = 
    member x.SubscriptionId = sub;
    member x.TenantId = ten;
    member x.ApplicationId = app;
    member x.Secret = sec;

let GetEnvironment () =
    let subscriptionId = Environment.GetEnvironmentVariable("AZURERM_SUB_ID")
    let tenantId = Environment.GetEnvironmentVariable("AZURERM_TEN_ID")
    let clientId = Environment.GetEnvironmentVariable("AZURERM_APP_ID")
    let secret = Environment.GetEnvironmentVariable("AZURERM_SECRET")
    Env(subscriptionId, tenantId, clientId, secret)