(Get-Clipboard).Split('\n') | % { $rex.Replace($_, "") } | % { $_[0] + $_[$_.length - 1] } | % { [System.Convert]::ToInt32($_) } | measure-object -sum
