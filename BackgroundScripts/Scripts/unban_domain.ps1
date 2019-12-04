param(
    # $smtpServer Enter Your SMTP Server Hostname or IP Address
    [Parameter(Mandatory=$True,Position=0)]
    [ValidateNotNull()]
    [string]$domain
)

$hosts = 'C:\Windows\System32\drivers\etc\hosts'

$is_blocked = Get-Content -Path $hosts | Select-String -Pattern ([regex]::Escape($domain))

If($is_blocked) {
	$newhosts = Get-Content -Path $hosts |
	Where-Object {
		$_ -notmatch ([regex]::Escape($domain))
	}

    Set-Content -Path $hosts -Value $newhosts
}