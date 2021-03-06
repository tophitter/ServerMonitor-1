﻿using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Bubblegum.Service.EDM;
using Common;

namespace Bubblegum.Service.Code
{
	public partial class Server
	{
		public async Task SendDataAsync(SrvMonSummary summary, string password)
		{
			await Task.Factory.StartNew(() => SendData(summary, password));
		}
		private static void SendData(SrvMonSummary summary, string password)
		{
				using (var db = new candykingdomdbEntities())
				{
					try
					{
						if (!Auth(summary.Config.UserId, password))
						{
							throw new FaultException("Authentication failed for " + summary.Config.UserId);
						}
					if (!db.servers.Any(s => s.ServerGUID == summary.Config.ServerId))
					{
						//add server
						db.servers.Add(new servers
						{
							ServerGUID = summary.Config.ServerId,
							UserID = db.AspNetUsers.Single(u => u.UserName == summary.Config.UserId).Id,
							HostName = summary.Config.HostName,
							OnlineTime = DateTime.Now,
							UtcTime = DateTime.Now.ToUniversalTime(),
							MonitoredServices = summary.Config.MonitoredServices,
							TopCpuProcesses = summary.Config.TopCpuProcesses,
							TopRamProcesses = summary.Config.TopRamProcesses,
							HwMonTimeSpan = summary.Config.HwMonTimeSpan,
							EvMonTimeSpan = summary.Config.EvMonTimeSpan,
							ServiceTimer = summary.Config.ServiceTimer,
							AgentVersion = summary.AgentVersion,
							IsConfigChanged = true
						});
						db.SaveChanges();
					}
					if (summary.ValidationErrors().Count==0)
						{
							//get server from db
							var serverInDb = db.servers.Single(s => s.ServerGUID == summary.Config.ServerId);
							serverInDb.OnlineTime = Convert.ToDateTime(summary.OnlineTime);
							serverInDb.UtcTime = Convert.ToDateTime(summary.UtcTime);
							serverInDb.AgentVersion = summary.AgentVersion;
							serverInDb.HostName = summary.Config.HostName;
							serverInDb.RAMTotal = summary.RamTotal;
							serverInDb.RAMFree = summary.RamFree;
							serverInDb.CPULoad = summary.CpuLoad;
							serverInDb.MonitoredServices = summary.Config.MonitoredServices;
							serverInDb.TopCpuProcesses = summary.Config.TopCpuProcesses;
							serverInDb.TopRamProcesses = summary.Config.TopRamProcesses;
							serverInDb.HwMonTimeSpan = summary.Config.HwMonTimeSpan;
							serverInDb.EvMonTimeSpan = summary.Config.EvMonTimeSpan;
							serverInDb.ServiceTimer = summary.Config.ServiceTimer;
							db.SaveChanges();
							//populate servicemonitor table
							if (summary.ServiceStates != null)
							{
								UpdateServicemonitor(summary);
							}
							//populate procmonitor table
							if ((summary.TopCpuProcesses != null) && (summary.TopRamProcesses != null))
							{
								UpdateProcmonitor(summary);
							}
							//populate diskmonitor table
							if (summary.LocalDrives != null)
							{
								UpdateDiskMonitor(summary);
							}
							//populate eventmonitor table
							if (summary.Events != null)
							{
								UpdateEventMonitor(summary);
							}
							//populate hardwarehistory table
							UpdateHardwareHistory(summary);
						}
						else
						{
							var sb = new StringBuilder();
							sb.AppendLine("Wrong data from " + summary.Config.ServerId);
							sb.AppendLine("Login: " + summary.Config.UserId+";\t Password: " + password);
							foreach (var error in summary.ValidationErrors())
							{
								sb.AppendLine(error);
							}
							sb.ToString().WriteLog(EventLogEntryType.Error, 100);
						}
					}
				catch (InvalidOperationException ex)
				{
					(ex.Message + ex.InnerException).WriteLog(EventLogEntryType.Error, 100);
					foreach (var server in db.servers.Where(s => s.ServerGUID == summary.Config.ServerId))
					{
						db.servers.Remove(server);
					}
					db.SaveChanges();
				}
				catch (Exception ex) when (ex is NullReferenceException || ex is FormatException || ex is FaultException)
				{
					(ex.Message + ex.InnerException).WriteLog(EventLogEntryType.Error, 100);
					throw new FaultException(ex.Message);
				}
			}
		}
	}
}