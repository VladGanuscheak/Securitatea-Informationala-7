 <#function Block-TrafficHost([String] $domain) {
    New-NetFirewallRule -DisplayName $domain -Direction Inbound -Action Block -RemoteAddress $domain
 }#>

param([String]$domain)

 function NetworkRule-Block-Host([String]$domain) {
    [System.Collections.ArrayList]$IPs = @()
    Resolve-DnsName -Name $domain -NoHostsFile | Foreach {$IPs.Add($($_.IPAddress))}
    New-NetFirewallRule -DisplayName "Block $domain" -Direction Outbound -Protocol ICMPv4 -Action Block -RemoteAddress $IPs
	New-NetFirewallRule -DisplayName "Block $domain" -Direction Outbound -Protocol TCP -Action Block -RemoteAddress $IPs
 }

 NetworkRule-Block-Host($domain)