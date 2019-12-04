iptables -F INPUT
iptables -L INPUT
iptables -A INPUT -m state --state ESTABLISHED,RELATED -j ACCEPT
iptables -L INPUT
iptables -I INPUT -s "facebook.com" -j DROP
iptables -L INPUT
iptables -L INPUT -n
