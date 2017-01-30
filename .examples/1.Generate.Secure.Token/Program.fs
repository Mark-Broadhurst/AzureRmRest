open Fake.AzureRm
open Fake.AzureRm.Env

[<EntryPoint>]
let main argv = 
    // If you see a bearer token in the console output, then your envrionment variables
    // are set correctly
    let e = GetEnvironment()
    let r = new ResourceManager (e.SubscriptionId, e.TenantId, e.ApplicationId, e.Secret)
    printf "Created resource manager ... "
    0
