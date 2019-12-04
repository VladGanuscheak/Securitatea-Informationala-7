using BackgroundScripts.Interfaces;
using BackgroundScripts.Options;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BackgroundScripts
{
    public class BackgroundScripts : IBackgroundScripts
    {
        private readonly IPathProvider _pathProvider;
        private readonly IOptions<BanDomainOptions> _banDomainOptions;
        private readonly IOptions<UnbanDomainOptions> _unbanDomainOptions;
        private readonly IOptions<SendEmailAnonymous> _sendEmailOptions;

        public BackgroundScripts(IOptions<BanDomainOptions> banDomainOptions,
            IOptions<UnbanDomainOptions> unbanDomainOptions, IOptions<SendEmailAnonymous> sendEmailOptions, IPathProvider pathProvider)
        {
            _banDomainOptions = banDomainOptions;
            _unbanDomainOptions = unbanDomainOptions;
            _pathProvider = pathProvider;
            _sendEmailOptions = sendEmailOptions;
        }

        public Task BanDomain(string domainName)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var process = new Process())
                    {
                        process.StartInfo = new ProcessStartInfo
                        {
                            FileName = @"C:\Program Files\PowerShell\6\pwsh.exe",
                            Arguments = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? $"{_pathProvider.MapPath($@"Scripts\ban_domain.ps1")} -domain {domainName}" : $"{_pathProvider.MapPath($@"Scripts\ban_domain_iptables.sh")}",
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        process.Start();

                        Debug.WriteLine($"Output: {process.StandardOutput.ReadToEnd()}");
                        Debug.WriteLine($"Error: {process.StandardError.ReadToEnd()}");

                        process.WaitForExit();

                        Debug.WriteLine($"Status: {process.ExitCode} Execution Time: {process.ExitTime}");
                    }
                }
                catch (Exception exception)
                {
                    var category = (exception.GetType()).ToString();
                    Debug.WriteLine($"{category}: {exception.Message}");
                }
            });
        }

        public async Task SendEmailAnonymous()
        {
            await Task.Run(() =>
            {
                try
                {
                    using (var process = new Process())
                    {
                        process.StartInfo = new ProcessStartInfo
                        {
                            FileName = @"C:\Program Files\PowerShell\6\pwsh.exe",
                            Arguments = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? $"{_pathProvider.MapPath($@"Scripts\send_email_anonymous.ps1")}" : $"{_pathProvider.MapPath($@"Scripts\send_email_anonymous.sh")}",
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        process.Start();

                        Debug.WriteLine($"Output: {process.StandardOutput.ReadToEnd()}");
                        Debug.WriteLine($"Error: {process.StandardError.ReadToEnd()}");

                        process.WaitForExit();

                        Debug.WriteLine($"Status: {process.ExitCode} Execution Time: {process.ExitTime}");
                    }
                }
                catch (Exception exception)
                {
                    var category = (exception.GetType()).ToString();
                    Debug.WriteLine($"{category}: {exception.Message}");
                }
            });
        }

        public Task UnbanDomain(string domainName)
        {
            return Task.Run(() =>
            {
                try
                {
                    using (var process = new Process())
                    {
                        process.StartInfo = new ProcessStartInfo
                        {
                            FileName = @"C:\Program Files\PowerShell\6\pwsh.exe",
                            Arguments = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? $"{_pathProvider.MapPath($@"Scripts\unban_domain.ps1")} -domain {domainName}" : $"{_pathProvider.MapPath($@"Scripts\unban_domain_iptables.sh")}",
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        process.Start();

                        Debug.WriteLine($"Output: {process.StandardOutput.ReadToEnd()}");
                        Debug.WriteLine($"Error: {process.StandardError.ReadToEnd()}");

                        process.WaitForExit();

                        Debug.WriteLine($"Status: {process.ExitCode} Execution Time: {process.ExitTime}");
                    }
                }
                catch (Exception exception)
                {
                    var category = (exception.GetType()).ToString();
                    Debug.WriteLine($"{category}: {exception.Message}");
                }
            });
        }
    }
}
