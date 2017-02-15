module AzureRmRest.Env

open System

type Env = 
    {
       SubscriptionId:string
       TenantId:string
       ApplicationId:string
       Secret:string
    }

let GetEnvironment () =
    {
        SubscriptionId = Environment.GetEnvironmentVariable("AZURERM_SUB_ID")
        TenantId = Environment.GetEnvironmentVariable("AZURERM_TEN_ID")
        ApplicationId = Environment.GetEnvironmentVariable("AZURERM_APP_ID")
        Secret = Environment.GetEnvironmentVariable("AZURERM_SECRET")
    }