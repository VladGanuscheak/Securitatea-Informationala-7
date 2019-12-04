param(
    # $smtpServer Enter Your SMTP Server Hostname or IP Address
    [Parameter(Mandatory=$True,Position=0)]
    [ValidateNotNull()]
    [string]$domain
)

$hosts = 'C:\Windows\System32\drivers\etc\hosts'

$is_blocked = Get-Content -Path $hosts | Select-String -Pattern ([regex]::Escape($domain))

If(-not $is_blocked) {
	Add-Content -Path $hosts -Value "127.0.0.1 " + $domain
}