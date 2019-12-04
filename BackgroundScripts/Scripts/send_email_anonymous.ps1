param(
    # $smtpServer Enter Your SMTP Server Hostname or IP Address
    [Parameter(Mandatory=$True,Position=0)]
    [ValidateNotNull()]
    [string]$smtpServer,
    # Notify Users if Expiry Less than X Days
    [Parameter(Mandatory=$True,Position=1)]
    [ValidateNotNull()]
    [string]$to,
    # From Address, eg "IT Support <support@domain.com>"
    [Parameter(Mandatory=$True,Position=2)]
    [ValidateNotNull()]
    [string]$from,
	[Parameter(Position=3)]
	[ValidateNotNull()]
	[string]$subject,
    [Parameter(Position=4)]
	[ValidateNotNull()]
	[string]$body,
    # Test Recipient, eg recipient@domain.com
    [Parameter(Position=8)]
    [string]$testRecipient,
    # Log file recipient
    [Parameter(Position=10)]
	[string]$username,
	[Parameter(Position=11)]
	[string]$password,
	[Parameter(Position=12)]
	[string]$reply
)
###################################################################################################################

[System.Net.ServicePointManager]::ServerCertificateValidationCallback = { return $true }

$textEncoding = [System.Text.Encoding]::UTF8

# Process notifying

	#Sends mail notification from this user
	$secpasswd = ConvertTo-SecureString $password -AsPlainText -Force
	$credentials = New-Object System.Management.Automation.PSCredential ($username, $secpasswd)

	Send-Mailmessage -smtpServer $smtpServer -From $from -To $to -Subject $subject -body $Body -bodyasHTML -Priority High -Encoding $textEncoding -ErrorAction Stop -Credential $credentials -UseSsl -Port 587 -ReplyTo $reply

# End
