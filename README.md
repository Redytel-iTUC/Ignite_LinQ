# Ignite_LinQ

## Prerequisites
As in the Apache Ignite web indicates, you must have (at least) the following components:
```
JDK: 			8+

OS:			Windows (7 and up),
			Windows Server (2008 R2 and up),
			Linux (any distro with .NET Core support),
			macOS
      
Network:		No restrictions (10G recommended)

Hardware:		No restrictions

.NET Framework:		.NET 4.0+, .NET Core 2.0+

IDE:			Visual Studio 2010+, Rider, Visual Studio Code, MonoDevelop
```
In addition, you must install the nuget-packages of _Apache.Ignite_ and _Apache.Ignite.LinQ_. 

```
Install-Package Apache.Ignite
Install-Package Apache.Ignite.LinQ
```

## Introduction
Due to the small number of resources available on the subject we provide this quite simple sample of using "LinQ" and "Apache Ignite" frameworks in C# for building a distributed decentralized (cached in memory) NoSQL Data-Base.

This example consists of creating a NoSQL-IMDB of employees pushing data from clients and querying from anyone against its distributed DB .

## HOW TO 
Download both solutions (node1 and node2) and prepare each one on a different computer with Visual Studio. 

Start the Node1 project before Node2 project and then ask from Node2 the name of any employee.

## Conclusion
With Apache-Ignite framework, it is easy and reliable to build a distributed DB.

With distributed DB we will prevent bottle-neck in balancing server (or RAC clustering) for high-performance processing tasks in massive distributed computing environments or neural networks.

In the near future tests will be carried out to check performance. 

Hoping it will help...

<The iTUC team>
