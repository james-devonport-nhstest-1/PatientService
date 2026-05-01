## Setup
### Prerequisites
- You must have the latest version of the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) installed
- _Optional_: If you wish to run this as a container, you will need [Docker](https://docs.docker.com/get-started/get-docker/)

### How to get started

1. Download the project, either via Git CLI or by downloading the zip of master
2. Open the `PatientService.sln` in your IDE of choice, or open the parent folder if you use an editor as your IDE (such as VS Code)
3. Build the solution and run the PatientService.Api


## Behaviours
### GetPatientById

To receive data about a specific patient, we can use the following endpoint:
```
GET https://localhost:{port}/api/patients/{id}
```
The default port is 5063

The `id` parameter is required, and must be a non-negative integer corresponding to the patient Id
