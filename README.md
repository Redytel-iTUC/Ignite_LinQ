# Ignite_LinQ

## Prerequisites

As the Apache Ignite web indicates, you must to have the following components:
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
In adition, you have to install the packages of _Apache.Ignite_ and _Apache.Ignite.LinQ_. To download them, follow this steps:
1. Open the project/solution in Visual Studio, and open the console using the Tools > NuGet Package Manager > Package Manager Console command.
2. Type the following commands:

```
Install-Package Apache.Ignite
Install-Package Apache.Ignite.LinQ
```

## Introduction

This is a simple example of how to use "LinQ" in the tool "Apache Ignite".

The example consist on create a list of employees, publishing it at the cache and make a simple query against a distribuited database.

We have two nodes (Ignite instances) that correspond to the two differents host that each one has a part of the list of the employees.
Both nodes publish their own parts (distint parts) of the list, but second one query through the distributed database.

## HOW TO 

Download both nodes, each one in a diferent computer.
Open both projects with your Visual Studio and start the Node1 project and then start the Node2 project.   

## Conclusion

We publish this example due to the small number of examples available about the subject, hoping it will help anyone wants to practice it.

In the near future, tests will be carried out to check the performance.

I.A.
