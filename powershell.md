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


# Fix: Terminate files with Newline

[SA1518](https://github.com/DotNetAnalyzers/StyleCopAnalyzers/blob/master/documentation/SA1518.md) Fix

```powershell

gci -recurse -Filter *.cs | % {
  $content = gc -raw $_
  if($content[-1] -ne "}") {
    $content + "`n" | out-file -NoNewline $_ 
  } 
 }
```
