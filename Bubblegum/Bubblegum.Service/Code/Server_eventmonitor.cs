﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using Bubblegum.Service.EDM;
using Common;

namespace Bubblegum.Service.Code
{
	public partial class Server
	{
		private static void UpdateEventMonitor(SrvMonSummary summary)
		{
			try
			{
				using (var db = new candykingdomdbEntities())
				{
					var serverInDb = db.servers.Single(s => s.ServerGUID == summary.Config.ServerId);
					foreach (var eventEntry in db.eventmonitor.Where(e => e.ServerID == serverInDb.ID))
					{
						//remove existing
						db.eventmonitor.Remove(eventEntry);
					}
					foreach (var eventEntry in summary.Events.OrderByDescending(e => e.Count).Take(20))
					{
						db.eventmonitor.Add(new eventmonitor
						{
							EventGUID = Guid.NewGuid(),
							ServerID = serverInDb.ID,
							Code = (int)eventEntry.Code,
							Source = eventEntry.Source,
							Text = eventEntry.Text,
							Count = eventEntry.Count,
							LastTimeStamp = Convert.ToDateTime(eventEntry.LastTimeStamp)
						});
					}
					db.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				(ex.Message + ex.InnerException).WriteLog(EventLogEntryType.Warning, 103);
			}
			catch (DbUpdateConcurrencyException ex)
			{
				(ex.Message + ex.InnerException).WriteLog(EventLogEntryType.Warning, 103);
			}
			catch (SocketException ex)
			{
				(ex.Message + ex.InnerException).WriteLog(EventLogEntryType.Error, 103);
			}
			catch (InvalidOperationException ex)
			{
				(ex.Message + ex.InnerException).WriteLog(EventLogEntryType.Error, 103);
			}
		}
	}
}