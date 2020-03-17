param (
    [Parameter(Mandatory = $True)]
    $GitBranch = "master",
    [Parameter(Mandatory = $True)]
    $SlackCommandToken,  
    [Parameter(Mandatory = $True)]
    $SlackChannelId,
    [Parameter(Mandatory = $True)]
    $EnvironmentDomain,
    [Parameter(Mandatory = $True)]
    $Market,
    [Parameter(Mandatory = $True)]
    $EnvironmentName,
    $CIServerEndpoint = "https://api.buildkite.com/v2/organizations/boden/pipelines/destroy/builds",
    $CIServerAccessToken
)

$ErrorActionPreference = "Stop"

function Issue-WebRequest ($endpoint) {
    Write-Host "Endpoint is $endpoint"

    $requestBody = @"
{
    "commit": "HEAD",
    "branch": "${GitBranch}",
    "message": "Triggered by TFS at $(Get-Date -Format g) from $($env:BUILD_REPOSITORY_NAME)",
    "author": {
      "name": "$(& whoami)",
      "email": "peter.arnold@boden.co.uk"
    },
    "env": {
        "EnvironmentName":"$($EnvironmentName)",
        "Market" : "$($Market)",      
        "Token" : "$($SlackCommandToken)",
        "ChannelId" : "$($SlackChannelId)",
        "SelfServiceUrl" : "https://api.$($EnvironmentDomain)/self-service/prod/slack/command/environment"
    },
    "meta_data": {
    }
  }
"@

    $headers = @{}
    $headers.Add('Authorization' , "Bearer $CIServerAccessToken")

    try {
        Write-Host "Running: Invoke-WebRequest -Uri $($endpoint) -Headers $($headers) -ContentType ""application/json"" -Method ""POST"" -Body $($requestBody) -Proxy $($env:HTTP_PROXY)"

        Invoke-WebRequest -Uri $endpoint `
            -Headers $headers `
            -ContentType "application/json" `
            -Method "POST" `
            -Body $requestBody `
            -Proxy $env:HTTP_PROXY
    }
    catch {
        Write-Output $_.Exception | Format-List -force
        Write-Host "Error: running Invoke-WebRequest -Uri $($endpoint) -Headers $($headers) -ContentType ""application/json"" -Method ""POST"" -Body $($requestBody) -Proxy $($env:HTTP_PROXY)"
    }
}

# Main body of program
try {   
    Issue-WebRequest -endpoint $CIServerEndpoint
}
catch {
    Write-Output $_.Exception | Format-List -force   
}