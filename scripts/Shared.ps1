function Get-PropertyFromJsonFile ($propertyName, $fileName) {
    Write-Host "Attempting to find $propertyName in $fileName"

    $json = (Get-Content $fileName -Raw) | ConvertFrom-Json
    
    Write-Verbose $json

    $return = $json.psobject.Properties[$propertyName].Value
    return $return
}

function Get-SiteResponse (
    [Parameter(Mandatory = $True)] [string] $uri, 
    [Parameter(Mandatory = $True)] [scriptblock] $predicate,
    $proxy,
    $headers) {
    try {
        Write-Host -NoNewline "."
        
        $response = Invoke-WebRequest -Proxy $proxy -Uri $uri -Headers $headers
        
        return $response | Where-Object $predicate
    }
    catch {
        Write-Verbose $_.Exception | Format-List -force
        Write-Verbose "# StatusCode Found #: $($response.StatusCode)"
        return $False;
    }
}

function Ensure-PropertySet {
    param(
        [Parameter(Mandatory = $True)]
        [ref]
        $property,
        [Parameter(Mandatory = $True)]
        $propertyName,
        [Parameter(Mandatory = $True)]
        $propertiesFile
    )

    if (!$property.Value) {
        $property.Value = Get-PropertyFromJsonFile -propertyName $propertyName -fileName $propertiesFile
        
        if (!$property.Value) {
            throw "$propertyName not found via parameter or in $propertiesFile"
        }

    } else {
        Write-Warning -Message "Using $($propertyName) :-> $($property.Value)"
    }
}