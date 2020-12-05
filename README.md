# Maximus Control Center

## Introduction
Maximus Control Center is a System Center Operations Manager (SCOM) Management Pack
(compatible with SCOM 2016+),
which enables performing routine server administration tasks right from SCOM Console application 
without logging to remote server session.

The Management Pack implements automation tasks for individual operations and SCOM Console 
Extension, which brings all tasks together in a user-friendly interface.

All tasks are executed at the remote server locally using SCOM Agent run-as account. In other words,
the management pack does not require inbound connections for remote control, 
but only SCOM Agent outbound connection. This makes this way of remote controlling highly secure.

## Installation
To install Maximus Control Center first you need to install base library management pack: 
[Maximus.Base.Library](https://github.com/MaxxVolk/Maximus.Base.Library). After that
simply download [the latest release](https://github.com/MaxxVolk/Maximus.ControlCenter/releases/download/1.0.2.143/Maximus.ControlCenter.mpb)
and import it into your SCOM management group.

## Current Release
The latest release implements the following features:

* Windows Service Control:
  * List all services and details, navigate in the list by typing service name.
  * Control service running state: stop, start, pause, and resume.
  * Configure service: change startup type, set startup account.
  * Query service dependency: extended information available after state refresh.
  * Query service registry parameters: extended information available after state refresh.
  * Query service clustering information.

* Event Viewer:
  * Simple query for last events.
  * Search in latest events for a simple or regular expression.
  * XPath query for advanced search (query builder not implemented).
  * Human readable and native XML views are supported.

* Registry Editor:
  * Remotely browse for registry key and values.
  * Create new keys and values.
  * Edit values: default, d-word, q-word, string, expand string, multi string, and binary types.

* Local Computer Certificates:
  * Coming soon

## User Manual

Please refer to my blog article: [Day-to-day admin task automation with SCOM Console extension](https://maxcoreblog.com/2020/12/05/day-to-day-admin-task-automation-with-scom-console-extension/).

## Join development
If you like this management pack and find it useful for your day-to-day activities, 
but missing a critical feature, please join me developing new tasks and their UI.