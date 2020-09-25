using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

using Maximus.ControlCenter.Tasks.Module.Global;
using Maximus.Library.Helpers;
using Maximus.Library.ManagedModuleBase;

using Microsoft.EnterpriseManagement.HealthService;

namespace Maximus.ControlCenter.Tasks.Module.Events
{
  [MonitoringModule(ModuleType.ReadAction)]
  [ModuleOutput(true)]
  class ReadEventLogPA : ModuleBaseSimpleAction<EventListDataItem>
  {
    // Configuration
    private string LogName = "Application", SearchString, XPathQuery;
    private int MaxEvents = 100, MaxSearchEvents = 1000;
    private bool SearchUseRegExp = false;

    public ReadEventLogPA(ModuleHost<EventListDataItem> moduleHost, XmlReader configuration, byte[] previousState) : base(moduleHost, configuration, previousState)
    {
    }

    protected override void PreInitialize(ModuleHost<EventListDataItem> moduleHost, XmlReader configuration, byte[] previousState)
    {
      ModInit.Logger.AddLoggingSource(GetType(), ModInit.evtId_ReadEventLogPA);
      base.PreInitialize(moduleHost, configuration, previousState);
    }

    protected override EventListDataItem[] GetOutputData(DataItemBase[] inputDataItems)
    {
      try
      {
        using (EventLogSession eventLogSession = new EventLogSession())
        {
          EventLogQuery eventLogQuery = string.IsNullOrWhiteSpace(XPathQuery) ?
            new EventLogQuery(LogName, PathType.LogName)
            {
              Session = eventLogSession,
              TolerateQueryErrors = true,
              ReverseDirection = true
            } :
            new EventLogQuery(LogName, PathType.LogName, XPathQuery)
            {
              Session = eventLogSession,
              TolerateQueryErrors = true,
              ReverseDirection = true
            };
          int returnedEventsCounter = MaxEvents;
          int searchedEventsCounter = MaxSearchEvents;
          List<EventInfo> eventList = new List<EventInfo>(MaxEvents);
          using (EventLogReader eventLogReader = new EventLogReader(eventLogQuery))
          {
            eventLogReader.Seek(System.IO.SeekOrigin.Begin, 0); // from latest event to the past. ReverseDirection swaps End and Begin for seek method
            do
            {
              if (returnedEventsCounter <= 0 || searchedEventsCounter <= 0)
                break;

              EventRecord eventData = eventLogReader.ReadEvent();
              searchedEventsCounter--;
              if (eventData == null)
                break;

              if (string.IsNullOrWhiteSpace(SearchString))
              {
                eventList.Add(CreateEventInfo(eventData));
                returnedEventsCounter--;
              }
              else
              {
                if (Regex.IsMatch(eventData.FormatDescription() ?? "", SearchUseRegExp ? SearchString : Regex.Escape(SearchString), RegexOptions.IgnoreCase))
                {
                  eventList.Add(CreateEventInfo(eventData));
                  returnedEventsCounter--;
                }
              }
              eventData.Dispose();
            } while (true);
          }

          return new EventListDataItem[]
          {
            new EventListDataItem(new EventList
            {
              Events = eventList,
              ErrorCode = 0,
              ErrorMessage = ""
            })
        };
        }
      }
      catch (Exception e)
      {
        ModuleErrorSignalReceiver(ModuleErrorSeverity.DataLoss, ModuleErrorCriticality.Continue, e, $"Failed to query local {LogName ?? "NULL"} event log using {XPathQuery ?? "NULL"} XPath query: {e.Message}");
        return new EventListDataItem[]
        {
          new EventListDataItem(new EventList
          {
            Events = new List<EventInfo>(),
            ErrorCode = e.HResult,
            ErrorMessage = $"Failed to query local {LogName} event log using {XPathQuery ?? "NULL"} XPath query: {e.Message}"
          })
        };
      }
    }

    private EventInfo CreateEventInfo(EventRecord eventData)
    {

      EventInfo result = new EventInfo
      {
        Computer = eventData.MachineName,
        EventId = eventData.Id,
        FormattedDescription = eventData.FormatDescription(),
        Logged = eventData.TimeCreated ?? DateTime.MinValue,
        LogName = eventData.LogName,
        RawXML = eventData.ToXml(),
        User = eventData.UserId?.ToString() ?? "N/A"
      };
      try
      {
        result.Keywords = eventData.KeywordsDisplayNames.Cast<object>().ToArray().EnumElements(); // ((object[])eventData.KeywordsDisplayNames).EnumElements(),
      }
      catch
      {
        result.Keywords = eventData.Keywords?.ToString() ?? "";
      }
      try
      {
        result.Source = eventData.ProviderName;
      }
      catch
      {
        result.Source = "";
      }
      try
      {
        result.TaskCategory = eventData.TaskDisplayName;
      }
      catch
      {
        result.TaskCategory = "";
      }
      try
      {
        result.Level = eventData.LevelDisplayName;
      }
      catch
      {
        result.Level = GetDefaultLevelName(eventData.Level);
      }
      if (string.IsNullOrWhiteSpace(result.FormattedDescription))
      {
        result.FormattedDescription = "Event description was not found. \r\n\r\nThe following information was included with the event: \r\n";
        if (eventData.Properties != null)
          foreach (EventProperty prop in eventData.Properties)
            result.FormattedDescription += $"{prop.Value?.ToString() ?? ""}\r\n";

      }
      return result;
    }

    private string GetDefaultLevelName(byte? code)
    {
      if (code == null)
        return "Unknown";
      switch (code)
      {
        case 4: return "Information";
        case 2: return "Error";
        case 3: return "Warning";
      }
      return code.ToString() ?? "Unknown";
    }

    protected override void LoadConfiguration(XmlDocument cfgDoc)
    {
      try
      {
        LoadConfigurationElement(cfgDoc, "LogName", out LogName);
        LoadConfigurationElement(cfgDoc, "MaxEvents", out MaxEvents, 100, false);
        LoadConfigurationElement(cfgDoc, "MaxSearchEvents", out MaxSearchEvents, 1000, false);
        LoadConfigurationElement(cfgDoc, "SearchString", out SearchString, null, false);
        LoadConfigurationElement(cfgDoc, "SearchUseRegExp", out SearchUseRegExp, false, false);
        LoadConfigurationElement(cfgDoc, "XPathQuery", out XPathQuery, null, false);

        ModInit.Logger.WriteInformation($"LogName: {LogName}; MaxEvents: {MaxEvents}; MaxSearchEvents: {MaxSearchEvents}; SearchString: [{SearchString}]; SearchUseRegExp: {SearchUseRegExp}; XPathQuery: {XPathQuery}", this);
      }
      catch (Exception e)
      {
        ModuleErrorSignalReceiver(ModuleErrorSeverity.FatalError, ModuleErrorCriticality.Stop, e, "Failed to load module configuration.");
        throw new ModuleException("Failed to load module configuration.", e);
      }
    }

    protected override void ModuleErrorSignalReceiver(ModuleErrorSeverity severity, ModuleErrorCriticality criticality, Exception e, string message, params object[] extaInfo)
    {
      ModInit.ModuleErrorSignalReceiver(severity, criticality, e, message, this);
    }
  }
}
