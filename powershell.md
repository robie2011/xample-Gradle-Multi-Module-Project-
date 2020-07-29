# Powershell

```powershell

 gi .\schemas\nak\*.json | %{ 
     $nCols =(gc $_  | ConvertFrom-Json | select -Property @{Name="cols";Expression={$_.meta.countColumns}})
     $props = @{
        name=$_.Name
        nCols = $nCols.cols
     }
     return New-Object psobject -Property $props
}
```