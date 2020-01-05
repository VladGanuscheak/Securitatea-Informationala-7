 param([String]$domain)

 function NetworkRule-Unblock-Host() {
    Remove-NetFirewallRule -DisplayName "Block $domain"
 }

 NetworkRule-Unblock-Host($domain)